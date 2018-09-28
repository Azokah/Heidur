#include "Stats.hpp"

Stats::Stats(){
    actualHealth = health = STARTING_HEALTH;
    actualEnergy = energy = STARTING_ENERGY;
    actualHunger = hunger = STARTING_HUNGER;
    actualThirst = thirst = STARTING_THIRST;
    strength = STARTING_STRENGTH;
    dexterity = STARTING_DEXTERITY;
    wisdom = STARTING_WISDOM;
};
Stats::~Stats(){};

void Stats::update(float delta){
    
};


