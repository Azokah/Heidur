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
    private:
        int grid[GRID_MAX_H][GRID_MAX_W];

        
};