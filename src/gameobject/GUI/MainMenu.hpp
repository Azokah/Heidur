#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../../Constantes.hpp"
#include "MenuGeneric.hpp"

class MainMenu : public MenuGeneric{
    public:
        
        static MainMenu& getInstance();
        
        MainMenu();
        ~MainMenu();

        void execute();
};