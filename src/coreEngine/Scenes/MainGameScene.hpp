#include <iostream>
#include "../../Constantes.hpp"
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class Player;
class GOManager;
class Scenario;

using namespace globals;

class MainGameScene : public Scene {
    public:
        MainGameScene();
        ~MainGameScene();

        virtual EVENT_ENUM_TYPE update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        Player * player;
        GOManager * gom;
        Scenario * map;
};