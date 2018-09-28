#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../../Constantes.hpp"

class Sprite {
    public:
        Sprite();
        ~Sprite();

        void update(float);

        void draw();
        void drawAt(int,int);

        bool testColision(Sprite *);

        void setDest(int,int,int,int);
        void setDest(int);
        SDL_Rect position, dest;

        bool isClicked(int,int);
        void resetClickedStatus();

        bool wasClicked; //To indicate if sprite was clicked by user

        int getDistanceFromSprite(Sprite*);

    private:
        SDL_Texture * texture;
        void loadTexture(SDL_Renderer*,std::string);

        bool checkInBounds();

       
};