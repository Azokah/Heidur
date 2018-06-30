#pragma once
#include <iostream>
#include <SDL2/SDL_net.h>
#include "../Constantes.hpp"


class NetworkClient{
  public:
    static NetworkClient& getInstance();
    ~NetworkClient();
    
    void update();

  private:
    NetworkClient();
    IPaddress ip;
    TCPsocket client;

    bool Init(); //Initialize SDL_net
    void Quit(); //Exit SDL_net
};