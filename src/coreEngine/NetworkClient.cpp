#include "NetworkClient.hpp"
 
NetworkClient& NetworkClient::getInstance(){
  static NetworkClient instance;
  return instance;
};
NetworkClient::NetworkClient(){
  Init();
  SDLNet_ResolveHost(&ip,MASTER_SERVER_IP,MASTER_SERVER_PORT);
};
NetworkClient::~NetworkClient(){
  std::cout<<"Closing connection with server...\n";
  SDLNet_TCP_Close(server);
  Quit();
};


void NetworkClient::update(){
  std::cout<<"Attempting connection with server...\n";
  client = SDLNet_TCP_Open(&ip);
  char text[MAX_BUFFER_DATA];
  SDLNet_TCP_Recv(client,text,MAX_BUFFER_DATA);
  std::cout<<text;
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