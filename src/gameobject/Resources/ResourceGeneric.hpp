#pragma once
#include <iostream>
#include <string>
#include <stdlib.h>
#include <time.h>  
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class Physics;
class Sprite;
class Stats;
class Resource;
class Player;

using namespace globals;

class ResourceGeneric{
    public:
        ResourceGeneric(int,int);
        ResourceGeneric(int,int,int);
        ~ResourceGeneric();

        void update(float,Player*);
        void draw(int,int);
        void draw();
        
        
        Physics * physics;
        Sprite * sprite;
        Resource * resource;
};
