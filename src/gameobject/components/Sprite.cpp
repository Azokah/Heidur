#include "Sprite.hpp"
#include "../../coreEngine/SDLHandler.hpp"

Sprite::Sprite(){
    loadTexture(SDLHandler::getInstance().getRender(),SPRITE_PATH);
    position.x = 0+TILE_W;
    position.y = 0+TILE_H;
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
    SDL_RenderCopy(SDLHandler::getInstance().getRender(),texture,&dest,&position);
};

void Sprite::drawAt(int y, int x){
    position.x = x;
    position.y = y;
    SDL_RenderCopy(SDLHandler::getInstance().getRender(),texture,&dest,&position);
};

void Sprite::setDest(int y, int x, int w, int h){
    dest.y = y*TILE_H;
    dest.x = x*TILE_W;
    dest.w = w*TILE_W;
    dest.h = h*TILE_H;
}
void Sprite::update(){
    
};