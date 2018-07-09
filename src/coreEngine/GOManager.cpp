/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/PlayerExternal.hpp"

GOManager::~GOManager(){};
GOManager::GOManager(){};

GOManager& GOManager::getInstance(){
    static GOManager instance;
    return instance;
};

void GOManager::playerFromConnection(int id){
   players.push_back(new PlayerExternal(id));

};

void GOManager::update(float delta){
    for(auto& p : players){
        p->update(delta);
    }
};
void GOManager::draw(){
    for(auto& p : players){
        p->draw();
    }
};

void GOManager::updatePlayer(int ID, int x, int y){
    for(auto& p : players){
        if(p->getID() == ID){
            p->sprite->position.x = x;
            p->sprite->position.y = y;
        }
    }
};