#include "StatsMenu.hpp"

#include "../Player.hpp"
#include "../components/Stats.hpp"
#include "../components/Item.hpp"
#include "../Items/ItemGeneric.hpp"
#include "../components/MenuComponent.hpp"
#include "../../coreEngine/SceneManager.hpp"


StatsMenu& StatsMenu::getInstance(){
    static StatsMenu instance;
    return instance;
}

StatsMenu::StatsMenu():MenuGeneric(){
    fetchStats();
};
StatsMenu::~StatsMenu(){
};

void StatsMenu::fetchStats(){
    menus.clear();
    menus.push_back(new MenuComponent("Resume"));
    menus.push_back(new MenuComponent("Health: " + std::to_string(Player::getInstance().stats->health)));
    menus.push_back(new MenuComponent("Energy: " + std::to_string(Player::getInstance().stats->energy)));
    menus.push_back(new MenuComponent("Hunger: " + std::to_string(Player::getInstance().stats->hunger)));
    menus.push_back(new MenuComponent("Thirst: " + std::to_string(Player::getInstance().stats->thirst)));
    menus.push_back(new MenuComponent("Strength: " + std::to_string(Player::getInstance().stats->strength)));
    menus.push_back(new MenuComponent("Dexterity: " + std::to_string(Player::getInstance().stats->dexterity)));
    menus.push_back(new MenuComponent("Wisdom: " + std::to_string(Player::getInstance().stats->wisdom)));
    menus.push_back(new MenuComponent("Experience: " + std::to_string(Player::getInstance().stats->experience)));
};

void StatsMenu::update(float delta){
    MenuGeneric::update(delta);
    fetchStats();
}

void StatsMenu::execute(){
    switch(currentOption){
        case 0:
            std::cout<<"Resuming game..."<<std::endl;
            SceneManager::getInstance().prevScene(); //Segfault fixed with scenemanager scenes != 0
            break;
        default:
            break;

    }
};
