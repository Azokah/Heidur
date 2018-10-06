#include "InventoryMenu.hpp"
#include "components/MenuComponent.hpp"

InventoryMenu& InventoryMenu::getInstance(){
    static InventoryMenu instance;
    return instance;
}

InventoryMenu::InventoryMenu():MenuGeneric(){
    menus.push_back(new MenuComponent("Inventory detail"));
};
InventoryMenu::~InventoryMenu(){
};
