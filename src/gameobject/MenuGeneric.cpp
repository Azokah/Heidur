#include "MenuGeneric.hpp"
#include "../coreEngine/SDLHandler.hpp"
#include "components/Sprite.hpp"
#include "components/MenuComponent.hpp"

MenuGeneric::MenuGeneric(){
    active = true;
    selectedComponent = 0;
};
MenuGeneric::~MenuGeneric(){
};

void MenuGeneric::update(float delta){
    if(active){
        bgRect.x = PANTALLA_AN/2;
        bgRect.y = PANTALLA_AL/2;
        bgRect.w = getMaxString();
        bgRect.h = TEXTO_SIZE * menus.size();
    }
};
void MenuGeneric::draw(){
    if(active){
        SDL_SetRenderDrawColor(SDLHandler::getInstance().getRender(),0,0,0,255);
        SDL_RenderFillRect(SDLHandler::getInstance().getRender(),&bgRect);
        int pos_y = 0;
        int cont = 0;
        for(auto& m : menus){
            if(cont==selectedComponent)
                SDLHandler::getInstance().printText(m->label,bgRect.x,bgRect.y+(pos_y*TEXTO_SIZE),255,0,0);
            else
                SDLHandler::getInstance().printText(m->label,bgRect.x,bgRect.y+(pos_y*TEXTO_SIZE),255,255,255);
            pos_y++;
            cont++;
        }
    }
};

int MenuGeneric::getMaxString(){
    int maxStr = menus.front()->label.size();
    for(auto& m : menus){
        if(m->label.size() > maxStr) maxStr = m->label.size();
    }
    return maxStr * TEXTO_SIZE/2;
};

bool MenuGeneric::activate(){
    active = true;
    return active;
};
bool MenuGeneric::deactivate(){
    active = false;
    return active;
};

void MenuGeneric::nextComponent(){
    selectedComponent++;
    if(selectedComponent > menus.size()) selectedComponent = menus.size();
};
void MenuGeneric::prevComponent(){
    selectedComponent--;
    if(selectedComponent < 0) selectedComponent = 0;
};