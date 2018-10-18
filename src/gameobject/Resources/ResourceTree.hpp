#pragma once
#include <iostream>
#include "ResourceGeneric.hpp"

class ResourceTree : public ResourceGeneric {
    public:
        ResourceTree(int,int);
        ~ResourceTree();

        void update(float,Player*);
};