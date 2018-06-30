#include "Player.hpp"
#include "components/Sprite.hpp"
#include "components/Physics.hpp"


Player::Player(){
    physics = new Physics();
    sprite = new Sprite();
};
Player::~Player(){};


void Player::update(float delta){
    physics->update(delta,sprite);
    sprite->update();

};