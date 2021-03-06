﻿using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Heidur.Entities
{
	public class NonPlayerCharacter : GameObject
    {

        public AIBehaviorsComponent aiBehaviorComponent;

        public NonPlayerCharacter(string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            
            aiBehaviorComponent = new AIBehaviorsComponent();
            PhysicsComponent.position = new Vector2(RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_WIDTH-1) * Constants.TILESIZE, RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_HEIGHT-1) * Constants.TILESIZE);
            PhysicsComponent.destination = this.PhysicsComponent.position;
            PhysicsComponent.Speed = Constants.NPC.DEFAULT_SPEED;
            SpriteComponent.TextureName = SpriteName;
            SpriteComponent.TextureModifier = Constants.NPC.DEFAULT_NPC_SIZE_MODIFIER;
		}

        public NonPlayerCharacter(int x, int y, string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            aiBehaviorComponent = new AIBehaviorsComponent();
            PhysicsComponent.position = new Vector2(x * Constants.TILESIZE, y * Constants.TILESIZE);
            PhysicsComponent.destination = this.PhysicsComponent.position;
            PhysicsComponent.Speed = Constants.NPC.DEFAULT_SPEED;
            SpriteComponent.TextureName = SpriteName;
            SpriteComponent.TextureModifier = Constants.NPC.DEFAULT_NPC_SIZE_MODIFIER;
		}

        public new void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            base.Update(deltaTime, nearbyNPC, map);
            AIBehaviorProcessor.Update(deltaTime, nearbyNPC, map, this);
        }
    }
}
