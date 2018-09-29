/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/ResourceGeneric.hpp"
#include "../gameobject/MenuGeneric.hpp"
#include "../gameobject/MainMenu.hpp"

GOManager::~GOManager(){};
GOManager::GOManager(){
    resources.push_back(new ResourceGeneric(BUSH,15,5));
    resources.push_back(new ResourceGeneric(BUSH,5,15));
    resources.push_back(new ResourceGeneric(ROCK,6,15));
    menu = new MainMenu();
};

GOManager& GOManager::getInstance(){
    static GOManager instance;
    return instance;
};
void GOManager::update(float delta,Player* player){
    for(auto& i : resources)
        i->update(delta,player);
    
    menu->update(delta);
};

void GOManager::draw(){
    for(auto& i : resources)
        i->draw();

    //menu->draw();
};
