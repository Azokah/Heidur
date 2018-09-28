#include "ItemGeneric.hpp"
#include "Player.hpp"
#include "components/Item.hpp"
#include "components/Sprite.hpp"
#include "components/Stats.hpp"


ItemGeneric::ItemGeneric(ITEM_TYPE TYPE){
    sprite = new Sprite();
    sprite->setDest(SPRITE_ITEM);
    stats = new Stats();
    item = new Item(TYPE);
    
};
ItemGeneric::~ItemGeneric() {};

void ItemGeneric::update(float delta){
    sprite->update(delta);
    stats->update(delta);
};
void ItemGeneric::draw(){
    sprite->draw();
};

