#pragma once
#include <iostream>
#include <SDL2/SDL_net.h>
#include "../Constantes.hpp"


class NetworkManager{
  public:
    static NetworkManager& getInstance();
    ~NetworkManager();
    

  private:
    NetworkManager();
    IPaddress ip;

    bool Init(); //Initialize SDL_net
    void Quit(); //Exit SDL_net
};