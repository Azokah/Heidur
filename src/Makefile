CC = g++ -std=c++14 
HEADERS = Constantes.hpp coreEngine/SDLHandler.hpp coreEngine/InputManager.hpp gameobject/components/Grid.hpp coreEngine/Texto.hpp coreEngine/Timer.hpp gameobject/components/Sprite.hpp gameobject/Player.hpp gameobject/Scenario.hpp  gameobject/components/Physics.hpp coreEngine/NetworkClient.hpp coreEngine/GOManager.hpp gameobject/PlayerExternal.hpp gameobject/Monster.hpp coreEngine/Camera.hpp gameobject/components/Stats.hpp gameobject/ResourceGeneric.hpp gameobject/components/Inventory.hpp gameobject/ItemGeneric.hpp gameobject/components/Resource.hpp gameobject/components/Item.hpp gameobject/components/MenuComponent.hpp gameobject/MenuGeneric.hpp
OBJECTS = SDLHandler.o Texto.o Timer.o Player.o Sprite.o Physics.o InputManager.o Grid.o Scenario.o NetworkClient.o GOManager.o PlayerExternal.o Monster.o Camera.o Stats.o ResourceGeneric.o Inventory.o ItemGeneric.o  Resource.o Item.o MenuComponent.o MenuGeneric.o 
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

Camera.o: coreEngine/Camera.hpp coreEngine/Camera.cpp
	$(CC) -c coreEngine/Camera.cpp

NetworkClient.o: coreEngine/NetworkClient.hpp coreEngine/NetworkClient.cpp
	$(CC) -c coreEngine/NetworkClient.cpp

GOManager.o: coreEngine/GOManager.hpp coreEngine/GOManager.cpp
	$(CC) -c coreEngine/GOManager.cpp

Sprite.o: gameobject/components/Sprite.hpp gameobject/components/Sprite.cpp
	$(CC) -c gameobject/components/Sprite.cpp

Resource.o: gameobject/components/Resource.hpp gameobject/components/Resource.cpp
	$(CC) -c gameobject/components/Resource.cpp

Item.o: gameobject/components/Item.hpp gameobject/components/Item.cpp
	$(CC) -c gameobject/components/Item.cpp

Inventory.o: gameobject/components/Inventory.hpp gameobject/components/Inventory.cpp
	$(CC) -c gameobject/components/Inventory.cpp

MenuComponent.o: gameobject/components/MenuComponent.hpp gameobject/components/MenuComponent.cpp
	$(CC) -c gameobject/components/MenuComponent.cpp

Grid.o: gameobject/components/Grid.hpp gameobject/components/Grid.cpp
	$(CC) -c gameobject/components/Grid.cpp

Physics.o: gameobject/components/Physics.hpp gameobject/components/Physics.cpp
	$(CC) -c gameobject/components/Physics.cpp

Stats.o: gameobject/components/Stats.hpp gameobject/components/Stats.cpp
	$(CC) -c gameobject/components/Stats.cpp

Player.o: gameobject/Player.hpp gameobject/Player.cpp
	$(CC) -c gameobject/Player.cpp

ResourceGeneric.o: gameobject/ResourceGeneric.hpp gameobject/ResourceGeneric.cpp
	$(CC) -c gameobject/ResourceGeneric.cpp

ItemGeneric.o: gameobject/ItemGeneric.hpp gameobject/ItemGeneric.cpp
	$(CC) -c gameobject/ItemGeneric.cpp

MenuGeneric.o: gameobject/MenuGeneric.hpp gameobject/MenuGeneric.cpp
	$(CC) -c gameobject/MenuGeneric.cpp

Monster.o: gameobject/Monster.hpp gameobject/Monster.cpp
	$(CC) -c gameobject/Monster.cpp

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
	-rm -f Monster.o
	-rm -f Camera.o 
	-rm -f Stats.o 
	-rm -f ResourceGeneric.o 
	-rm -f Inventory.o 
	-rm -f ItemGeneric.o 
	-rm -f Resource.o 
	-rm -f Item.o 
	-rm -f MenuComponent.o 
	-rm -f MenuGeneric.o 