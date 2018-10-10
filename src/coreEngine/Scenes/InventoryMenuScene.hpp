#include <iostream>
#include "../../Constantes.hpp"
#include "Scene.hpp"

class SDLHandler;
class Camera;
class InputManager;
class InventoryMenu;

using namespace globals;

class InventoryMenuScene : public Scene {
    public:
        InventoryMenuScene();
        ~InventoryMenuScene();

        virtual EVENT_ENUM_TYPE update();

    private:

        SDLHandler * sdl;
        Camera * camera;
        InputManager * input;

        InventoryMenu * menu;

};