#pragma once
#include <iostream>
#include <string>
#include <SDL2/SDL.h>
#include "../Constantes.hpp"
#include "Player.hpp"

class PlayerExternal : public Player {
    public:
        PlayerExternal(int);
        ~PlayerExternal();

        int getID();

    private:
        int id;
};
