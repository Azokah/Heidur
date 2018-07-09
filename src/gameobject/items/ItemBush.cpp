#include "ItemBush.hpp"
#include "../components/Sprite.hpp"
#include "../components/Physics.hpp"
#include "../components/Stats.hpp"

ItemBush::ItemBush(int y,int x):Item(){
    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
    sprite->setDest(SPRITE_BUSH);
    sprite->position.y = y*TILE_H;
    sprite->position.x = x*TILE_W;
    type = BUSH;
};
ItemBush::~ItemBush(){
    delete physics;
    delete sprite;
    delete stats;
};

void ItemBush::action(){

};

void ItemBush::update(float delta){
    physics->update(delta,sprite);
    sprite->update();
    stats->update();

};

void ItemBush::draw(){
    sprite->draw();
};