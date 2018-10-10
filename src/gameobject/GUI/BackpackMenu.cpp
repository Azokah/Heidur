#include "BackpackMenu.hpp"
#include "BackpackMenu.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"


BackpackMenu& BackpackMenu::getInstance(){
    static BackpackMenu instance;
    return instance;
}

BackpackMenu::BackpackMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("Object1"));
    menus.push_back(new MenuComponent("Resume"));
};
BackpackMenu::~BackpackMenu(){
};

void BackpackMenu::execute(){
    switch(currentOption){
        default:
            SceneManager::getInstance().prevScene();
            break;

    }
};
