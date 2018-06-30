#include "NetworkServer.hpp"
 
NetworkServer& NetworkServer::getInstance(){
  static NetworkServer instance;
  return instance;
};
NetworkServer::NetworkServer(){
  Init();
  SDLNet_ResolveHost(&ip,NULL,2715);
  server = SDLNet_TCP_Open(&ip);

};
NetworkServer::~NetworkServer(){
  std::cout<<"Cerrando el server...\n";
  SDLNet_TCP_Close(server);
  Quit();
};


void NetworkServer::update(){
  const char * text = "cliente conectado!\n";
  while(true){
    client = SDLNet_TCP_Accept(server);
    if(client){
      SDLNet_TCP_Send(client,text,strlen(text)+1);
      SDLNet_TCP_Close(client);
      break;
    }
  }
};

bool NetworkServer::Init() {
    if (SDLNet_Init() < 0) {
        globals::getError("No se pudo inicializar el NetworkServer",NETWORK_ERROR);
          return false;
        }
        else
            return true;
}
 
void NetworkServer::Quit() {
    SDLNet_Quit();
}