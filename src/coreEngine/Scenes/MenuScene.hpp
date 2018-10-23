#include <iostream>
#include "../../Constantes.hpp"
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class MenuGeneric;

using namespace globals;

class MenuScene : public Scene {
    public:
        MenuScene(MenuGeneric*);
        ~MenuScene();

        virtual EVENT_ENUM_TYPE update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        MenuGeneric * menu;

};