#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../Constantes.hpp"
#include "MenuGeneric.hpp"

class InventoryMenu : public MenuGeneric{
    public:
        static InventoryMenu& getInstance();

        InventoryMenu();
        ~InventoryMenu();
};