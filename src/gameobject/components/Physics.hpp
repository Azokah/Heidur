#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"
#include "../Scenario.hpp"

class Sprite;

enum FACING {
    NORTH,
    SOUTH,
    WEST,
    EAST
};

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

        
        FACING facing;
    private:

    bool movingUp, movingDown, movingLeft, movingRight;
    float speed;
};