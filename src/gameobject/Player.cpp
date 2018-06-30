#include "Player.hpp"
#include "components/Sprite.hpp"


Player::Player(){
    sprite = new Sprite();
};
Player::~Player(){};


void Player::update(float delta){
    sprite->update();
};