#include "Inventory.hpp"
#include "../items/Item.hpp"

Inventory::Inventory(){

};
Inventory::~Inventory(){

};

void Inventory::update(float delta){

};

void Inventory::toConsole(){
    for(auto& i  : items){
        std::cout<<i->type<<std::endl;
    }
};