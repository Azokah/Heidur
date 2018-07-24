#include "MenuGeneric.hpp"
#include "../coreEngine/SDLHandler.hpp"
#include "components/Sprite.hpp"
#include "components/MenuComponent.hpp"

MenuGeneric::MenuGeneric(){
    menus.push_back(new MenuComponent("test"));
    menus.push_back(new MenuComponent("Inventario"));
};
MenuGeneric::~MenuGeneric(){
};

void MenuGeneric::update(float delta){
    bgRect.x = PANTALLA_AN/2;
    bgRect.y = PANTALLA_AL/2;
    bgRect.w = getMaxString();
    bgRect.h = TEXTO_SIZE * menus.size();
};
void MenuGeneric::draw(){
    SDL_SetRenderDrawColor(SDLHandler::getInstance().getRender(),0,0,0,255);
    SDL_RenderFillRect(SDLHandler::getInstance().getRender(),&bgRect);
    int pos_y = 0;
    for(auto& m : menus){
        SDLHandler::getInstance().printText(m->label,bgRect.x,bgRect.y+(pos_y*TEXTO_SIZE),255,255,255);
        pos_y++;
    }
};

int MenuGeneric::getMaxString(){
    int maxStr = menus.front()->label.size();
    for(auto& m : menus){
        if(m->label.size() > maxStr) maxStr = m->label.size();
    }
    return maxStr * TEXTO_SIZE/2;
};