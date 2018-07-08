#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <sstream>
#include <string>
#include "../Constantes.hpp"

class Sprite;
class Grid;

class Scenario{
    public:
        static Scenario& getInstance();
        
        ~Scenario();

        void update(float);
        void draw();
        bool testColision(int,int);

        Sprite * sprite;
        Grid * grid;

        private:
            Scenario();

            void load();
            void load(std::string);
};
