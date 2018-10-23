#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../../Constantes.hpp"


class MenuComponent;

class MenuGeneric {
    public:
        MenuGeneric();
        ~MenuGeneric();

        virtual void update(float);
        void draw();

        bool activate();
        bool deactivate();


        void nextOption();
        void previousOption();
        virtual void execute();

        bool active;

        SDL_Rect bgRect;
        std::vector<MenuComponent*> menus;

    protected:
        int getMaxString();

        int currentOption;
};