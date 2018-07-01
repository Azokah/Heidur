#pragma once
#include <iostream>
#include <string>
#include <chrono>
#include <SDL2/SDL_net.h>
#include "../Constantes.hpp"

class Player;

class NetworkClient{
  public:
    static NetworkClient& getInstance();
    ~NetworkClient();
    
    void update();
    void updatePlayer(Player*);

  private:
    NetworkClient();
    IPaddress ip;
    TCPsocket client;
    SDLNet_SocketSet socketset; //Container to manage sockets

    bool Init(); //Initialize SDL_net
    void Quit(); //Exit SDL_net

    void checkSockets();
};