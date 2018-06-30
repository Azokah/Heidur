CC = g++ -std=c++14 
HEADERS = Constantes.hpp coreEngine/SDLHandler.hpp coreEngine/Texto.hpp coreEngine/Timer.hpp gameobject/components/Sprite.hpp gameobject/Player.hpp
OBJECTS = SDLHandler.o Texto.o Timer.o Player.o Sprite.o
LIBS = -lSDL2 -lSDL2_image -lSDL2_mixer -lSDL2_ttf -lSDL2

default: main $(OBJECTS)

all: main

main: main.cpp $(HEADERS) $(OBJECTS)
	$(CC) main.cpp -o main $(OBJECTS) $(LIBS)

SDLHandler.o: coreEngine/SDLHandler.hpp coreEngine/SDLHandler.cpp
	$(CC) -c coreEngine/SDLHandler.cpp

Texto.o: coreEngine/Texto.hpp coreEngine/Texto.cpp
	$(CC) -c coreEngine/Texto.cpp

Timer.o: coreEngine/Timer.hpp coreEngine/Timer.cpp
	$(CC) -c coreEngine/Timer.cpp

Sprite.o: gameobject/components/Sprite.hpp gameobject/components/Sprite.cpp
	$(CC) -c gameobject/components/Sprite.cpp

Player.o: gameobject/Player.hpp gameobject/Player.cpp
	$(CC) -c gameobject/Player.cpp

clean:
	-rm -f main
	-rm -f SDLHandler.o
	-rm -f Texto.o 
	-rm -f Timer.o 
	-rm -f Player.o 
	-rm -f Sprite.o 