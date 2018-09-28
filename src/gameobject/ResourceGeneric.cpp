#include "ResourceGeneric.hpp"
#include "Player.hpp"
#include "ItemGeneric.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"
#include "components/Resource.hpp"
#include "components/Inventory.hpp"
#include "../coreEngine/Timer.hpp"


ResourceGeneric::ResourceGeneric(RESOURCE_TYPE TYPE,int y,int x){
    srand(time(NULL));
    physics = new Physics();
    sprite = new Sprite();
    resource = new Resource(TYPE);

    switch(TYPE){
        case BUSH:
            sprite->setDest(SPRITE_BUSH);
            sprite->position.y = y*TILE_H;
            sprite->position.x = x*TILE_W;
            break;
        default:
            //case ROCK:
            sprite->setDest(SPRITE_RESOURCE_GENERIC);
            sprite->position.y = y*TILE_H;
            sprite->position.x = x*TILE_W;
            break;
    }
    
    
};
ResourceGeneric::~ResourceGeneric(){
    delete physics;
    delete sprite;
    delete resource;
};


void ResourceGeneric::update(float delta,Player* p){
    if(!resource->cooldown){
        physics->update(delta,sprite);
        sprite->update(delta);
        resource->update(delta,p);
        if(sprite->wasClicked){
            if(p->sprite->getDistanceFromSprite(sprite) <= PICKUP_ITEM_DISTANCE){
                resource->action(p); 
            }
            sprite->resetClickedStatus();
        }
    }else{
        resource->checkCooldown();
        sprite->position.y = (rand()%GRID_MAX_H)*TILE_H;
        sprite->position.x = (rand()%GRID_MAX_W)*TILE_W;
    }
};

void ResourceGeneric::draw(){
    if(!resource->cooldown)
        sprite->draw();
};