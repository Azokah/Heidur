#include <iostream>
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class Player;
class GOManager;
class Scenario;

class MainGameScene : public Scene {
    public:
        MainGameScene();
        ~MainGameScene();

        virtual SDL_EventType update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        Player * player;
        //Monster monster(15,15);
        GOManager * gom;
        Scenario * map;
};