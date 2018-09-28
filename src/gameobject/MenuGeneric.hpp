#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../Constantes.hpp"

class MenuComponent;

class MenuGeneric {
    public:
        MenuGeneric();
        ~MenuGeneric();

        void update(float);
        void draw();

        bool activate();
        bool deactivate();

        bool active;

        SDL_Rect bgRect;
        std::vector<MenuComponent*> menus;

    private:
        int getMaxString();
};