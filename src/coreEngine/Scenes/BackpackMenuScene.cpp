#include "BackpackMenuScene.hpp"

#include "../../Constantes.hpp"
#include "../SDL/SDLHandler.hpp"
#include "../InputManager.hpp"
#include "../Camera.hpp"
#include "../../gameobject/GUI/BackpackMenu.hpp"

BackpackMenuScene::BackpackMenuScene(){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    input = &InputManager::getInstance();
    menu = &BackpackMenu::getInstance();
    
};
BackpackMenuScene::~BackpackMenuScene(){};

EVENT_ENUM_TYPE BackpackMenuScene::update(){
    EVENT_ENUM_TYPE inputAction;
    
    float delta = sdl->getDelta();

    inputAction = input->processInput(menu); //Input
    
    //Update entities
    menu->update(delta);

    //Drawing sequence
    sdl->cleanRender();
    menu->draw();
    sdl->draw();

    return inputAction;
};