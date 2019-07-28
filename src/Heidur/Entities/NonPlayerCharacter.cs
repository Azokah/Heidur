using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class NonPlayerCharacter : Unit
    {
        private float IdleMovementInterval;
        private float Clock;
        Random random;

        public new void Init()
        {
            base.Init();

            this.Range = Constants.NPC.DEFAULT_RANGE;
            random = new Random(Guid.NewGuid().GetHashCode());
            this.position = new Vector2(random.Next(Constants.Map.DEFAULT_MAP_WIDTH-1) * Constants.TILESIZE, random.Next(Constants.Map.DEFAULT_MAP_HEIGHT-1) * Constants.TILESIZE);
            destination = position;
            IdleMovementInterval = 0;
            Clock = 0;
            
        }

        public new void Update(float deltaTime, List<IUnit> nearbyNPC, GameMap map)
        {
            Clock += deltaTime;
            base.Update(deltaTime, nearbyNPC, map);
            var objective = nearbyNPC.Where(u => this.GetDistanceFromUnit(u) < this.Range).FirstOrDefault();
            if (objective != null)
            {
                AIAgressive(map, objective);
            }
            else
            {
                AIIdle(map);
            }
        }

        private void AIAgressive(GameMap map, IUnit objective)
        {
            if (this.Clock > IdleMovementInterval + Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE)
            {
                IdleMovementInterval = Clock;

                if (objective.position.Y < this.position.Y)
                {
                    destination = position - new Vector2(0, Constants.TILESIZE);
                    FacingDirection = FacingDirections.UP;
                }

                if (objective.position.Y > this.position.Y)
                {
                    destination = position + new Vector2(0, Constants.TILESIZE);
                    FacingDirection = FacingDirections.DOWN;
                }

                if (objective.position.X > this.position.X)
                {
                    destination = position + new Vector2(Constants.TILESIZE, 0);
                    FacingDirection = FacingDirections.RIGHT;
                }

                if (objective.position.X < this.position.X)
                {
                    destination = position - new Vector2(Constants.TILESIZE, 0);
                    FacingDirection = FacingDirections.LEFT;
                }

                if (CheckColission(map, destination))
                {
                    destination = position;
                }
            }

            this.Attack();
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
                        this.destination += new Vector2(-1 * Constants.TILESIZE, 0);
                    }
                    else
                    {
                        this.destination += new Vector2(0, -1 * Constants.TILESIZE);
                    }
                }
                else
                {
                    // X or Y
                    if (random.Next(2) == 1)
                    {
                        this.destination += new Vector2(Constants.TILESIZE, 0);
                    }
                    else
                    {
                        this.destination += new Vector2(0, Constants.TILESIZE);
                    }
                }

                if (CheckColission(map, destination))
                {
                    destination = position;
                }
            }
        }

        private bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }
    }
}
