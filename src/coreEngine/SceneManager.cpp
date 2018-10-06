#include "SceneManager.hpp"
#include "MainGameScene.hpp"

SceneManager::SceneManager(){
    scenes.push_back(new MainGameScene());
};
SceneManager::~SceneManager(){};

SceneManager& SceneManager::getInstance(){
    static SceneManager instance;
    return instance;
};

void SceneManager::update(){
    for(auto& s : scenes){
        s->update();
    }
};