using Heidur.Entities.Components;
using Heidur.Entities.Items;
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
            statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            physicsComponent.position = new Vector2(RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_WIDTH-1) * Constants.TILESIZE, RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_HEIGHT-1) * Constants.TILESIZE);
            physicsComponent.destination = this.physicsComponent.position;
            physicsComponent.Speed = Constants.NPC.DEFAULT_SPEED;
            spriteComponent.TextureName = SpriteName;
            spriteComponent.TextureModifier = Constants.NPC.DEFAULT_NPC_SIZE_MODIFIER;
			ItemsProcessor.Unequip(this, (Item)inventory.First());
		}

        public NonPlayerCharacter(int x, int y, string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            aiBehaviorComponent = new AIBehaviorsComponent();
            statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            physicsComponent.position = new Vector2(x * Constants.TILESIZE, y * Constants.TILESIZE);
            physicsComponent.destination = this.physicsComponent.position;
            physicsComponent.Speed = Constants.NPC.DEFAULT_SPEED;
            spriteComponent.TextureName = SpriteName;
            spriteComponent.TextureModifier = Constants.NPC.DEFAULT_NPC_SIZE_MODIFIER;
			ItemsProcessor.Unequip(this, (Item)inventory.First());
		}

        public new void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            base.Update(deltaTime, nearbyNPC, map);
            AIBehaviorProcessor.Update(deltaTime, nearbyNPC, map, this);
        }
    }
}
