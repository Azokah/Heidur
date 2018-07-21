#include "MenuGeneric.hpp"
#include "../coreEngine/SDLHandler.hpp"
#include "components/Sprite.hpp"
#include "components/MenuComponent.hpp"

MenuGeneric::MenuGeneric(){
    menus.push_back(new MenuComponent("test"));
};
MenuGeneric::~MenuGeneric(){
};

void MenuGeneric::update(float delta){
    bgRect.x = 0;
    bgRect.y = 0;
    bgRect.w = bgRect.h = 100;
};
void MenuGeneric::draw(){
    SDL_RenderDrawRect(SDLHandler::getInstance().getRender(),&bgRect);
};