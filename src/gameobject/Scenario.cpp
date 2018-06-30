#include "Scenario.hpp"
#include "components/Sprite.hpp"
#include "components/Grid.hpp"


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