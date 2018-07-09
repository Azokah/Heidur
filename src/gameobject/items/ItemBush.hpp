#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"
#include "Item.hpp"


class ItemBush : public Item{
    public:
        ItemBush(int,int);
        ~ItemBush();

        virtual void update(float);
        virtual void draw();
        
        virtual void action();
    

};
