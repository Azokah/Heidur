#include "NetworkServer.hpp"
 
NetworkServer& NetworkServer::getInstance(){
  static NetworkServer instance;
  return instance;
};
NetworkServer::NetworkServer(){
  Init();
  SDLNet_ResolveHost(&ip,NULL,MASTER_SERVER_PORT);
  server = SDLNet_TCP_Open(&ip);
  client = SDLNet_TCP_Accept(server);

};
NetworkServer::~NetworkServer(){
  std::cout<<"Closing the server...\n";
  SDLNet_TCP_Close(server);
  Quit();
};


void NetworkServer::update(){
  char buffer[BUFFER_SIZE];
  if(client){
    SDLNet_TCP_Recv(client,buffer,BUFFER_SIZE);
    std::cout<<buffer<<std::endl;
  }else{
    client = SDLNet_TCP_Accept(server);
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