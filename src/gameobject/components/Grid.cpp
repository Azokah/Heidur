#include "Grid.hpp"

Grid::Grid(){
    resetGrid();
};
Grid::~Grid(){

};

void Grid::resetGrid(){
    for(int i = 0; i < GRID_MAX_H; i++)
        for(int j = 0; j < GRID_MAX_W; j++)
            grid[i][j] = 1;
};


void Grid::update(float delta){

};

int Grid::getValueAt(int y,int x){
    return grid[y][x];
};