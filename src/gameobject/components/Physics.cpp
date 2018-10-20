#include "Physics.hpp"
#include "Sprite.hpp"


Physics::Physics(){
    speed = PLAYERS_SPEED_BASE;
    movingUp = movingDown = movingRight = movingLeft = false;
    facing = SOUTH;
};
Physics::~Physics(){};

void Physics::update(float delta, Sprite* sprite){
    
    float totalMove = speed*delta;

    if (movingUp && Scenario::getInstance().testColision(sprite->position.y-totalMove,sprite->position.x))
        sprite->position.y -= totalMove;
    if (movingDown && Scenario::getInstance().testColision(sprite->position.y+totalMove,sprite->position.x))
        sprite->position.y += totalMove;
    if (movingRight && Scenario::getInstance().testColision(sprite->position.y,sprite->position.x+totalMove))
        sprite->position.x += totalMove;
    if (movingLeft&& Scenario::getInstance().testColision(sprite->position.y,sprite->position.x-totalMove))
        sprite->position.x -= totalMove;
};
void Physics::moveUp(){
    movingUp = true;
    facing = NORTH;
};
void Physics::moveDown(){
    movingDown = true;
    facing = SOUTH;
};
void Physics::moveLeft(){
    movingLeft = true;
    facing = WEST;
};
void Physics::moveRight(){
    movingRight = true;
    facing = EAST;
};

void Physics::stopUp(){ movingUp = false; };
void Physics::stopLeft(){ movingLeft = false; };
void Physics::stopRight(){ movingRight = false; };
void Physics::stopDown(){ movingDown = false; };