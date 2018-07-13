#include "Inventory.hpp"
#include "Item.hpp"
#include "../ItemGeneric.hpp"


Inventory::Inventory(){

};
Inventory::~Inventory(){

};

void Inventory::update(float delta){

};

void Inventory::toConsole(){
    for(auto& i  : items){
        std::cout<<i->item->name<<"-"<<i->item->description<<std::endl;
    }
};