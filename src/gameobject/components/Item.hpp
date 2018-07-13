#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

using namespace globals;

class Item{
    public:
        Item(ITEM_TYPE);
        ~Item();

        void update(float);
        
    //private:

        ITEM_TYPE type;

        std::string name, description;

};
