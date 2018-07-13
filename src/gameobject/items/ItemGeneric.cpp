#include "ItemGeneric.hpp"
#include "../Player.hpp"
#include "../components/Sprite.hpp"
#include "../components/Stats.hpp"


ItemGeneric::ItemGeneric(ITEM_TYPE TYPE):Item(){
    type = TYPE;
    name = "Stick";
    description = "Used to craft things.";

    sprite = new Sprite();
    stats = new Stats();
};
ItemGeneric::~ItemGeneric() {};

void ItemGeneric::update(float delta,Player* p){
    sprite->update(delta);
    stats->update(delta);
};
void ItemGeneric::draw(){
    sprite->draw();
};

