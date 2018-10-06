#include <iostream>
#include <vector>

class Scene;


class SceneManager {
    public:
        ~SceneManager();

        static SceneManager& getInstance();

        std::vector<Scene*> scenes;

        void update();
    private:
        SceneManager();
};