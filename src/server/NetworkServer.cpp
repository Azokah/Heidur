#include "NetworkServer.hpp"
 
NetworkServer& NetworkServer::getInstance(){
  static NetworkServer instance;
  return instance;
};
NetworkServer::NetworkServer(){
  connectedClients = 0;
  Init();
  SDLNet_ResolveHost(&ip,NULL,MASTER_SERVER_PORT);
  server = SDLNet_TCP_Open(&ip);

  //Set socketset size
  clients=SDLNet_AllocSocketSet(MAX_CLIENTS);
  if(!clients) globals::getError("Cannot initialize socketsets",SOCKET_SETS_ERROR);

  //Add sockets to socketset
  if(SDLNet_TCP_AddSocket(clients,server) == -1)
    globals::getError("Cannot add socket to socketsets",SOCKET_SETS_ERROR_2);
  connectedClients++;

};
NetworkServer::~NetworkServer(){
  std::cout<<"Closing the server...\n";
  for(int c = 0; c < MAX_CLIENTS; c++)
    SDLNet_TCP_Close(client[c]);
  SDLNet_TCP_Close(server);
  Quit();
};


void NetworkServer::update(){
  checkConnections();
  checkSockets();

};

//Method that checks if a new Player has connected
void NetworkServer::checkConnections(){
  int socketState = SDLNet_CheckSockets(clients, SERVER_CHECKSOCKET_MS);
  if( socketState == -1)
    globals::getError(SDLNet_GetError(),SOCKET_SETS_ERROR_2);
  else if(socketState != 0){
  std::cout<<"The server socket has activity\n";
  // check all sockets with SDLNet_SocketReady and handle the active ones.
    if(SDLNet_SocketReady(server)) {
      client[connectedClients] = SDLNet_TCP_Accept(server);
      connectedClients++;
      if(SDLNet_TCP_AddSocket(clients,client[connectedClients-1]) == -1)
        globals::getError(SDLNet_GetError(),SOCKET_SETS_ERROR_2);
      std::cout<<"A new player has connected!\n";
      if(client[connectedClients-1]) {
          //play with client
          notifyNewPlayerOnline(connectedClients-1);
      }
    }
  }
};

//Method that checks on sockets
void NetworkServer::checkSockets(){
  char buffer[BUFFER_SIZE];
  int numPkts;
  // Wait for up to 1 second for network activity
  //SDLNet_SocketSet set;
  int socketState = SDLNet_CheckSockets(clients, SERVER_CHECKSOCKET_MS);
  if( socketState == -1)
    globals::getError(SDLNet_GetError(),SOCKET_SETS_ERROR_2);
  else if( socketState != 0){
      // check all sockets with SDLNet_SocketReady and handle the active ones.
      for(int c = 0; c < MAX_CLIENTS; c++){
        if(SDLNet_SocketReady(client[c])) {
          numPkts=SDLNet_TCP_Recv(client[c],buffer,BUFFER_SIZE);
          if(numPkts) {
              // process the packet.
              std::cout<<buffer<<std::endl;
          }
        }
      }

  }

};

//Method that informs clients when a new player connected
//It takes the client number that recently connected as a parameter
void NetworkServer::notifyNewPlayerOnline(int clientId){
  char txt_c[25], txt_clientId[25];
  sprintf(txt_c,"%d: %d",NEW_PLAYER_CONNECTED_CODE, clientId);
  
  for(int c = 0; c < MAX_CLIENTS; c++){
    sprintf(txt_clientId,"%d: %d",NEW_PLAYER_CONNECTED_CODE, c);
    if(c != clientId && c != SERVER_SOCKET_NUMBER){
      if(client[c]){
        SDLNet_TCP_Send(client[c],txt_c,strlen(txt_c)+1); //inform of clientId
        SDLNet_TCP_Send(client[clientId],txt_clientId,strlen(txt_clientId)+1); //inform of c
      }
    }
  }
  
};

bool NetworkServer::Init() {
    if (SDLNet_Init() < 0) {
        globals::getError("Cannot initialize NetworkServer",NETWORK_ERROR);
          return false;
        }
        else
            return true;
}
 
void NetworkServer::Quit() {
    SDLNet_Quit();
}