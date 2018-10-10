#include "InventoryMenu.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"
#include "../../coreEngine/Scenes/BackpackMenuScene.hpp"


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
            SceneManager::getInstance().nextScene( new BackpackMenuScene());
            break;
        case 1:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        case 2:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        default:
            break;

    }
};
