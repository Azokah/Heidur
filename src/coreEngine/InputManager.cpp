#include "InputManager.hpp"
#include "SDL/SDLHandler.hpp"
#include "GOManager.hpp"
#include "SceneManager.hpp"
#include "Scenes/MainMenuScene.hpp"
#include "Scenes/InventoryMenuScene.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/Resources/ResourceGeneric.hpp"
#include "../gameobject/components/Physics.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/components/Inventory.hpp"
#include "../gameobject/components/Resource.hpp"
#include "../gameobject/GUI/MenuGeneric.hpp"


InputManager& InputManager::getInstance(){
    static InputManager instance;
    return instance;

};
InputManager::InputManager(){
    up = new MoveUp();
    down = new MoveDown();
    left = new MoveLeft();
    right = new MoveRight();
    stopUp = new StopUp();
    stopDown = new StopDown();
    stopRight = new StopRight();
    stopLeft = new StopLeft();
    toggleInventory = new ToggleInventory();
    interact = new Interact();

    upMenu = new MoveUpMenu();
    downMenu = new MoveDownMenu();
    leftMenu = new MoveLeftMenu();
    rightMenu = new MoveRightMenu();
    stopUpMenu = new StopUpMenu();
    stopDownMenu = new StopDownMenu();
    stopRightMenu = new StopRightMenu();
    stopLeftMenu = new StopLeftMenu();
    interactMenu = new InteractMenu();
};
InputManager::~InputManager(){};



EVENT_ENUM_TYPE InputManager::processInput(MenuGeneric* menu){
    SDL_EventType accion;
    /* Check for events */
    while( SDL_PollEvent( &event ) ){
        switch( event.type ){
            /* Look for a keypress */
            case SDL_KEYDOWN:
                /* Check the SDLKey values and move change the coords */
                switch( event.key.keysym.sym ){
                    case SDLK_ESCAPE:
                        SDL_Quit();
                        //accion = SDL_QUIT;
                        break;
                    case SDLK_F1:
                        SDLHandler::getInstance().takeScreenshot();
                        //accion = SDL_KEYDOWN;
                        break;
                    case SDLK_UP:
                        upMenu->execute(menu);
                        break;
                    case SDLK_DOWN:
                        downMenu->execute(menu);
                        break;
                    case SDLK_RIGHT:
                        rightMenu->execute(menu);
                        break;
                    case SDLK_LEFT:
                        leftMenu->execute(menu);
                        break;
                    case SDLK_z:
                        interactMenu->execute(menu);
                        break;
                    accion = SDL_KEYDOWN;
                }
                break;
            case SDL_KEYUP:
                /* Check the SDLKey values and move change the coords */
                switch( event.key.keysym.sym ){
                    case SDLK_UP:
                        stopUpMenu->execute(menu);
                        break;
                    case SDLK_DOWN:
                        stopDownMenu->execute(menu);
                        break;
                    case SDLK_RIGHT:
                        stopRightMenu->execute(menu);
                        break;
                    case SDLK_LEFT:
                        stopLeftMenu->execute(menu);
                        break;
                    accion = SDL_KEYUP;
                }
                break;
            case SDL_QUIT:
                    SDL_Quit();
                    accion = SDL_QUIT;
                    break;
            default:
                break;
        }
    }

    if(accion == SDL_QUIT) return CLOSE_MENU;
    else return NOTHING;
};

EVENT_ENUM_TYPE InputManager::processInput(Player* player){
    SDL_EventType accion;
    /* Check for events */
    while( SDL_PollEvent( &event ) ){
        switch( event.type ){
            /* Look for a keypress */
            case SDL_KEYDOWN:
                /* Check the SDLKey values and move change the coords */
                switch( event.key.keysym.sym ){
                    case SDLK_ESCAPE:
                        //SDL_Quit();
                        //accion = SDL_QUIT;
                        SceneManager::getInstance().nextScene(new MainMenuScene());
                        break;
                    case SDLK_F1:
                        SDLHandler::getInstance().takeScreenshot();
                        //accion = SDL_KEYDOWN;
                        break;
                    case SDLK_UP:
                        up->execute(player);
                        break;
                    case SDLK_DOWN:
                        down->execute(player);
                        break;
                    case SDLK_RIGHT:
                        right->execute(player);
                        break;
                    case SDLK_LEFT:
                        left->execute(player);
                        break;
                    case SDLK_i:
                        toggleInventory->execute(player);
                        break;
                    case SDLK_z:
                        interact->execute(player);
                        break;
                    accion = SDL_KEYDOWN;
                }
                break;
            case SDL_KEYUP:
                /* Check the SDLKey values and move change the coords */
                switch( event.key.keysym.sym ){
                    case SDLK_UP:
                        stopUp->execute(player);
                        break;
                    case SDLK_DOWN:
                        stopDown->execute(player);
                        break;
                    case SDLK_RIGHT:
                        stopRight->execute(player);
                        break;
                    case SDLK_LEFT:
                        stopLeft->execute(player);
                        break;
                    accion = SDL_KEYUP;
                }
                break;
            case SDL_QUIT:
                    SDL_Quit();
                    accion = SDL_QUIT;
                    break;
            case SDL_MOUSEBUTTONDOWN:
                switch(event.button.button){
                    case SDL_BUTTON_RIGHT:
                        dispatchClick(event.button.y,event.button.x);
                    break;
                }
            default:
                break;
        }
    }

    if(accion == SDL_QUIT) return QUIT;
    else return NOTHING;
};


//Deprecado el juego no usa mouse
void InputManager::dispatchClick(int y,int x){
    for(auto& r : GOManager::getInstance().resources)
        if(!r->resource->cooldown)r->sprite->isInPos(y,x);
        //std::cout<<"Click in: "<<x<<" - "<<y<<". Da: "<<item->sprite->isClicked(y,x)<<"\n";
    
};


//Player commander
void MoveUp::execute(Player* p) { p->physics->moveUp();};
void MoveDown::execute(Player* p) { p->physics->moveDown();};
void MoveLeft::execute(Player* p) { p->physics->moveLeft();};
void MoveRight::execute(Player* p) { p->physics->moveRight();};
void StopUp::execute(Player* p) { p->physics->stopUp();};
void StopDown::execute(Player* p) { p->physics->stopDown();};
void StopLeft::execute(Player* p) { p->physics->stopLeft();};
void StopRight::execute(Player* p) { p->physics->stopRight();};
void ToggleInventory::execute(Player* p) {
    //p->inventory->toConsole();
    SceneManager::getInstance().nextScene(new InventoryMenuScene());
};
void Interact::execute(Player* p) {
    for(auto& r : GOManager::getInstance().resources)
        if(!r->resource->cooldown)r->sprite->isInPos(p->sprite->position.y,p->sprite->position.x);
};

//Menu Commander definition

void MoveUpMenu::execute(MenuGeneric* m) { m->previousOption(); };
void MoveDownMenu::execute(MenuGeneric* m) {m->nextOption(); };
void MoveLeftMenu::execute(MenuGeneric* m) {};
void MoveRightMenu::execute(MenuGeneric* m) { };
void StopUpMenu::execute(MenuGeneric* m) { };
void StopDownMenu::execute(MenuGeneric* m) { };
void StopLeftMenu::execute(MenuGeneric* m) { };
void StopRightMenu::execute(MenuGeneric* m) { };
void InteractMenu::execute(MenuGeneric* m) {
    //for(auto& r : GOManager::getInstance().resources)
        //if(!r->resource->cooldown)r->sprite->isInPos(p->sprite->position.y,p->sprite->position.x);
        m->execute();
};