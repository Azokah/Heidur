#include "InputManager.hpp"
#include "SDLHandler.hpp"
#include "../gameobject/Player.hpp"
#include "../gameobject/items/Item.hpp"
#include "../gameobject/components/Physics.hpp"
#include "../gameobject/components/Sprite.hpp"
#include "../gameobject/components/Inventory.hpp"

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
};
InputManager::~InputManager(){};


SDL_EventType InputManager::processInput(Player* player,std::vector<Item*>items){
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
                        accion = SDL_QUIT;
                        break;
                    case SDLK_F1:
                        SDLHandler::getInstance().takeScreenshot();
                        accion = SDL_KEYDOWN;
                        break;
                    case SDLK_w:
                        up->execute(player);
                        break;
                    case SDLK_s:
                        down->execute(player);
                        break;
                    case SDLK_d:
                        right->execute(player);
                        break;
                    case SDLK_a:
                        left->execute(player);
                        break;
                    case SDLK_i:
                        toggleInventory->execute(player);
                        break;
                    accion = SDL_KEYDOWN;
                }
                break;
            case SDL_KEYUP:
                /* Check the SDLKey values and move change the coords */
                switch( event.key.keysym.sym ){
                    case SDLK_w:
                        stopUp->execute(player);
                        break;
                    case SDLK_s:
                        stopDown->execute(player);
                        break;
                    case SDLK_d:
                        stopRight->execute(player);
                        break;
                    case SDLK_a:
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
                        dispatchClick(event.button.y,event.button.x,items);
                    break;
                }
            default:
                break;
        }
    }

    return accion;
};

void InputManager::dispatchClick(int y,int x,std::vector<Item*>items){
    for(auto& item : items)
        item->sprite->isClicked(y,x);
        //std::cout<<"Click in: "<<x<<" - "<<y<<". Da: "<<item->sprite->isClicked(y,x)<<"\n";
    
};

void MoveUp::execute(Player* p) { p->physics->moveUp();};
void MoveDown::execute(Player* p) { p->physics->moveDown();};
void MoveLeft::execute(Player* p) { p->physics->moveLeft();};
void MoveRight::execute(Player* p) { p->physics->moveRight();};
void StopUp::execute(Player* p) { p->physics->stopUp();};
void StopDown::execute(Player* p) { p->physics->stopDown();};
void StopLeft::execute(Player* p) { p->physics->stopLeft();};
void StopRight::execute(Player* p) { p->physics->stopRight();};
void ToggleInventory::execute(Player* p) { p->inventory->toConsole();};