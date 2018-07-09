#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

enum ITEM_TYPE {
    PLACEHOLDER,
    BUSH
};

class Sprite;
class Physics;
class Stats;
class Player;

class Item{
    public:
        virtual ~Item() {};

        virtual void update(float,Player*) = 0;
        virtual void draw() = 0;
        
        virtual void action(Player*) = 0;
        
    //private:
        Sprite * sprite;
        Physics * physics;
        Stats * stats;

        ITEM_TYPE type;

        std::string name, description;

};
