#include "Player.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"
#include "components/Stats.hpp"
#include "components/Inventory.hpp"

Player::Player(){
    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
    inventory = new Inventory();
};
Player::~Player(){
    delete physics;
    delete sprite;
    delete stats;
    delete inventory;
};


void Player::update(float delta){
    physics->update(delta,sprite);
    sprite->update(delta);
    stats->update(delta);
    inventory->update(delta);
};

void Player::draw(){
    sprite->draw();
};