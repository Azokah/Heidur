#include <iostream>
#include <deque>

class Scene;


class SceneManager {
    public:
        ~SceneManager();

        static SceneManager& getInstance();

        std::deque<Scene*> scenes;

        void update();

        //Add scene control methods
        void nextScene(Scene*);
        void prevScene();

    private:
        SceneManager();
};