/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/Resources/ResourceGeneric.hpp"
#include "../gameobject/GUI/MenuGeneric.hpp"
#include "../gameobject/GUI/MainMenu.hpp"

GOManager::~GOManager(){};
GOManager::GOManager(){
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
