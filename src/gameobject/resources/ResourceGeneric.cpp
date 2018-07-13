#include "ResourceGeneric.hpp"
#include "../Player.hpp"
#include "../components/Sprite.hpp"
#include "../components/Physics.hpp"
#include "../components/Stats.hpp"
#include "../components/Inventory.hpp"
#include "../../coreEngine/Timer.hpp"
#include "../items/ItemGeneric.hpp"

ResourceGeneric::ResourceGeneric(RESOURCE_TYPE TYPE,int y,int x):Resource(){
    srand(time(NULL));

    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
    resourceType = TYPE;
    switch(resourceType){
        case BUSH:
            sprite->setDest(SPRITE_BUSH);
            sprite->position.y = y*TILE_H;
            sprite->position.x = x*TILE_W;
            name = "Bush";
            description = "Used to craft things.";
            itemType = STICK;
            break;
        case ROCK:
            sprite->setDest(SPRITE_ARROW);
            sprite->position.y = y*TILE_H;
            sprite->position.x = x*TILE_W;
            name = "Stone";
            description = "Used to craft things.";
            itemType = STONE;
            break;
        default:
            break;
    }
    
    cooldown = false;
};
ResourceGeneric::~ResourceGeneric(){
    delete physics;
    delete sprite;
    delete stats;
};

void ResourceGeneric::action(Player* p){
    p->inventory->items.push_back(new ItemGeneric(itemType)); //Añade un item del tipo del recurso
    //std::cout<<"Aded bush fruit to player\n"; //TESTUSE
    goInCooldown();
};

void ResourceGeneric::update(float delta,Player* p){
    if(!cooldown){
        physics->update(delta,sprite);
        sprite->update(delta);
        stats->update(delta);
        if(sprite->wasClicked){
            if(p->sprite->getDistanceFromSprite(sprite) <= PICKUP_ITEM_DISTANCE){
                action(p); 
            }
            sprite->resetClickedStatus();
        }
    }else checkCooldown();
};

void ResourceGeneric::draw(){
    if(!cooldown)
        sprite->draw();
};

void ResourceGeneric::goInCooldown(){
    cooldown = true;
    cooldownTick = Timer::getInstance().get_ticks() + STANDAR_COOLDOWN ;
};

void ResourceGeneric::checkCooldown(){
    if(Timer::getInstance().get_ticks() > cooldownTick){
        cooldown = false;
        sprite->position.y = (rand()%GRID_MAX_H)*TILE_H;
        sprite->position.x = (rand()%GRID_MAX_W)*TILE_W;
        
    }
};