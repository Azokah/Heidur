using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Heidur.Entities
{
    public class NonPlayerCharacter : GameObject
    {

        public AIBehaviorsComponent aiBehaviorComponent;

        public NonPlayerCharacter(string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            aiBehaviorComponent = new AIBehaviorsComponent();
            this.statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            this.physicsComponent.position = new Vector2(RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_WIDTH-1) * Constants.TILESIZE, RandomNumbersHelper.ReturnRandomNumber(Constants.Map.DEFAULT_MAP_HEIGHT-1) * Constants.TILESIZE);
            this.physicsComponent.destination = this.physicsComponent.position;
            spriteComponent.textureName = SpriteName;
            spriteComponent.textureModifier = 2;
            
        }

        public NonPlayerCharacter(int x, int y, string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            aiBehaviorComponent = new AIBehaviorsComponent();
            this.statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            this.physicsComponent.position = new Vector2(x * Constants.TILESIZE, y * Constants.TILESIZE);
            this.physicsComponent.destination = this.physicsComponent.position;
            spriteComponent.textureName = SpriteName;
            spriteComponent.textureModifier = 2;
        }

        public new void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            base.Update(deltaTime, nearbyNPC, map);
            AIBehaviorProcessor.Update(deltaTime, nearbyNPC, map, this);
        }
    }
}
