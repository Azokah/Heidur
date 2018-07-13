#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

using namespace globals;

class Player;
class Sprite;
class Stats;

class Item{
    public:
        virtual ~Item() {};

        virtual void update(float,Player*) = 0;
        virtual void draw() = 0;
        
    //private:
        Sprite * sprite;
        Stats * stats;

        ITEM_TYPE type;

        std::string name, description;

};
