/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/items/Item.hpp"
#include "../gameobject/items/ItemBush.hpp"

GOManager::~GOManager(){};
GOManager::GOManager(){
    items.push_back(new ItemBush(15,5));
    items.push_back(new ItemBush(5,15));
};

GOManager& GOManager::getInstance(){
    static GOManager instance;
    return instance;
};
void GOManager::update(float delta,Player* player){
    for(auto& i : items)
        i->update(delta,player);
};

void GOManager::draw(){
    for(auto& i : items)
        i->draw();
};
