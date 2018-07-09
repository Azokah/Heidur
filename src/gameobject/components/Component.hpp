/************************
*   Currently unused    *
************************/

#pragma once
#include <iostream>

class Component {
    public:
        virtual ~Component() {};
        virtual void update(float) = 0; //Override with additional parameters? Physics uses sprite for example...
};