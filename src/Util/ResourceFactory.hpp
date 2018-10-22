#pragma once
#include <iostream>
#include <memory>
#include <vector>

class ResourceTree;
class ResourceGeneric;


class ResourceFactory {
    public:
        static ResourceFactory& getInstance();
        ~ResourceFactory();
        
        std::unique_ptr<ResourceGeneric> makeTree(int,int);
        std::unique_ptr<ResourceGeneric> makeResource(int,int,int);

        //std::vector<std::unique_ptr<ResourceGeneric>> resources;

    private:
        ResourceFactory();

        int numObjetos;

};