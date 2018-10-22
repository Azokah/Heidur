#include "JsonParser.hpp"
#include "GameHandler.hpp"
#include "../Juego/Mapa.hpp"
#include "../Juego/Npc.hpp"
#include "../Juego/Objeto.hpp"
#include "Dialogo.hpp"

JsonParser::JsonParser(){

};
JsonParser::~JsonParser(){

};


JsonParser& JsonParser::getInstance(){
    static JsonParser instance;
    return instance;
};


Mapa* JsonParser::parseMap(){
    std::ifstream i("Data/Maps/mapa1.json");
    json j;
    i >> j;

    std::string path = j["csv"];
    
    Mapa* mapa = new Mapa(path);
    return mapa;
};

std::vector<Npc*> JsonParser::parseNPC(){
    std::ifstream i("Data/Maps/mapa1.json");
    json j;
    i >> j;

    std::string path = j["npc"];
    std::ifstream w(path);
    json n; 
    w >> n;
    
    std::vector<Npc*> npcs;
    int x, y, tipo;
    std::string d;
    for(auto& e : n){
        for(auto& u : e){
            x = u["x"];
            y = u["y"];
            tipo = u["tipo"];
            d = u["dialogo"];
            npcs.push_back(new Npc(x,y,(npcTipo)tipo,d));
        }
    }
    
    return npcs;
};

std::vector<Objeto*> JsonParser::parseObject(){

    std::ifstream i("Data/Maps/mapa1.json");
    json j;
    i >> j;

    std::string path = j["objetos"];
    std::ifstream w(path);
    json n; 
    w >> n;
    
    std::vector<Objeto*> objetos;
    int x, y, tipo,walk;
    for(auto& e : n){
        for(auto& u : e){
            x = u["x"];
            y = u["y"];
            tipo = u["tipo"];
            walk = u["walkable"];
            objetos.push_back(new Objeto(x,y,tipo,walk));
        }
    }
    
    return objetos;
};

void JsonParser::createObjectsJSON(){
    json j;

    std::ifstream file(MAPA_OBJECTS_PATH);
	int fila, columna;
	fila = 0;
	columna = 0;
	std::string linea;
    int walk = 0;
    
	while (std::getline(file, linea,',')){
		std::istringstream iss(linea);
		int n;

		while (iss >> n){
			if(n >= OBJ_CODE_START_AT){
                if(n == OBJ_CODE_PUERTA_VERT_ABIERTA || //Esto esta mal.
                    n == OBJ_CODE_PUERTA_HOR_ABIERTA ||
                    n == OBJ_CODE_PINO_TOP){
                        walk = 1;
                    }else walk = 0;
                j["objetos"] += {{"x",columna},
                                {"y",fila},
                                {"tipo",n},
                                {"script","0"},
                                {"walkable",walk}};
            }
			columna++;

			if(columna >= MAPA_W){
				columna = 0;
				fila += 1;
			}
		}
	}

	file.close();

    std::ofstream o("Assets/Resources/Mapa1_Objetos.json");
    o << std::setw(4) << j << std::endl;
    std::cout<<"Exito"<<std::endl;
};

void JsonParser::createNpcJSON(){
    json j;

    std::ifstream file(MAPA_NPC_PATH);
	int fila, columna;
	fila = 0;
	columna = 0;
	std::string linea;

    
	while (std::getline(file, linea,',')){
		std::istringstream iss(linea);
		int n;
        std::string dialogo;
		while (iss >> n){
			if(n >= 22 && n < 26){
                dialogo = "guardias";
                if(n == 24) dialogo = "cocinera";
                if(n == 23) dialogo = "rey";
                if(n == 25) dialogo = "elfas";
                j["npcs"] += {{"x",columna},
                                {"y",fila},
                                {"tipo",n-21},
                                {"script","0"},
                                {"dialogo",dialogo}};
            }
			columna++;

			if(columna >= MAPA_W){
				columna = 0;
				fila += 1;
			}
		}
	}

	file.close();

    std::ofstream o("Assets/Resources/Mapa1_Npc.json");
    o << std::setw(4) << j << std::endl;
    std::cout<<"Exito"<<std::endl;
};


std::string JsonParser::loadScript(std::string path){
    std::ifstream i("Data/Scripts/dialogo_test.json");
    json j;
    i >> j;

    std::string retorno = j[path]["texto_inicial"];

    return retorno;
};

Dialogo* JsonParser::loadDialogo(std::string path){
    std::ifstream i(DIALOGOS_PATH);
    json j;
    i >> j;

    Dialogo* d = new Dialogo();
    
    std::string texto;
    for(auto& t : j[path]["texto"]){
        texto = t;
        d->textos.push_back(texto);
    }

    return d;
};