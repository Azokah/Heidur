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
#include <vector>

class ResourceGeneric;
class Player;
class MenuGeneric;

class GOManager {
    public:
        static GOManager& getInstance();
        ~GOManager();

        void update(float,Player*);
        void draw();

        std::vector<ResourceGeneric*> resources;

        MenuGeneric * menu;

    private:
        GOManager();


};