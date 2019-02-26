/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
#include "GOManager.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/Monster.hpp"
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

void GOManager::draw(int y, int x){
    for(auto& i : resources)
        i->draw(x,y); //Recorro todos los objetos en cada celda :/

    //menu->draw();
};

void GOManager::draw(){
    for(auto& i : resources)
        i->draw();

    for(auto& m : monsters)
        m->draw();
};


 void GOManager::poblateMonsters(){ //testOnly
     monsters.push_back(std::unique_ptr<Monster>(new Monster(15,15)));
     monsters.push_back(std::unique_ptr<Monster>(new Monster(18,15)));
 }; 

Monster* GOManager::getClosestEnemy(Player*p){
     Monster* closestEnemy = NULL;
     for(auto& m : monsters){
        if(closestEnemy == NULL) closestEnemy = m.get();
        if( p->sprite->getDistanceFromSprite(m->sprite) <
            p->sprite->getDistanceFromSprite(closestEnemy->sprite))
            {
                closestEnemy = m.get();
            }
     }

    return closestEnemy;
 };