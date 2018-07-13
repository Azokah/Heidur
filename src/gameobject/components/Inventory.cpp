#include "Inventory.hpp"
#include "../resources/Resource.hpp"

Inventory::Inventory(){

};
Inventory::~Inventory(){

};

void Inventory::update(float delta){

};

void Inventory::toConsole(){
    for(auto& i  : items){
        std::cout<<i->name<<"-"<<i->description<<std::endl;
    }
};