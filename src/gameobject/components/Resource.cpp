#include "Resource.hpp"
#include "Inventory.hpp"
#include "Stats.hpp"
#include "../Player.hpp"
#include "../Items/ItemGeneric.hpp"
#include "../../coreEngine/SDL/Timer.hpp"


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
    p->stats->experience+=MIN_EXP_GAIN;
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