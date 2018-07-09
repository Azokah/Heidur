#pragma once
#include <iostream>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

class Player;
class Item;

class Command {
    public:
        virtual ~Command(){};
        virtual void execute(Player*) = 0;
};

class InputManager {
    public:
        InputManager();
        ~InputManager();
        
        SDL_EventType processInput(Player*,Item*);//Should be changed to a vector of items

        void dispatchClick(int,int,Item*);

    private:
        SDL_Event event;

        Command* up;
        Command* left;
        Command* right;
        Command* down;
        Command* stopUp;
        Command* stopLeft;
        Command* stopRight;
        Command* stopDown;
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