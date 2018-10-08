#include "SceneManager.hpp"
#include "MainMenuScene.hpp"
#include "MainGameScene.hpp"

SceneManager::SceneManager(){
    scenes.push_back(new MainMenuScene());
};
SceneManager::~SceneManager(){};

SceneManager& SceneManager::getInstance(){
    static SceneManager instance;
    return instance;
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
    scenes.pop_front();//Dealocate first memory leak
};