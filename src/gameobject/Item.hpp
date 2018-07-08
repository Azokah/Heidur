#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

enum ITEM_TYPE {
    PLACEHOLDER,
    BUSH
};

class Sprite;
class Physics;
class Stats;

class Item{
    public:
        Item(ITEM_TYPE,int,int);
        ~Item();

        void update(float);
        void draw();
        
    //private:
        Sprite * sprite;
        Physics * physics;
        Stats * stats;

        ITEM_TYPE type;

};
