using Heidur.Entities.Components;
using Heidur.Entities.Processors;
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

        public GameObject()
        {
            physicsComponent = new PhysicsComponent();
            statsComponent = new StatsComponent();
            spriteComponent = new SpriteComponent();
        }

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            PhysicsProcessor.Update(deltaTime, nearbyNPC, map, physicsComponent);
            StatsProcessor.Update(deltaTime, statsComponent);
            SpriteProcessor.Update(deltaTime, spriteComponent);
            AnimationProcessor.SwitchToFrameCategory(this);
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteProcessor.Draw(camera, spriteBatch, position, spriteComponent, physicsComponent.FacingDirection);
        }
    }
}
