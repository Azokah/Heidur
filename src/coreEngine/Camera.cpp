#include "Camera.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/components/Sprite.hpp"

Camera& Camera::getInstance(){
    static Camera instance;
    return instance;
};
Camera::~Camera(){};
Camera::Camera(){
    init();
};

void Camera::init(){
    bounds.x = bounds.y = 0;
    bounds.w = PANTALLA_AN;
    bounds.h = PANTALLA_AL;
};

void Camera::update(float delta, Player* p){
    bounds.x = p->sprite->position.x - PANTALLA_AN/2;
    bounds.y = p->sprite->position.y - PANTALLA_AL/2;
};