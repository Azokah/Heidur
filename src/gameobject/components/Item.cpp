#include "Item.hpp"


Item::Item(ITEM_TYPE TYPE){
    type = TYPE;

    switch(type){
        case STICK:
            name = "Stick";
            description = "Used to craft things.";
            break;
        case STONE:
            name = "Stone";
            description = "Used to craft things.";
            break;
        default:
            name = "Unknown";
            description = "Who knows?";
            break;
    }
    

    
};
Item::~Item() {};

void Item::update(float delta){
};

