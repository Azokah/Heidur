#include <iostream>
#include "Constantes.hpp"
#include "coreEngine/SDLHandler.hpp"
#include "coreEngine/InputManager.hpp"
#include "coreEngine/NetworkClient.hpp"
#include "gameobject/Player.hpp"
#include "gameobject/Scenario.hpp"
#include "gameobject/components/Sprite.hpp"



using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting game...." << endl;
    
    SDLHandler * sdl = &SDLHandler::getInstance();
    InputManager input;
    NetworkClient * net = &NetworkClient::getInstance();
    Player player;
    Scenario map;
    
    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();

        inputAction = input.processInput(&player);
        
        player.update(delta);
        net->updatePlayer(&player);

        sdl->cleanRender();
        map.draw();
        player.draw();
        sdl->draw();
    }
    return 0;
};