#include "ResourceFactory.hpp"
#include "../gameobject/Resources/ResourceGeneric.hpp"
#include "../gameobject/Resources/ResourceTree.hpp"


ResourceFactory& ResourceFactory::getInstance(){
    static ResourceFactory instance;
    return instance;
};
ResourceFactory::ResourceFactory(){
    numObjetos = 0;
};
ResourceFactory::~ResourceFactory(){};

std::unique_ptr<ResourceGeneric> ResourceFactory::makeTree(int x, int y){
    std::cout<<"Instanciamos objeto: "<<numObjetos<<std::endl;
    numObjetos++;
    return std::unique_ptr<ResourceGeneric>(new ResourceTree(x,y));
};

std::unique_ptr<ResourceGeneric> ResourceFactory::makeResource(int n ,int x,int y){
    std::cout<<"Instanciamos objeto: "<<numObjetos<<std::endl;
    numObjetos++;
    return std::unique_ptr<ResourceGeneric>(new ResourceGeneric(n,x,y));
};