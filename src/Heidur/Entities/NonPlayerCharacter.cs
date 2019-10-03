using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Heidur.Constants.Physics;

namespace Heidur.Entities
{
    public class NonPlayerCharacter : GameObject
    {
        private float IdleMovementInterval;
        private float Clock;
        Random random;

        public NonPlayerCharacter(string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            this.statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            random = new Random(Guid.NewGuid().GetHashCode());
            this.physicsComponent.position = new Vector2(random.Next(Constants.Map.DEFAULT_MAP_WIDTH-1) * Constants.TILESIZE, random.Next(Constants.Map.DEFAULT_MAP_HEIGHT-1) * Constants.TILESIZE);
            this.physicsComponent.destination = this.physicsComponent.position;
            IdleMovementInterval = 0;
            Clock = 0;
            spriteComponent.textureName = SpriteName;
            spriteComponent.textureModifier = 2;
        }

        public NonPlayerCharacter(int x, int y, string SpriteName = Constants.NPC.DEFAULT_SPRITE) : base()
        {
            this.statsComponent.Range = Constants.NPC.DEFAULT_RANGE;
            random = new Random(Guid.NewGuid().GetHashCode());
            this.physicsComponent.position = new Vector2(x * Constants.TILESIZE, y * Constants.TILESIZE);
            this.physicsComponent.destination = this.physicsComponent.position;
            IdleMovementInterval = 0;
            Clock = 0;
            spriteComponent.textureName = SpriteName;
            spriteComponent.textureModifier = 2;
        }

        public new void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            Clock += deltaTime;
            base.Update(deltaTime, nearbyNPC, map);
            var objective = nearbyNPC.Where(u => PhysicsProcessor.GetDistanceFromUnit(u.physicsComponent, this.physicsComponent) < this.statsComponent.Range).FirstOrDefault();
            if (objective != null)
            {
                AIAgressive(map, objective);
            }
            else
            {
                AIIdle(map);
            }
        }

        private void AIAgressive(GameMap map, GameObject objective)
        {
            if (this.Clock > IdleMovementInterval + Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE)
            {
                IdleMovementInterval = Clock;

                if (objective.physicsComponent.position.Y < this.physicsComponent.position.Y)
                {
                    physicsComponent.destination = physicsComponent.position - new Vector2(0, Constants.TILESIZE);
                    physicsComponent.FacingDirection = FacingDirections.UP;
                }

                if (objective.physicsComponent.position.Y > this.physicsComponent.position.Y)
                {
                    physicsComponent.destination = physicsComponent.position + new Vector2(0, Constants.TILESIZE);
                    physicsComponent.FacingDirection = FacingDirections.DOWN;
                }

                if (objective.physicsComponent.position.X > this.physicsComponent.position.X)
                {
                    physicsComponent.destination = physicsComponent.position + new Vector2(Constants.TILESIZE, 0);
                    physicsComponent.FacingDirection = FacingDirections.RIGHT;
                }

                if (objective.physicsComponent.position.X < this.physicsComponent.position.X)
                {
                    physicsComponent.destination = physicsComponent.position - new Vector2(Constants.TILESIZE, 0);
                    physicsComponent.FacingDirection = FacingDirections.LEFT;
                }

                if (CheckColission(map, physicsComponent.destination))
                {
                    physicsComponent.destination = physicsComponent.position;
                }
            }

            StatsProcessor.Attack(this.statsComponent, this.physicsComponent);
        }

        private void AIIdle(GameMap map)
        {
            if (this.Clock > IdleMovementInterval + Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_IDLE)
            {
                IdleMovementInterval = Clock;

                // Negative or positive
                if (random.Next(2) == 1)
                {
                    // X or Y
                    if (random.Next(2) == 1)
                    {
                        this.physicsComponent.destination += new Vector2(-1 * Constants.TILESIZE, 0);
                    }
                    else
                    {
                        this.physicsComponent.destination += new Vector2(0, -1 * Constants.TILESIZE);
                    }
                }
                else
                {
                    // X or Y
                    if (random.Next(2) == 1)
                    {
                        this.physicsComponent.destination += new Vector2(Constants.TILESIZE, 0);
                    }
                    else
                    {
                        this.physicsComponent.destination += new Vector2(0, Constants.TILESIZE);
                    }
                }

                if (CheckColission(map, physicsComponent.destination))
                {
                    physicsComponent.destination = physicsComponent.position;
                }
            }
        }

        private bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }
    }
}
