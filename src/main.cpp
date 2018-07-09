#include <iostream>
#include <vector>
#include "Constantes.hpp"
#include "coreEngine/SDLHandler.hpp"
#include "coreEngine/InputManager.hpp"
#include "coreEngine/Camera.hpp"
#include "gameobject/Player.hpp"
#include "gameobject/items/ItemBush.hpp"
#include "gameobject/Monster.hpp"
#include "gameobject/Scenario.hpp"
#include "gameobject/components/Sprite.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting game...." << endl;
    
    SDLHandler * sdl = &SDLHandler::getInstance();
    Camera * camera = &Camera::getInstance();
    InputManager input;

    Player player;
    Monster monster(15,15);
    std::vector<Item*> bushes;
    bushes.push_back(new ItemBush(15,5));
    bushes.push_back(new ItemBush(5,15));
    Scenario * map = &Scenario::getInstance();;

    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();

        inputAction = input.processInput(&player,bushes); //Input
        
        //Update entities
        player.update(delta);
        monster.update(delta);
        for(auto& bush : bushes)
            bush->update(delta,&player);
        camera->update(&player);

        //Drawing sequence
        sdl->cleanRender();
        map->draw();
        player.draw();
        monster.draw();
        for(auto& bush : bushes)
            bush->draw();
        sdl->draw();
    }
    return 0;
};