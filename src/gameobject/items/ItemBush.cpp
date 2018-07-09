#include "ItemBush.hpp"
#include "../Player.hpp"
#include "../components/Sprite.hpp"
#include "../components/Physics.hpp"
#include "../components/Stats.hpp"
#include "../components/Inventory.hpp"


ItemBush::ItemBush(int y,int x):Item(){
    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
    sprite->setDest(SPRITE_BUSH);
    sprite->position.y = y*TILE_H;
    sprite->position.x = x*TILE_W;
    type = BUSH;
    name = "Bush.";
    description = "Used to craft things.";
};
ItemBush::~ItemBush(){
    delete physics;
    delete sprite;
    delete stats;
};

void ItemBush::action(Player* p){
    p->inventory->items.push_back(this);
    std::cout<<"Aded bush fruit to player\n"; //TESTUSE
};

void ItemBush::update(float delta,Player* p){
    physics->update(delta,sprite);
    sprite->update(delta);
    stats->update(delta);
    if(sprite->wasClicked){
        if(p->sprite->getDistanceFromSprite(sprite) <= PICKUP_ITEM_DISTANCE){
            action(p); 
        }
        sprite->resetClickedStatus();
    }
};

void ItemBush::draw(){
    sprite->draw();
};