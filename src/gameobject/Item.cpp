#include "Item.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"
#include "components/Stats.hpp"

Item::Item(ITEM_TYPE typeItem,int y,int x){
    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
    type = typeItem;
    sprite->setDest(0,SPRITE_BUSH,1,1);
    sprite->position.y = y*TILE_H;
    sprite->position.x = x*TILE_W;
};
Item::~Item(){
    delete physics;
    delete sprite;
    delete stats;
};


void Item::update(float delta){
    physics->update(delta,sprite);
    sprite->update();
    stats->update();

};

void Item::draw(){
    sprite->draw();
};