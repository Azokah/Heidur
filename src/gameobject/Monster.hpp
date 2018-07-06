#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"


class Sprite;
class Physics;

class Monster{
    public:
        Monster();
        Monster(int,int);
        ~Monster();

        void update(float);
        void draw();
        
    //private:
        Sprite * sprite;
        Physics * physics;

};
