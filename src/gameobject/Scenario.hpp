#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

class Sprite;
class Grid;

class Scenario{
    public:
        Scenario();
        ~Scenario();

        void update(float);
        void draw();

        Sprite * sprite;
        Grid * grid;

};
