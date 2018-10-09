#include "MainMenuScene.hpp"

#include "../../Constantes.hpp"
#include "../SDL/SDLHandler.hpp"
#include "../InputManager.hpp"
#include "../Camera.hpp"
#include "../../gameobject/GUI/MainMenu.hpp"

MainMenuScene::MainMenuScene(){
    sdl = &SDLHandler::getInstance();
    camera = &Camera::getInstance();
    input = &InputManager::getInstance();
    menu = &MainMenu::getInstance();
    
};
MainMenuScene::~MainMenuScene(){};

EVENT_ENUM_TYPE MainMenuScene::update(){
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