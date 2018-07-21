#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class MenuComponent {
    public:
        MenuComponent();
        MenuComponent(std::string);
        ~MenuComponent();

        void update(float);

        void toConsole();

        std::string label;
};