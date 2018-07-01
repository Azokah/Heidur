#include "Scenario.hpp"
#include "components/Sprite.hpp"
#include "components/Grid.hpp"

Scenario& Scenario::getInstance(){
    static Scenario instance;
    return instance;
}

Scenario::Scenario(){
    sprite = new Sprite();
    grid = new Grid();
};
Scenario::~Scenario(){
    delete sprite;
    delete grid;
};


void Scenario::update(float delta){
    sprite->update();

};

void Scenario::draw(){
    for(int i = 0; i < GRID_MAX_H; i++)
        for(int j = 0; j < GRID_MAX_W; j++)
            switch(grid->getValueAt(i,j)){
                default:
                    sprite->setDest(0,grid->getValueAt(i,j),1,1);
                    sprite->drawAt(i*TILE_H,j*TILE_W);
                    break;
            }
};

bool Scenario::testColision(int y, int x){
    int i = y/TILE_H, j =  x/TILE_W;
    int i2 = (y+TILE_H)/TILE_H, j2 = (x+TILE_W)/TILE_W;
    if(grid->getValueAt(i,j) != 1 || grid->getValueAt(i2,j) != 1 || grid->getValueAt(i,j2) != 1 || grid->getValueAt(i2,j2) != 1){
        return false;
    }else return true;
}