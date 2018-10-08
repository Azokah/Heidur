/*
*   This file contains the declaration of the commander pattern used for input.
*   It is separated in a commander for player commands and a commander for menu/gui commands.
*   Also it contains the processInput() method of the InputManager class that 
*   makes the relation between key press events and their respective command
*   At some point in time it were capable of dispatch clicks events too, but now it is
*   a deprecated feature, because this game doesnt implement mouse actions.
*/


#pragma once
#include <iostream>
#include <vector>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"

using namespace globals;

class Player;
class MenuGeneric;
class ResourceGeneric;

//Commander for player input
class Command {
    public:
        virtual ~Command(){};
        virtual void execute(Player*) = 0;
};
//Commander for gui/menu input
class CommandMenu {
    public:
        virtual ~CommandMenu(){};
        virtual void execute(MenuGeneric*) = 0;
};

class InputManager {
    public:
        static InputManager& getInstance();
        
        ~InputManager();

        EVENT_ENUM_TYPE processInput(MenuGeneric*);//For scenes without player
        EVENT_ENUM_TYPE processInput(Player*);

        void dispatchClick(int,int); //Deprecado, el juego no usa mouse

    private:
        InputManager();
        SDL_Event event;


        //Player Scene Commands
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


        //Menu Scene Commands
        CommandMenu* upMenu;
        CommandMenu* leftMenu;
        CommandMenu* rightMenu;
        CommandMenu* downMenu;
        CommandMenu* stopUpMenu;
        CommandMenu* stopLeftMenu;
        CommandMenu* stopRightMenu;
        CommandMenu* stopDownMenu;
        CommandMenu* interactMenu;

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


//Commands for menu/gui definitions
class MoveUpMenu : public CommandMenu {
    public:
        virtual void execute(MenuGeneric*);
};

class MoveDownMenu : public CommandMenu {
    public:
        virtual void execute(MenuGeneric*);
};

class MoveLeftMenu : public CommandMenu {
    public:
       virtual void execute(MenuGeneric*);
};

class MoveRightMenu : public CommandMenu {
    public:
      virtual void execute(MenuGeneric*);
};


class StopUpMenu : public CommandMenu {
    public:
     virtual void execute(MenuGeneric*);
};

class StopDownMenu : public CommandMenu {
    public:
       virtual void execute(MenuGeneric*);
};

class StopLeftMenu : public CommandMenu {
    public:
       virtual void execute(MenuGeneric*);
};

class StopRightMenu : public CommandMenu {
    public:
        virtual void execute(MenuGeneric*);
};
class InteractMenu : public CommandMenu {
    public:
        virtual void execute(MenuGeneric*);
};