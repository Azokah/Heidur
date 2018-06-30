#pragma once

//General
//Constantes de Juego
#define VERSION 0.0.1
#define TILE_W 64
#define TILE_H 64

//SDLWrapper
#define TITULO "MR.IO - EARLY ALPHA"
#define PANTALLA_AN 1280
#define PANTALLA_AL 1024
#define GAME_OPTIONS SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC
#define GAME_OPTIONS_NOVSYNC SDL_RENDERER_ACCELERATED
#define SCREENSHOT_PATH "../screenshots/develop/"

//Musica
#define AUDIO_HZ 44100
#define AUDIO_CHANNELS 2
#define AUDIO_CHUNK_SIZE 1024
#define MUSICA_PATH "../resources/Musica/Castillo_Tuto.ogg"

//Graficos
#define SPRITE_PATH "../resources/Sprites/Sprites.png"

//Texto
#define TEXTO_SIZE 18
#define FUENTE "../resources/Fonts/fuente.ttf"
#define TEXTO_ALPHA 1

//Camara
#define CAMARA_W PANTALLA_AN
#define CAMARA_H PANTALLA_AL
#define CAMARA_SPEED 2
#define CAMARA_BORDE TILE_W

//GAMEPLAY
#define PLAYERS_SPEED_BASE 0.64


//GRID
#define GRID_MAX_H 20
#define GRID_MAX_W 20
//ERRORES
#define SDL_INIT_ERROR -1
#define ERROR_SPRITESHEET -2
#define MIXER_ERROR -3
#define MUSIC_ERROR -4
#define FONT_ERROR -5
#define NETWORK_ERROR -6


namespace globals {
    static void getError(std::string errorString, int error ){
        std::cout<<errorString<<std::endl;
        exit(error);
    }

    static void windowToWorld(int* x, int* y){
        (*x) = ((*x)/TILE_W)*TILE_W;
        (*y) = ((*y)/TILE_H)*TILE_H;
    }
    static int lastID = 1000;

        static int getLastID(){ return lastID;};
        static int getNextID(){
                lastID++;  
                return lastID;
        }

    enum game_estado{
            INICIANDO,
            CORRIENDO,
            TERMINADO
    };


    struct vector2f{
        float x;
        float y;
    };

    struct vector2i{
        int x;
        int y;
    };

}
