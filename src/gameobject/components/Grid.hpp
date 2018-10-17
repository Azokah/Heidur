#pragma once
#include <iostream>
#include "../../Constantes.hpp"

class Grid {
    public:
        Grid();
        ~Grid();

        void resetGrid();
        void update(float);

        int getValueAt(int,int);
        void setValue(int,int,int);

        
        void setColisionAt(int,int,int);
        bool isWalkable(int,int);
    private:
        int grid[GRID_MAX_H][GRID_MAX_W];
        int colisiones[GRID_MAX_H][GRID_MAX_W];

        
};