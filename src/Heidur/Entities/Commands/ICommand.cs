using Heidur.Entities.GameObjects;

namespace Heidur.Entities
{
	interface ICommand
    {
        void execute(GameObject player);
    }
}
