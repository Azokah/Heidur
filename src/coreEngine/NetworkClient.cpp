/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "NetworkClient.hpp"
#include "Timer.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "GOManager.hpp"

NetworkClient& NetworkClient::getInstance(){
  static NetworkClient instance;
  return instance;
};
NetworkClient::NetworkClient(){
  Init();
  SDLNet_ResolveHost(&ip,MASTER_SERVER_IP,MASTER_SERVER_PORT);
  std::cout<<"Attempting connection with server...\n";
  
  //Set socketset size
  socketset=SDLNet_AllocSocketSet(MAX_CLIENT_SOCKETSET);
  if(!socketset) globals::getError("Cannot initialize socketsets",SOCKET_SETS_ERROR);

  client = SDLNet_TCP_Open(&ip);
  if(!client) globals::getError("No se ha podido conectar con el servidor...", CANNOT_CONNECT_ERROR);
  else  {
    //Add sockets to socketset
    if(SDLNet_TCP_AddSocket(socketset,client) == -1)
      globals::getError("Cannot add socket to socketsets",SOCKET_SETS_ERROR_2);
  }

};
NetworkClient::~NetworkClient(){
  std::cout<<"Closing connection with server...\n";
  SDLNet_TCP_Close(client);
  Quit();
};

void NetworkClient::updatePlayer(Player* p){
  //This should be done via UDP i think
  char txt[BUFFER_SIZE];
  int size;
  size = sprintf(txt,"%d: %d %d\n",PLAYER_DATA_CODE,p->sprite->position.x, p->sprite->position.y);
  SDLNet_TCP_Send(client,txt,size);
};

//Method that checks on sockets if recieved bytes
void NetworkClient::checkSockets(){
  char buffer[BUFFER_SIZE];
  int numPkts;
  // Wait for up to 1 second for network activity
  //SDLNet_SocketSet set;
  int socketState = SDLNet_CheckSockets(socketset, CLIENT_CHECKSOCKET_MS);
  if( socketState == -1)
    globals::getError(SDLNet_GetError(),SOCKET_SETS_ERROR_2);
  else if( socketState != 0){
      // check all sockets with SDLNet_SocketReady and handle the active ones.
      if(SDLNet_SocketReady(client)) {
        numPkts=SDLNet_TCP_Recv(client,buffer,BUFFER_SIZE);
        if(numPkts) {
            // process the packet.
            std::cout<<buffer<<std::endl;
            processBuffer(buffer);
        }
      }
    }
};

//Method that process the recieved buffer from the TCP Socket
void NetworkClient::processBuffer(std::string buffer){
  buffer = buffer.substr(0, buffer.find("\n"));
  
  std::string operationCode = buffer.substr(0, buffer.find(":")); //Get operationCode
  buffer = buffer.substr(buffer.find(" ")+1); //get the next substring
  int opCode = std::stoi(operationCode); //parse opcode to int
  int value; //Value, used to store data
  int pos_x, pos_y;//used to store data


  switch(opCode){//switch by opcode
    case NEW_PLAYER_CONNECTED_CODE: //if a new player connected
      value = std::stoi(buffer);//get client id
      GOManager::getInstance().playerFromConnection(value); //Add new player by id
      break;
    case PLAYER_DATA_CODE://if a player moved

      //get his new position
      pos_x = std::stoi(buffer.substr(0, buffer.find(" ")));
      buffer = buffer.substr(buffer.find(" ")+1);
      pos_y = std::stoi(buffer.substr(0, buffer.find("%d")));
      buffer = buffer.substr(buffer.find(" ")+1);
      value = std::stoi(buffer.substr(0, buffer.find("%d")));

      GOManager::getInstance().updatePlayer(value,pos_x,pos_y);//Move player by id to his new position
      break;
    default:
      std::cout<<"Opcode recieved: "<<opCode<<std::endl;
      break;
  }
};
void NetworkClient::update(){
  checkSockets();
};

bool NetworkClient::Init() {
    if (SDLNet_Init() < 0) {
        globals::getError("Cannot initialize NetworkClient",NETWORK_ERROR);
          return false;
        }
        else
            return true;
}
 
void NetworkClient::Quit() {
    SDLNet_Quit();
}