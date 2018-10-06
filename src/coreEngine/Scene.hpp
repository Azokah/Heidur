#include <iostream>
#include "../Constantes.hpp"

using namespace globals;

class Scene {
    public:
        virtual ~Scene(){};

        virtual EVENT_ENUM_TYPE update() = 0;
};