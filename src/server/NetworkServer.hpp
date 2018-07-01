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
    TCPsocket client[MAX_CLIENTS+1]; //Actual sockets go add to the container
    SDLNet_SocketSet clients; //Container to manage sockets
    int connectedClients;

    bool Init(); //Initialize SDL_net
    void Quit(); //Exit SDL_net

    void checkSockets();
    void checkConnections();
    void notifyNewPlayerOnline(int); //Method that informs clients when a new player connected
};