#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <vector>
#include "../../Constantes.hpp"
#include "MenuGeneric.hpp"

class StatsMenu : public MenuGeneric{
    public:
        static StatsMenu& getInstance();

        StatsMenu();
        ~StatsMenu();

        void execute();

        virtual void update(float);
        void fetchStats();

};