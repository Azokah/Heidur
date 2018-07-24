#include <iostream>
#include <vector>
#include "Constantes.hpp"
#include "coreEngine/SDLHandler.hpp"
#include "coreEngine/InputManager.hpp"
#include "coreEngine/Camera.hpp"
#include "coreEngine/GOManager.hpp"
#include "gameobject/Player.hpp"
#include "gameobject/Monster.hpp"
#include "gameobject/Scenario.hpp"
#include "gameobject/components/Sprite.hpp"
#include "gameobject/MenuGeneric.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting game...." << endl;
    
    SDLHandler * sdl = &SDLHandler::getInstance();
    Camera * camera = &Camera::getInstance();
    InputManager input;

    Player player;
    Monster monster(15,15);
    GOManager * gom = &GOManager::getInstance();
    Scenario * map = &Scenario::getInstance();;
    MenuGeneric * menu = new MenuGeneric();

    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();

        inputAction = input.processInput(&player); //Input
        
        //Update entities
        player.update(delta);
        monster.update(delta);
        camera->update(delta,&player);
        gom->update(delta,&player);
        menu->update(delta);

        //Drawing sequence
        sdl->cleanRender();
        map->draw();
        player.draw();
        monster.draw();
        gom->draw();
        menu->draw();
        sdl->draw();
    }
    return 0;
};