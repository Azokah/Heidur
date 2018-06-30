CC = g++ -std=c++14 
HEADERS = NetworkServer.hpp
OBJECTS = NetworkServer.o
LIBS = -lSDL2 -lSDL2_image -lSDL2_mixer -lSDL2_ttf -lSDL2_net

default: server $(OBJECTS)

all: server

server: server.cpp $(HEADERS) $(OBJECTS)
	$(CC) server.cpp -o server $(OBJECTS) $(LIBS)

NetworkServer.o: NetworkServer.hpp NetworkServer.cpp
	$(CC) -c NetworkServer.cpp

clean:
	-rm -f server
	-rm -f NetworkServer.o