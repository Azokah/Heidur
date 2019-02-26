/********************************************************************************
*   Deprecated                                                                  *
*   Various methods are deprecated and made for another uses. Must be upgraded. *
*********************************************************************************/
/********************************************************************
*   This Class responsabilities are to manage,  create and delete   *
*   all gameobjects that are not main player and map                *
*********************************************************************/
#pragma once
#include <iostream>
#include <memory>
#include <vector>

class ResourceGeneric;
class Player;
class MenuGeneric;
class Monster;

class GOManager {
    public:
        static GOManager& getInstance();
        ~GOManager();

        void update(float,Player*);
        void draw(int,int);
        void draw();

        void poblateMonsters(); //Test only

        Monster* getClosestEnemy(Player*);

        std::vector<std::unique_ptr<ResourceGeneric>> resources;
        std::vector<std::unique_ptr<Monster>> monsters;

        MenuGeneric * menu;

    private:
        GOManager();


};