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
        SDL_Rect position;

    private:
        SDL_Texture * texture;
        void loadTexture(SDL_Renderer*,std::string);
};