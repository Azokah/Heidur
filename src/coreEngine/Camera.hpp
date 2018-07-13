#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

class Player;

class Camera {
    public:
        static Camera& getInstance();
        ~Camera();

        void init();

        void update(float,Player*);

        SDL_Rect bounds;
    private:
        Camera();
};