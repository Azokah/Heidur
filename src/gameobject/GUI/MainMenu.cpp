#include "MainMenu.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"
#include "../../coreEngine/Scenes/MainGameScene.hpp"

MainMenu::MainMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("New Game"));
    menus.push_back(new MenuComponent("Resume"));
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
            if(SceneManager::getInstance().state != CORRIENDO){
                std::cout<<"Starting game..."<<std::endl;//Starting game when game already started is wrong
                SceneManager::getInstance().nextScene(new MainGameScene());
                SceneManager::getInstance().state = CORRIENDO;
            }
            break;
        case 1:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        case 3:
            std::cout<<"Exit game..."<<std::endl;
            SceneManager::getInstance().exitGame();
            break;
        default:
            break;

    }
};