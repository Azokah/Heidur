#pragma once
#include <iostream>
#include <SDL2/SDL_net.h>
#include "../Constantes.hpp"


class NetworkServer{
  public:
    static NetworkServer& getInstance();
    ~NetworkServer();
    
    void update();

  private:
    NetworkServer();
    IPaddress ip;
    TCPsocket server;
    TCPsocket client;

    bool Init(); //Initialize SDL_net
    void Quit(); //Exit SDL_net
};