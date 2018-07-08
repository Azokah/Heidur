#pragma once
#include <iostream>
#include <fstream>
#include <vector>
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <sstream>
#include <string>
#include "../Patrones/nlohmann/json.hpp"


class GameHandler;
class Mapa;
class Npc;
class Objeto;
class Dialogo;

// for convenience
using json = nlohmann::json;

class JsonParser {
    public:
        static JsonParser& getInstance();
        ~JsonParser();

        Mapa* parseMap();
        std::vector<Npc*> parseNPC();
        std::vector<Objeto*> parseObject();

        void createObjectsJSON();
        void createNpcJSON();

        std::string loadScript(std::string);
        Dialogo* loadDialogo(std::string);

    private:
        JsonParser();

        json j;
};