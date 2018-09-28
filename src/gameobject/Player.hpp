#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"


class Sprite;
class Physics;
class Stats;
class Inventory;

class Player{
    public:
        Player();
        ~Player();

        void update(float);
        void draw();
        
    //private:
        Sprite * sprite;
        Physics * physics;
        Stats * stats;
        Inventory * inventory;

};
