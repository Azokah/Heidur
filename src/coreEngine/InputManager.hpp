#pragma once
#include <iostream>
#include <vector>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

using namespace globals;

class Player;
class ResourceGeneric;

class Command {
    public:
        virtual ~Command(){};
        virtual void execute(Player*) = 0;
};

class InputManager {
    public:
        static InputManager& getInstance();
        
        ~InputManager();
        
        EVENT_ENUM_TYPE processInput(Player*);

        void dispatchClick(int,int); //Deprecado, el juego no usa mouse

    private:
        InputManager();
        SDL_Event event;

        Command* up;
        Command* left;
        Command* right;
        Command* down;
        Command* stopUp;
        Command* stopLeft;
        Command* stopRight;
        Command* stopDown;
        Command* interact;
        Command* toggleInventory;

};


class MoveUp : public Command {
    public:
        virtual void execute(Player*);
};

class MoveDown : public Command {
    public:
        virtual void execute(Player*);
};

class MoveLeft : public Command {
    public:
       virtual void execute(Player*);
};

class MoveRight : public Command {
    public:
      virtual void execute(Player*);
};


class StopUp : public Command {
    public:
     virtual void execute(Player*);
};

class StopDown : public Command {
    public:
       virtual void execute(Player*);
};

class StopLeft : public Command {
    public:
       virtual void execute(Player*);
};

class StopRight : public Command {
    public:
        virtual void execute(Player*);
};
class ToggleInventory : public Command {
    public:
        virtual void execute(Player*);
};
class Interact : public Command {
    public:
        virtual void execute(Player*);
};