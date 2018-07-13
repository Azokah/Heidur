#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"
#include "Resource.hpp"

class ResourceBush : public Resource{
    public:
        ResourceBush(int,int);
        ~ResourceBush();

        virtual void update(float,Player*);
        virtual void draw();
        
        virtual void action(Player*);

        virtual void goInCooldown();
        virtual void checkCooldown();

};
