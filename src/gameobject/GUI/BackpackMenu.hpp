#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../../Constantes.hpp"
#include "MenuGeneric.hpp"

class BackpackMenu : public MenuGeneric{
    public:
        static BackpackMenu& getInstance();

        BackpackMenu();
        ~BackpackMenu();

        void execute();

        void update(float);
        void fetchItems();

};