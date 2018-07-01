#include <iostream>
#include <vector>
#include "Constantes.hpp"
#include "coreEngine/SDLHandler.hpp"
#include "coreEngine/InputManager.hpp"
#include "coreEngine/NetworkClient.hpp"
#include "coreEngine/GOManager.hpp"
#include "gameobject/Player.hpp"
#include "gameobject/Monster.hpp"
#include "gameobject/Scenario.hpp"
#include "gameobject/components/Sprite.hpp"



using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting game...." << endl;
    
    SDLHandler * sdl = &SDLHandler::getInstance();
    InputManager input;
    //NetworkClient * net = &NetworkClient::getInstance();
    Player player;
    Monster monster;
    Scenario * map = &Scenario::getInstance();;
    GOManager * gom = &GOManager::getInstance();

    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();
        //Networking (Should be another thread)
        //net->update();
        //net->updatePlayer(&player);

        inputAction = input.processInput(&player); //Input
        
        //Update entities
        player.update(delta);
        monster.update(delta);
        gom->update(delta);
        
        //Drawing sequence
        sdl->cleanRender();
        map->draw();
        player.draw();
        monster.draw();
        gom->draw();
        sdl->draw();
    }
    return 0;
};