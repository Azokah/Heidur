#include "Scenario.hpp"
#include "components/Sprite.hpp"
#include "components/Grid.hpp"
#include "../coreEngine/GOManager.hpp"
#include "Resources/ResourceGeneric.hpp"

Scenario& Scenario::getInstance(){
    static Scenario instance;
    return instance;
}

Scenario::Scenario(){
    sprite = new Sprite();
    grid = new Grid();
    load(GRID_PATH);
	loadColisiones(GRID_COLISIONS_PATH);
	loadObjects(GRID_OBJECTS_PATH);
};
Scenario::~Scenario(){
    delete sprite;
    delete grid;
};


void Scenario::update(float delta){
    sprite->update(delta);

};

void Scenario::draw(){
    for(int i = 0; i < GRID_MAX_H; i++)
        for(int j = 0; j < GRID_MAX_W; j++)
            switch(grid->getValueAt(i,j)){
                default:
                    sprite->setDest(grid->getValueAt(i,j));
                    sprite->drawAt(i*TILE_H,j*TILE_W);
                    break;
            }
};

bool Scenario::testColision(int y, int x){
    int i = (y+TILE_H/2)/TILE_H, j =  (x+TILE_W/3)/TILE_W;
    int i2 = (y+TILE_H)/TILE_H, j2 = (x+(TILE_W/3)+(TILE_W/3))/TILE_W;
    if(!grid->isWalkable(i,j) || !grid->isWalkable(i2,j) || !grid->isWalkable(i,j2)|| !grid->isWalkable(i2,j2)){
        return false;
    }else return true;
}


void Scenario::load(std::string path){
	std::cout<<"Cargando Mapa"<<std::endl;
	std::ifstream file(path);
	int fila, columna;
	fila = 0;
	columna = 0;
	std::string linea;

	while (std::getline(file, linea,',')){
		std::istringstream iss(linea);
		int n;

		while (iss >> n){
			grid->setValue(fila,columna,n);
			columna++;

			if(columna >= GRID_MAX_W){
				columna = 0;
				fila += 1;
			}
		}
	}

	file.close();
};


void Scenario::loadColisiones(std::string path){
	std::cout<<"Cargando colisiones"<<std::endl;
	std::ifstream file(path);
	int fila, columna;
	fila = 0;
	columna = 0;
	std::string linea;

	while (std::getline(file, linea,',')){
		std::istringstream iss(linea);
		int n;

		while (iss >> n){
			grid->setColisionAt(fila,columna,n);
			columna++;

			if(columna >= GRID_MAX_W){
				columna = 0;
				fila += 1;
			}
		}
	}

	file.close();
};

void Scenario::loadObjects(std::string path){
	std::cout<<"Cargando objetos"<<std::endl;
	std::ifstream file(path);
	int fila, columna;
	fila = 0;
	columna = 0;
	std::string linea;

	while (std::getline(file, linea,',')){
		std::istringstream iss(linea);
		int n;

		while (iss >> n){
			//grid->setColisionAt(fila,columna,n);
			if(n != 0)
				GOManager::getInstance().resources.push_back(new ResourceGeneric(n,fila,columna));//Instanciamos objetos
			columna++;

			if(columna >= GRID_MAX_W){
				columna = 0;
				fila += 1;
			}
		}
	}

	file.close();
};