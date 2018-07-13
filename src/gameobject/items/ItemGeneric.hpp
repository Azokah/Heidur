#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "Item.hpp"
#include "../../Constantes.hpp"
#include "Item.hpp"

using namespace globals;


class ItemGeneric : public Item{
    public:
        ItemGeneric(ITEM_TYPE);
        ~ItemGeneric();

        virtual void update(float,Player*);
        virtual void draw();
};
