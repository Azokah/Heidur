#include "Physics.hpp"
#include "Sprite.hpp"

Physics::Physics(){
    speed = PLAYERS_SPEED_BASE;
    movingUp = movingDown = movingRight = movingLeft = false;
};
Physics::~Physics(){};

void Physics::update(float delta, Sprite* sprite){
    
    if (movingUp) sprite->position.y -= speed*delta;
    if (movingDown) sprite->position.y += speed*delta;
    if (movingRight) sprite->position.x += speed*delta;
    if (movingLeft) sprite->position.x -= speed*delta;
};
void Physics::moveUp(){ movingUp = true;};
void Physics::moveDown(){ movingDown = true; };
void Physics::moveLeft(){ movingLeft = true; };
void Physics::moveRight(){ movingRight = true; };

void Physics::stopUp(){ movingUp = false; };
void Physics::stopLeft(){ movingLeft = false; };
void Physics::stopRight(){ movingRight = false; };
void Physics::stopDown(){ movingDown = false; };