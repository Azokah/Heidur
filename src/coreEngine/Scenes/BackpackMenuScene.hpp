#include <iostream>
#include "../../Constantes.hpp"
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class BackpackMenu;

using namespace globals;

class BackpackMenuScene : public Scene {
    public:
        BackpackMenuScene();
        ~BackpackMenuScene();

        virtual EVENT_ENUM_TYPE update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        BackpackMenu * menu;

};