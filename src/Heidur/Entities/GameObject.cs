using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Heidur.Entities
{
    public class GameObject : IGameObject
    {
        public PhysicsComponent physicsComponent { get; set; }
        public StatsComponent statsComponent { get; set; }
        public SpriteComponent spriteComponent { get; set; }
        public List<IComponent> Components;

        public GameObject()
        {
            physicsComponent = new PhysicsComponent();
            statsComponent = new StatsComponent();
            spriteComponent = new SpriteComponent();

            Components = new List<IComponent>() { physicsComponent, statsComponent, spriteComponent };
        }

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            Components.ForEach(c => c.Update(deltaTime, nearbyNPC, map));
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch, Vector2 position)
        {
            spriteComponent.Draw(camera, spriteBatch, position);
        }
    }
}
