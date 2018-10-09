#include "SceneManager.hpp"
#include "Scenes/MainMenuScene.hpp"
#include "Scenes/MainGameScene.hpp"
#include <SDL2/SDL.h>

SceneManager::SceneManager(){
    scenes.push_back(new MainMenuScene());
    state = INICIANDO;
};
SceneManager::~SceneManager(){};

SceneManager& SceneManager::getInstance(){
    static SceneManager instance;
    return instance;
};

void SceneManager::exitGame(){
    SDL_Quit();
    exit(0);
};

void SceneManager::update(){
    EVENT_ENUM_TYPE e;
    while(e != QUIT && scenes.size() != 0){
        e = scenes.front()->update();
    }
    
};

void SceneManager::nextScene(Scene* s){
    
    scenes.push_front(s);
    
};
void SceneManager::prevScene(){
    Scene* front = scenes.at(0);
    scenes.pop_front();//Dealocate first memory leak
    delete(front);  //Preventing memory leak 
};