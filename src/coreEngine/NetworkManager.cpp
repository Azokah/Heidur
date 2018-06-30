#include "NetworkManager.hpp"
 
NetworkManager& NetworkManager::getInstance(){
  static NetworkManager instance;
  return instance;
};
NetworkManager::NetworkManager(){
  Init();
};
NetworkManager::~NetworkManager(){};

bool NetworkManager::Init() {
    if (SDLNet_Init() < 0) {
        globals::getError("No se pudo inicializar el NetworkManager",NETWORK_ERROR);
          return false;
        }
        else
            return true;
}
 
void NetworkManager::Quit() {
    SDLNet_Quit();
}