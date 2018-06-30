#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"


class Sprite;
class Physics;

class Player{
    public:
        Player();
        ~Player();

        void update(float);
    //private:
        Sprite * sprite;
        Physics * physics;

};
