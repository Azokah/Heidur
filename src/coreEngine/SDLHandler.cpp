#include "SDLHandler.hpp"
#include "Texto.hpp"
#include "Timer.hpp"

SDLHandler& SDLHandler::getInstance(){
	static  SDLHandler instancia;
	return instancia;
};

SDLHandler::SDLHandler()
{
    SDL_Rect viewport = {0, 0, PANTALLA_AL, PANTALLA_AN };
    //viewport.x = 0;
    //viewport.y = 0;
    //viewport.w = PANTALLA_AN;
    //viewport.h = PANTALLA_AL;

    //Inicializacion de elementos de SDL
    if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
        globals::getError("No se pudo inicializar SDL.",SDL_INIT_ERROR);
    ventana = SDL_CreateWindow(TITULO, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, PANTALLA_AN, PANTALLA_AL, SDL_WINDOW_SHOWN);// | SDL_WINDOW_FULLSCREEN);
    render = SDL_CreateRenderer(ventana, -1, GAME_OPTIONS);
    SDL_RenderSetViewport(render,&viewport);
    //SDL_RenderSetLogicalSize(render, TILE_W*12, TILE_H*12);

    //Contador de FPS
    proximoTick = Timer::getInstance().get_ticks() + 1000;
    FPS = 0;

    //Inicializacion de componentes
    texto = new Texto();
    texto->init(TEXTO_SIZE);
    texto->setAlpha(TEXTO_ALPHA);

    delta = Timer::getInstance().get_ticks();
    
};
SDLHandler::~SDLHandler(){
    delete texto;
};

//Graphics methods

void SDLHandler::printText(std::string mensaje, int x, int y, int r, int g, int b){
    texto->ponerTexto(mensaje, x, y, r, g, b, render);
}

void SDLHandler::cleanRender() { SDL_RenderClear(render); };

//Renderizo y aumento el conteo de FPS.
void SDLHandler::draw() { 
    drawFPS();
    SDL_RenderPresent(render);
    FPS++;
};

SDL_Renderer * SDLHandler::getRender() { return render; };


// Utilities

void SDLHandler::drawFPS(){
	if(Timer::getInstance().get_ticks() >= proximoTick) {
		proximoTick = Timer::getInstance().get_ticks() + 1000;
		FPSMAX = FPS;
		FPS = 0;
	}
	char txt[25];
	sprintf(txt,"FPS: %.0f",FPSMAX);
	printText(txt,25,50,255,0,125);
};

void SDLHandler::takeScreenshot(){
    SDL_Surface *sshot = SDL_CreateRGBSurface(0, PANTALLA_AN, PANTALLA_AL, 32, 0x00ff0000, 0x0000ff00, 0x000000ff, 0xff000000);
    SDL_RenderReadPixels(render, NULL, SDL_PIXELFORMAT_ARGB8888, sshot->pixels, sshot->pitch);
    char txt[25];
    sprintf(txt,"%s%d.bmp",SCREENSHOT_PATH,Timer::getInstance().get_ticks());
    SDL_SaveBMP(sshot, txt);
    std::cout<<"Screenshot taken!"<<std::endl;
    SDL_FreeSurface(sshot);

}

float SDLHandler::getDelta(){
    float aux = Timer::getInstance().get_ticks();
    float retorno = aux - delta;
    delta = Timer::getInstance().get_ticks();
    return retorno;
};