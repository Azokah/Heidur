#include "ItemGeneric.hpp"
#include "Player.hpp"
#include "components/Item.hpp"
#include "components/Sprite.hpp"
#include "components/Stats.hpp"


ItemGeneric::ItemGeneric(ITEM_TYPE TYPE){
    sprite = new Sprite();
    stats = new Stats();
    item = new Item(TYPE);

    switch(TYPE){
        case STICK:
            sprite->setDest(SPRITE_STICK);
            break;
        case STONE:
            sprite->setDest(SPRITE_ARROW);
            break;
        default:
            break;
    }
    

    
};
ItemGeneric::~ItemGeneric() {};

void ItemGeneric::update(float delta){
    sprite->update(delta);
    stats->update(delta);
};
void ItemGeneric::draw(){
    sprite->draw();
};

