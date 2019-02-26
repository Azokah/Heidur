#include "MainGameScene.hpp"

#include "../../Constantes.hpp"
#include "../SDL/SDLHandler.hpp"
#include "../InputManager.hpp"
#include "../Camera.hpp"
#include "../GOManager.hpp"
#include "../../gameobject/Player.hpp"
#include "../../gameobject/Scenario.hpp"
#include "../../gameobject/components/Sprite.hpp"


MainGameScene::MainGameScene(){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    gom = &GOManager::getInstance();
    gom->poblateMonsters();
    map = &Scenario::getInstance();
    input = &InputManager::getInstance();
    player = &Player::getInstance();
    
};
MainGameScene::~MainGameScene(){};

EVENT_ENUM_TYPE MainGameScene::update(){
    EVENT_ENUM_TYPE inputAction;

    float delta = sdl->getDelta();

    inputAction = input->processInput(player); //Input
    
    //Update entities
    player->update(delta);
    camera->update(delta,player);
    gom->update(delta,player);

    //Drawing sequence
    sdl->cleanRender();
    map->draw();
    player->draw();
    /*
    for(int i = 0; i < GRID_MAX_H;i++){
        for(int j = 0; j< GRID_MAX_W; j++){
            gom->draw(i,j);
        }
    }*/
    gom->draw();
    sdl->draw(); 
    
    return inputAction;
};