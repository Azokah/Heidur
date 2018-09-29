#include "MainMenu.hpp"
#include "components/MenuComponent.hpp"

MainMenu::MainMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("Character"));
    menus.push_back(new MenuComponent("Inventory"));
    menus.push_back(new MenuComponent("Resume"));
    menus.push_back(new MenuComponent("Exit"));
};
MainMenu::~MainMenu(){
};
