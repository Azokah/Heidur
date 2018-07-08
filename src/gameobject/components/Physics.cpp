#include "Physics.hpp"
#include "Sprite.hpp"


Physics::Physics(){
    speed = PLAYERS_SPEED_BASE;
    movingUp = movingDown = movingRight = movingLeft = false;
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
void Physics::moveUp(){ movingUp = true;};
void Physics::moveDown(){ movingDown = true; };
void Physics::moveLeft(){ movingLeft = true; };
void Physics::moveRight(){ movingRight = true; };

void Physics::stopUp(){ movingUp = false; };
void Physics::stopLeft(){ movingLeft = false; };
void Physics::stopRight(){ movingRight = false; };
void Physics::stopDown(){ movingDown = false; };