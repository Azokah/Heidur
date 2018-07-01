CC = g++ -std=c++14 
HEADERS = Constantes.hpp coreEngine/SDLHandler.hpp coreEngine/InputManager.hpp gameobject/components/Grid.hpp coreEngine/Texto.hpp coreEngine/Timer.hpp gameobject/components/Sprite.hpp gameobject/Player.hpp gameobject/Scenario.hpp  gameobject/components/Physics.hpp coreEngine/NetworkClient.hpp coreEngine/GOManager.hpp gameobject/PlayerExternal.hpp
OBJECTS = SDLHandler.o Texto.o Timer.o Player.o Sprite.o Physics.o InputManager.o Grid.o Scenario.o NetworkClient.o GOManager.o PlayerExternal.o 
LIBS = -lSDL2 -lSDL2_image -lSDL2_mixer -lSDL2_ttf -lSDL2 -lSDL2_net

default: main $(OBJECTS)

all: main

main: main.cpp $(HEADERS) $(OBJECTS)
	$(CC) main.cpp -o main $(OBJECTS) $(LIBS)

SDLHandler.o: coreEngine/SDLHandler.hpp coreEngine/SDLHandler.cpp
	$(CC) -c coreEngine/SDLHandler.cpp

Texto.o: coreEngine/Texto.hpp coreEngine/Texto.cpp
	$(CC) -c coreEngine/Texto.cpp

InputManager.o: coreEngine/InputManager.hpp coreEngine/InputManager.cpp
	$(CC) -c coreEngine/InputManager.cpp

Timer.o: coreEngine/Timer.hpp coreEngine/Timer.cpp
	$(CC) -c coreEngine/Timer.cpp

NetworkClient.o: coreEngine/NetworkClient.hpp coreEngine/NetworkClient.cpp
	$(CC) -c coreEngine/NetworkClient.cpp

GOManager.o: coreEngine/GOManager.hpp coreEngine/GOManager.cpp
	$(CC) -c coreEngine/GOManager.cpp

Sprite.o: gameobject/components/Sprite.hpp gameobject/components/Sprite.cpp
	$(CC) -c gameobject/components/Sprite.cpp

Grid.o: gameobject/components/Grid.hpp gameobject/components/Grid.cpp
	$(CC) -c gameobject/components/Grid.cpp

Physics.o: gameobject/components/Physics.hpp gameobject/components/Physics.cpp
	$(CC) -c gameobject/components/Physics.cpp

Player.o: gameobject/Player.hpp gameobject/Player.cpp
	$(CC) -c gameobject/Player.cpp

Scenario.o: gameobject/Scenario.hpp gameobject/Scenario.cpp
	$(CC) -c gameobject/Scenario.cpp

PlayerExternal.o: gameobject/PlayerExternal.hpp gameobject/PlayerExternal.cpp
	$(CC) -c gameobject/PlayerExternal.cpp


clean:
	-rm -f main
	-rm -f SDLHandler.o
	-rm -f Texto.o 
	-rm -f Timer.o 
	-rm -f Player.o 
	-rm -f Sprite.o 
	-rm -f Physics.o 
	-rm -f InputManager.o
	-rm -f Scenario.o
	-rm -f Grid.o
	-rm -f NetworkClient.o 
	-rm -f GOManager.o 
	-rm -f PlayerExternal.o 