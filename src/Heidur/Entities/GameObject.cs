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
        public PhysicsComponent PhysicsComponent { get; set; }
        public StatsComponent StatsComponent { get; set; }
        public SpriteComponent SpriteComponent { get; set; }
		public List<ISkill> SkillSet { get; set; }
		public List<ItemComponent> Inventory { get; set; }

        public GameObject()
        {
            PhysicsComponent = new PhysicsComponent();
            StatsComponent = new StatsComponent();
            SpriteComponent = new SpriteComponent();
			SkillSet = new List<ISkill>() { new MeleeSkill(), new RangedSkill() };
			Inventory = new List<ItemComponent>() { new ItemComponent() };
			ItemsProcessor.EquipAll(this);
		}

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            PhysicsProcessor.Update(deltaTime, nearbyNPC, map, this);
            StatsProcessor.Update(deltaTime, StatsComponent);
            SpriteProcessor.Update(deltaTime, SpriteComponent);
            AnimationProcessor.SwitchToFrameCategory(this);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteProcessor.Draw(spriteBatch, position, SpriteComponent, PhysicsComponent.FacingDirection);
        }
    }
}
