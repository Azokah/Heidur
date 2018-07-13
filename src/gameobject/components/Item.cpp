#include "Item.hpp"


Item::Item(ITEM_TYPE TYPE){
    type = TYPE;

    switch(type){
        case STICK:
            name = "Stick";
            description = "Used to craft things.";
            break;
        case STONE:
            name = "Arrow";
            description = "Used to shoot with a bow.";
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

