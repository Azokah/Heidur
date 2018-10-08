#include "MainMenu.hpp"
#include "components/MenuComponent.hpp"
#include "../coreEngine/SceneManager.hpp"
#include "../coreEngine/MainGameScene.hpp"

MainMenu::MainMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("New Game"));
    menus.push_back(new MenuComponent("Load Game"));
    menus.push_back(new MenuComponent("Options"));
    menus.push_back(new MenuComponent("Exit"));
};
MainMenu::~MainMenu(){
};

MainMenu& MainMenu::getInstance(){
    static MainMenu instance;
    return instance;
};


void MainMenu::execute(){
    switch(currentOption){
        case 0:
            std::cout<<"Starting game..."<<std::endl;
            SceneManager::getInstance().nextScene(new MainGameScene());
            break;
        case 3:
            std::cout<<"Quitting game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        default:
            break;

    }
};