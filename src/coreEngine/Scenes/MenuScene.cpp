#include "MenuScene.hpp"

#include "../../Constantes.hpp"
#include "../SDL/SDLHandler.hpp"
#include "../InputManager.hpp"
#include "../Camera.hpp"
#include "../../gameobject/GUI/MenuGeneric.hpp"

MenuScene::MenuScene(MenuGeneric* ActualMenu){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    input = &InputManager::getInstance();
    menu = ActualMenu;
    
};
MenuScene::~MenuScene(){};

EVENT_ENUM_TYPE MenuScene::update(){
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