#include "ResourceTree.hpp"
#include "../Player.hpp"
#include "../Items/ItemGeneric.hpp"
#include "../components/Sprite.hpp"
#include "../components/Physics.hpp"
#include "../components/Resource.hpp"
#include "../components/Inventory.hpp"
#include "../../coreEngine/SDL/Timer.hpp"


ResourceTree::ResourceTree(int x, int y):ResourceGeneric(x,y){
    resource = new Resource(TREE);
    sprite->setDest(SPRITE_TREE);
};
ResourceTree::~ResourceTree(){};



void ResourceTree::update(float delta,Player* p){
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
        //sprite->position.y = (rand()%GRID_MAX_H)*TILE_H;
        //sprite->position.x = (rand()%GRID_MAX_W)*TILE_W;
    }

};