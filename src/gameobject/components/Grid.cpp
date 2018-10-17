#include "Grid.hpp"

Grid::Grid(){
    resetGrid();
};
Grid::~Grid(){

};

void Grid::resetGrid(){
    for(int i = 0; i < GRID_MAX_H; i++)
        for(int j = 0; j < GRID_MAX_W; j++){
            grid[i][j] = 1;
            colisiones[i][j] = 0;
        }

    grid[3][3] = 2;
};


void Grid::update(float delta){

};

int Grid::getValueAt(int y,int x){
    return grid[y][x];
};

bool Grid::isWalkable(int y,int x){
    if(colisiones[y][x] == 0) return true;
    else return false;
}
void Grid::setValue(int y,int x,int n){
    grid[y][x] = n;
};

void Grid::setColisionAt(int y,int x,int n){
    colisiones[y][x] = n;
};