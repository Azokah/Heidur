/********************************************************************
*   This Class responsabilities are to manage,  create and delete   *
*   all gameobjects that are not main player and map                *
*********************************************************************/
#pragma once
#include <iostream>
#include <vector>

class PlayerExternal;

class GOManager {
    public:
        static GOManager& getInstance();
        ~GOManager();

        void update(float);
        void draw();

        void playerFromConnection(int);
        void updatePlayer(int,int,int);

    private:
        GOManager();

        std::vector<PlayerExternal*> players;

};