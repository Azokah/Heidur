#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"
#include "../Scenario.hpp"

class Sprite;

class Physics {
    public:
        Physics();
        ~Physics();

        void update(float, Sprite*);

        void moveUp();
        void moveDown();
        void moveLeft();
        void moveRight();

        void stopUp();
        void stopLeft();
        void stopRight();
        void stopDown();

        

    private:

    bool movingUp, movingDown, movingLeft, movingRight;
    float speed;
};