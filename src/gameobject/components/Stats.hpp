#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class Stats {
    public:
        Stats();
        ~Stats();

        void update();
    //private:
        int health, energy, hunger, thirst;
        int actualHealth, actualEnergy, actualHunger, actualThirst;

        int strength, dexterity, wisdom;
};