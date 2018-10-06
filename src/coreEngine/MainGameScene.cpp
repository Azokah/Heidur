#include "MainGameScene.hpp"

#include "../Constantes.hpp"
#include "SDLHandler.hpp"
#include "InputManager.hpp"
#include "Camera.hpp"
#include "GOManager.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/Monster.hpp"
#include "../gameobject/Scenario.hpp"
#include "../gameobject/components/Sprite.hpp"


MainGameScene::MainGameScene(){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    gom = &GOManager::getInstance();
    map = &Scenario::getInstance();;
    player = new Player();
    input = new InputManager();
};
MainGameScene::~MainGameScene(){};

SDL_EventType MainGameScene::update(){
    SDL_EventType inputAction;
    while (inputAction != SDL_QUIT){
        float delta = sdl->getDelta();

        inputAction = input->processInput(player); //Input
        
        //Update entities
        player->update(delta);
        //monster.update(delta);
        camera->update(delta,player);
        gom->update(delta,player);

        //Drawing sequence
        sdl->cleanRender();
        map->draw();
        player->draw();
        //monster.draw();
        gom->draw();
        sdl->draw();
    }
    return inputAction;
};