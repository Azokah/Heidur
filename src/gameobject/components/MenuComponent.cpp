#include "MenuComponent.hpp"

MenuComponent::MenuComponent(){};
MenuComponent::MenuComponent(std::string label){
    this->label = label;
};
MenuComponent::~MenuComponent(){

};

void MenuComponent::update(float delta){

};

void MenuComponent::toConsole(){
    std::cout<<label<<std::endl;
};