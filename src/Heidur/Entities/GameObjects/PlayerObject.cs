using Heidur.Entities.Components;
using Heidur.Entities.Factories;
using Heidur.Entities.Processors;
using Heidur.Entities.Skills;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heidur.Entities.GameObjects
{
	public class PlayerObject : GameObject
	{
        public PhysicsComponent PhysicsComponent { get; set; }
        public StatsComponent StatsComponent { get; set; }
        public SpriteComponent SpriteComponent { get; set; }
		public List<ISkill> SkillSet { get; set; }
		public List<ItemComponent> Inventory { get; set; }

        public PlayerObject()
        {
            PhysicsComponent = new PhysicsComponent();
            StatsComponent = new StatsComponent();
			SpriteComponent = SpriteFactory.GetNewAnimatedSprite(Constants.Unit.DEFAULT_SPRITE);
			SkillSet = new List<ISkill>() { new MeleeSkill(), new RangedSkill() };
			Inventory = new List<ItemComponent>() { };
		}

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            PhysicsProcessor.Update(deltaTime, nearbyNPC, map, this);
            StatsProcessor.Update(deltaTime, StatsComponent);
            SpriteProcessor.Update(deltaTime, SpriteComponent);
            AnimationProcessor.SwitchToFrameCategory(this as GameObject);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteProcessor.Draw(spriteBatch, position, SpriteComponent);
        }
    }
}