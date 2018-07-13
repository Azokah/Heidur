#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

using namespace globals;

class Sprite;
class Stats;
class Item;


class ItemGeneric{
    public:
        ItemGeneric(ITEM_TYPE);
        ~ItemGeneric();

        void update(float);
        void draw();

        Sprite * sprite;
        Stats * stats;
        Item * item;
};
