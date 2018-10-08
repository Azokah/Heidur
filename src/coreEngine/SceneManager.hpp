/*
*   This class controls the flow of the scenes of the game, and the game itself.
*   It has responsabilities of selection which scene to render as example.
*   It can also call exitGame() to terminate game.
*/


#include <iostream>
#include <deque>
#include "../Constantes.hpp"

class Scene;

using namespace globals;

class SceneManager {
    public:
        ~SceneManager();

        static SceneManager& getInstance();

        std::deque<Scene*> scenes;

        void update();

        void exitGame();

        //Add scene control methods
        void nextScene(Scene*);
        void prevScene();

        gameState state;
    private:
        SceneManager();
};