#include "BackpackMenu.hpp"

#include "../Player.hpp"
#include "../components/Inventory.hpp"
#include "../components/Item.hpp"
#include "../Items/ItemGeneric.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"


BackpackMenu& BackpackMenu::getInstance(){
    static BackpackMenu instance;
    return instance;
}

BackpackMenu::BackpackMenu():MenuGeneric(){
    fetchItems();
};
BackpackMenu::~BackpackMenu(){
};

void BackpackMenu::fetchItems(){
    menus.clear();
    menus.push_back(new MenuComponent("Resume"));
    for(auto& i : Player::getInstance().inventory->items){
        menus.push_back(new MenuComponent(i->item->name));
    }
};

void BackpackMenu::update(float delta){
    MenuGeneric::update(delta);
    fetchItems();
}

void BackpackMenu::execute(){
    switch(currentOption){
        case 0:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        default:
            break;

    }
};
