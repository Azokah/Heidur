#include <iostream>
#include "Constantes.hpp"
#include "coreEngine/SDLHandler.hpp"
#include "gameobject/Player.hpp"
#include "gameobject/components/Sprite.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting window...." << endl;
    
    SDLHandler * sdl = &SDLHandler::getInstance();
    Player player;

    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();

        inputAction = sdl->input();

        player.update(delta);

        sdl->cleanRender();
        player.sprite->draw();
        sdl->draw();
    }
    return 0;
};