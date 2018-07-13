/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/resources/Resource.hpp"
#include "../gameobject/resources/ResourceGeneric.hpp"

GOManager::~GOManager(){};
GOManager::GOManager(){
    items.push_back(new ResourceGeneric(BUSH,15,5));
    items.push_back(new ResourceGeneric(BUSH,5,15));
    items.push_back(new ResourceGeneric(ROCK,6,15));
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
