#include "Sprite.hpp"
#include "../../coreEngine/SDLHandler.hpp"
#include "../../coreEngine/Camera.hpp"

Sprite::Sprite(){
    wasClicked = false;
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
void Sprite::setDest(int pos){
    dest.y = 0*TILE_H;
    dest.x = pos*TILE_W;
    dest.w = 1*TILE_W;
    dest.h = 1*TILE_H;
}
void Sprite::update(float delta){
    
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
    //tobedone -- should work
    /*int i = (sprite->position.y+TILE_H/2), j =  (sprite->position.x+TILE_W/3);
    int i2 = (sprite->position.y+TILE_H), j2 = (sprite->position.x+(TILE_W/3)+(TILE_W/3));

    int y = (position.y+TILE_H/2), x =  (position.x+TILE_W/3);
    int y2 = (position.y+TILE_H), x2 = (position.x+(TILE_W/3)+(TILE_W/3));

    if(((j > x2 ) || (j2 < x)) && ((i > y2) || (i2 < y))){
        return false;
    }else return true;*/
}

bool Sprite::isClicked(int y, int x){
    x += Camera::getInstance().bounds.x;
    y += Camera::getInstance().bounds.y;
    if( x >= position.x && x <= position.x+position.w)
        if( y >= position.y && y <= position.y+position.h)
            wasClicked = true; 
    return wasClicked;
};

void Sprite::resetClickedStatus(){
    wasClicked = false;
};


int Sprite::getDistanceFromSprite(Sprite* s){
    int x = position.x - s->position.x;
    int y = position.y - s->position.y;
    if(x < 0) x *= -1;
    if(y < 0) y *= -1;

    return x+y;
};