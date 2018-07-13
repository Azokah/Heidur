#include "Resource.hpp"
#include "Inventory.hpp"
#include "../Player.hpp"
#include "../ItemGeneric.hpp"
#include "../../coreEngine/Timer.hpp"


Resource::Resource(RESOURCE_TYPE TYPE){
    resourceType = TYPE;
    switch(resourceType){
        case BUSH:
            name = "Bush";
            description = "Used to craft things.";
            itemType = STICK;
            break;
        case ROCK:
            name = "Stone";
            description = "Used to craft things.";
            itemType = STONE;
            break;
        default:
            break;
    }
    cooldown = false;
};
Resource::~Resource(){
};

void Resource::action(Player* p){
    p->inventory->items.push_back(new ItemGeneric(itemType)); //Añade un item del tipo del recurso
    //std::cout<<"Aded bush fruit to player\n"; //TESTUSE
    goInCooldown();
};

void Resource::update(float delta,Player* p){
    //checkCooldown();
};

void Resource::goInCooldown(){
    cooldown = true;
    cooldownTick = Timer::getInstance().get_ticks() + STANDAR_COOLDOWN ;
};

void Resource::checkCooldown(){
    if(Timer::getInstance().get_ticks() > cooldownTick){
        cooldown = false;
    }
};