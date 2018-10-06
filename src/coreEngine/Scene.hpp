#include <iostream>
#include <SDL2/SDL.h>

class Scene {
    public:
        virtual ~Scene(){};

        virtual SDL_EventType update() = 0;
};