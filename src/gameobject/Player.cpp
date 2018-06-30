#include "Player.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"


Player::Player(){
    physics = new Physics();
    sprite = new Sprite();
};
Player::~Player(){
    delete physics;
    delete sprite;
};


void Player::update(float delta){
    physics->update(delta,sprite);
    sprite->update();

};

void Player::draw(){
    sprite->draw();
};