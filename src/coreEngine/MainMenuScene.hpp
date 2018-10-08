#include <iostream>
#include "../Constantes.hpp"
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class MainMenu;

using namespace globals;

class MainMenuScene : public Scene {
    public:
        MainMenuScene();
        ~MainMenuScene();

        virtual EVENT_ENUM_TYPE update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        MainMenu * menu;

};