#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class Sprite;
class Physics;
class Stats;
class Player;

using namespace globals;

class Resource{
    public:
        virtual ~Resource() {};

        virtual void update(float,Player*) = 0;
        virtual void draw() = 0;
        
        virtual void action(Player*) = 0;

        virtual void goInCooldown() = 0;
        virtual void checkCooldown() = 0;
        
    //private:
        Sprite * sprite;
        Physics * physics;
        Stats * stats;

        RESOURCE_TYPE resourceType;
        ITEM_TYPE itemType;

        std::string name, description;
        int cooldownTick;
        bool cooldown;

};
