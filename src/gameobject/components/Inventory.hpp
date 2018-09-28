#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class ItemGeneric;

class Inventory {
    public:
        Inventory();
        ~Inventory();

        void update(float);

        void toConsole();
        std::vector<ItemGeneric*> items;
};