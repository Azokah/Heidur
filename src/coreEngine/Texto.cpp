#include "Texto.hpp"


Texto::Texto(void)
{

	_font1 = NULL;
	_mensaje = NULL;
	colorTexto.r = 0;
	colorTexto.g = 0;
	colorTexto.b = 0;
	_a = 255;
}


Texto::~Texto(void)
{
	TTF_CloseFont(_font1);
	TTF_Quit();
}

void Texto::setAlpha(int x)
{
	_a = x;
}

void Texto::ponerTexto(std::string texto,int x, int y, int r, int g, int b, SDL_Renderer* render)
{


	const char * Texto = texto.c_str();
	colorTexto.r = r;
	colorTexto.g = g;
	colorTexto.b = b;
	_rectTexto.x = x;
	_rectTexto.y = y;
	_mensaje = TTF_RenderText_Solid(_font1, Texto, colorTexto);
	_rectTexto.w = _mensaje->w;
	_rectTexto.h = _mensaje->h;
	_textura = SDL_CreateTextureFromSurface(render,_mensaje);
	SDL_RenderCopy(render,_textura,NULL,&_rectTexto);
	SDL_FreeSurface(_mensaje);
	SDL_DestroyTexture(_textura);
}

void Texto::init(int x)
{
	_tam = x;
	TTF_Init();
	_font1 = TTF_OpenFont(FUENTE,_tam);
	if(_font1 == NULL)
	{
		globals::getError("No se pudo cargar la fuente 1",FONT_ERROR);
	}
}

