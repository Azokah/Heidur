#include "Player.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"
#include "components/Stats.hpp"

Player::Player(){
    physics = new Physics();
    sprite = new Sprite();
    stats = new Stats();
};
Player::~Player(){
    delete physics;
    delete sprite;
    delete stats;
};


void Player::update(float delta){
    physics->update(delta,sprite);
    sprite->update();
    stats->update();

};

void Player::draw(){
    sprite->draw();
};