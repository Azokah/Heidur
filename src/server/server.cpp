#include <iostream>
#include "../Constantes.hpp"
#include "NetworkServer.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout <<"Initializing server..\n";
    NetworkServer * server = &NetworkServer::getInstance();
    
    server->update();

    return 0;
}