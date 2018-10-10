#include "InventoryMenuScene.hpp"

#include "../../Constantes.hpp"
#include "../SDL/SDLHandler.hpp"
#include "../InputManager.hpp"
#include "../Camera.hpp"
#include "../../gameobject/GUI/InventoryMenu.hpp"

InventoryMenuScene::InventoryMenuScene(){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    input = &InputManager::getInstance();
    menu = &InventoryMenu::getInstance();
    
};
InventoryMenuScene::~InventoryMenuScene(){};

EVENT_ENUM_TYPE InventoryMenuScene::update(){
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