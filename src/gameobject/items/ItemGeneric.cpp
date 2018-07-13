#include "ItemGeneric.hpp"
#include "../Player.hpp"
#include "../components/Sprite.hpp"
#include "../components/Stats.hpp"


ItemGeneric::ItemGeneric(ITEM_TYPE TYPE):Item(){
    type = TYPE;
    sprite = new Sprite();
    stats = new Stats();

    switch(type){
        case STICK:
            name = "Stick";
            description = "Used to craft things.";
            sprite->setDest(SPRITE_STICK);
            break;
        case STONE:
            name = "Arrow";
            description = "Used to shoot with a bow.";
            sprite->setDest(SPRITE_ARROW);
            break;
        default:
            name = "Unknown";
            description = "Who knows?";
            break;
    }
    

    
};
ItemGeneric::~ItemGeneric() {};

void ItemGeneric::update(float delta,Player* p){
    sprite->update(delta);
    stats->update(delta);
};
void ItemGeneric::draw(){
    sprite->draw();
};

