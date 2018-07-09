/********************************************
*   Unused                                  *
*   Made for a possible multiplayer feature *
********************************************/
#include "PlayerExternal.hpp"

PlayerExternal::PlayerExternal(int ID):Player(){
    id = ID;
};
PlayerExternal::~PlayerExternal(){};

int PlayerExternal::getID(){return id;};