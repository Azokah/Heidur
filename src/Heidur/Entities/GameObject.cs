using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Heidur.Entities.Skills;
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
		public List<ISkill> skillSet { get; set; }

        public GameObject()
        {
            physicsComponent = new PhysicsComponent();
            statsComponent = new StatsComponent();
            spriteComponent = new SpriteComponent();
			skillSet = new List<ISkill>() { new MeleeSkill(), new RangedSkill()};

		}

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            PhysicsProcessor.Update(deltaTime, nearbyNPC, map, physicsComponent);
            StatsProcessor.Update(deltaTime, statsComponent);
            SpriteProcessor.Update(deltaTime, spriteComponent);
            AnimationProcessor.SwitchToFrameCategory(this);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteProcessor.Draw(spriteBatch, position, spriteComponent, physicsComponent.FacingDirection);
        }
    }
}
