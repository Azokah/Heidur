#include "InventoryMenu.hpp"
#include "BackpackMenu.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"


InventoryMenu& InventoryMenu::getInstance(){
    static InventoryMenu instance;
    return instance;
}

InventoryMenu::InventoryMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("Backpack"));
    menus.push_back(new MenuComponent("Stats"));
    menus.push_back(new MenuComponent("Resume"));
};
InventoryMenu::~InventoryMenu(){
};

void InventoryMenu::execute(){
    switch(currentOption){
        case 0:
            if(SceneManager::getInstance().state != CORRIENDO){
                std::cout<<"Starting game..."<<std::endl;//Starting game when game already started is wrong
                //SceneManager::getInstance().nextScene(new MainGameScene());
                SceneManager::getInstance().state = CORRIENDO;
            }
            break;
        case 1:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        case 3:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        default:
            break;

    }
};
