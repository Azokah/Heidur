/************************************************************
*	This is the central SDL class that manages most of the	*
*	API functions.											*
*************************************************************/

#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
#include <SDL2/SDL_ttf.h>
#include <string>
#include "../Constantes.hpp"

class Texto;
class Timer;

class SDLHandler {

	public:
		static SDLHandler& getInstance();
		~SDLHandler();

		//Input
		SDL_EventType input();

		//Graficado
		void cleanRender();
		void draw();
		
		void printText(std::string mensaje, int x, int y, int r, int g, int b);
		SDL_Renderer * getRender();
		
		
		void takeScreenshot();


		float getDelta();
	private:
		SDLHandler();
		void drawFPS();

		float FPS,FPSMAX,proximoTick;
		float delta;
		
		SDL_Window * ventana;
		SDL_Renderer * render;

        SDL_Event event;

		Texto * texto;
};

