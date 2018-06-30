#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"
#include <SDL2/SDL_ttf.h>

class Texto
{
public:
	Texto(void);
	~Texto(void);

	void ponerTexto(std::string texto,int x, int y, int r, int g, int b, SDL_Renderer* render);
	void init(int x);
	void setAlpha(int x);
private:

	int _tam, _a;
	TTF_Font* _font1;
	SDL_Surface* _mensaje;
	SDL_Texture * _textura;
	SDL_Color colorTexto;
	SDL_Rect _rectTexto;

	
};

