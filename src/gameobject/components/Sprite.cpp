#include "Sprite.hpp"
#include "../../coreEngine/SDLHandler.hpp"
#include "../../coreEngine/Camera.hpp"

Sprite::Sprite(){
    loadTexture(SDLHandler::getInstance().getRender(),SPRITE_PATH);
    position.x = 5*TILE_W;
    position.y = 5*TILE_H;
    position.w = dest.w = TILE_W;
    position.h = dest.h = TILE_H;
    dest.y = 0;
    dest.x = 0;
};
Sprite::~Sprite(){};
void Sprite::loadTexture(SDL_Renderer* render,std::string path){
    texture = IMG_LoadTexture(render,path.c_str());
    if(texture == NULL){
        globals::getError("No se pudo cargar SpriteSheet",ERROR_SPRITESHEET);
    }
}

void Sprite::draw(){
    if(checkInBounds()){
        SDL_Rect posCam = Camera::getInstance().bounds;
        position.x -= posCam.x;
        position.y -= posCam.y;
        SDL_RenderCopy(SDLHandler::getInstance().getRender(),texture,&dest,&position);
        position.x += posCam.x;
        position.y += posCam.y;
    }
};

void Sprite::drawAt(int y, int x){
    position.x = x;
    position.y = y;
    if(checkInBounds()){
        SDL_Rect posCam = Camera::getInstance().bounds;
        position.x -= posCam.x;
        position.y -= posCam.y;
        SDL_RenderCopy(SDLHandler::getInstance().getRender(),texture,&dest,&position);
        position.x += posCam.x;
        position.y += posCam.y;
    }
};

void Sprite::setDest(int y, int x, int w, int h){
    dest.y = y*TILE_H;
    dest.x = x*TILE_W;
    dest.w = w*TILE_W;
    dest.h = h*TILE_H;
}
void Sprite::update(){
    
};

//Method in charge of checking if sprite is inside camera bounds
bool Sprite::checkInBounds(){
    SDL_Rect posCam = Camera::getInstance().bounds;
    if(position.x >= posCam.x - TILE_W && position.x <= posCam.x+PANTALLA_AN)
        if(position.y >= posCam.y - TILE_H && position.y <= posCam.y+PANTALLA_AL)
            return true;
    return false;
};

bool Sprite::testColision(Sprite * sprite){
    //tobedone
}