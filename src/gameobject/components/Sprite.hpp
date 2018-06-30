#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class Sprite {
    public:
        Sprite();
        ~Sprite();

        void update();

        void draw();
        void drawAt(int,int);

        void setDest(int,int,int,int);
        SDL_Rect position, dest;

    private:
        SDL_Texture * texture;
        void loadTexture(SDL_Renderer*,std::string);
};