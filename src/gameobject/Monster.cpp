#include "Monster.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"


Monster::Monster(){
    physics = new Physics();
    sprite = new Sprite();
    sprite->setDest(0,MONSTER_SPRITE_DEST,1,1);
};
Monster::Monster(int y,int x){
    physics = new Physics();
    sprite = new Sprite();
    sprite->position.x = x*TILE_W;
    sprite->position.y = y*TILE_H;
    sprite->setDest(0,MONSTER_SPRITE_DEST,1,1);
};
Monster::~Monster(){
    delete physics;
    delete sprite;
};


void Monster::update(float delta){
    physics->update(delta,sprite);
    sprite->update();

};

void Monster::draw(){
    sprite->draw();
};