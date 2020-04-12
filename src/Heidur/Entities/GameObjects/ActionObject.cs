using Heidur.Entities.Components;
using Heidur.Entities.Factories;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heidur.Entities.GameObjects
{
	public class ActionObject : IGameObject
    {
        public SpriteComponent SpriteComponent { get; set; }

        public ActionObject()
        {
			SpriteComponent = SpriteFactory.GetNewAnimatedSprite(Constants.Unit.DEFAULT_SPRITE);
		}

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            SpriteProcessor.Update(deltaTime, SpriteComponent);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteProcessor.Draw(spriteBatch, position, SpriteComponent);
        }
    }
}