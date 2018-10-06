#include <iostream>
#include <vector>
#include "Constantes.hpp"
#include "coreEngine/SceneManager.hpp"


using namespace std;

int main(int argc, char * argv[]){
    cout << "Starting game...." << endl;
    
    SceneManager * sceneManager = &SceneManager::getInstance();
    sceneManager->update();

    return 0;
};