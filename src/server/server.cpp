/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include <iostream>
#include "../Constantes.hpp"
#include "NetworkServer.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout <<"Initializing server..\n";
    NetworkServer * server = &NetworkServer::getInstance();
    
    while(true){
        server->update();
    }
    
    return 0;
}