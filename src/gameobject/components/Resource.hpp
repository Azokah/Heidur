#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

/*
*   Clase que representa un resource en el juego.
*   Los resource son recursos con los cuales se puede interactuar y devuelven un objeto.
*   Cada resource tiene un resource type al cual esta asociado a un item type.
*/


class Player;

using namespace globals;

class Resource{
    public:
        Resource(RESOURCE_TYPE);
        ~Resource();

        void update(float,Player*);
        
        void action(Player*);

        void goInCooldown();
        void checkCooldown();
        
    //private
        RESOURCE_TYPE resourceType;
        ITEM_TYPE itemType;

        std::string name, description;
        int cooldownTick;
        bool cooldown;

};
