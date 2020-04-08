using Heidur.Entities.Components;
using Heidur.Entities.Skills;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Processors
{
    public static class AIBehaviorProcessor
    {
        public static void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map, NonPlayerCharacter caller)
        {
            caller.aiBehaviorComponent.Clock.Update(deltaTime);

            var objective = nearbyNPC.Where(u => PhysicsProcessor.GetDistanceFromUnit(u.physicsComponent, caller.physicsComponent) < caller.statsComponent.Range).FirstOrDefault();
            if (objective != null)
            {
                AIAgressive(caller, map, objective);
            }
            else
            {
                AIIdle(caller, map);
            }
        }

        private static void AIAgressive(NonPlayerCharacter caller, GameMap map, GameObject objective)
        {
            PhysicsProcessor.StopAllMovement(caller.physicsComponent);

            if (caller.aiBehaviorComponent.Clock.isIntervalTicked(Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE))
            {

                if (objective.physicsComponent.position.Y < caller.physicsComponent.position.Y)
                {
                    PhysicsProcessor.MoveUp(caller.physicsComponent);
                    caller.physicsComponent.FacingDirection = FacingDirections.UP;
                }

                if (objective.physicsComponent.position.Y > caller.physicsComponent.position.Y)
                {
                    PhysicsProcessor.MoveDown(caller.physicsComponent);
                    caller.physicsComponent.FacingDirection = FacingDirections.DOWN;
                }

                if (objective.physicsComponent.position.X > caller.physicsComponent.position.X)
                {
                    PhysicsProcessor.MoveRight(caller.physicsComponent);
                    caller.physicsComponent.FacingDirection = FacingDirections.RIGHT;
                }

                if (objective.physicsComponent.position.X < caller.physicsComponent.position.X)
                {
                    PhysicsProcessor.MoveLeft(caller.physicsComponent);
                    caller.physicsComponent.FacingDirection = FacingDirections.LEFT;
                }

                if (CheckColission(map, caller.physicsComponent.destination))
                {
                    caller.physicsComponent.destination = caller.physicsComponent.position;
                }
            }

			caller.skillSet.Where(s => s is MeleeSkill).FirstOrDefault().Execute(caller);
        }

        private static void AIIdle(NonPlayerCharacter caller, GameMap map)
        {
            if (caller.aiBehaviorComponent.Clock.isIntervalTicked( Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_IDLE))
            {

                // Negative or positive
                if (RandomNumbersHelper.ReturnRandomNumber(2) == 1)
                {
                    // X or Y
                    if (RandomNumbersHelper.ReturnRandomNumber(2) == 1)
                    {
                        caller.physicsComponent.destination += new Vector2(-1 * Constants.TILESIZE, 0);
                    }
                    else
                    {
                        caller.physicsComponent.destination += new Vector2(0, -1 * Constants.TILESIZE);
                    }
                }
                else
                {
                    // X or Y
                    if (RandomNumbersHelper.ReturnRandomNumber(2) == 1)
                    {
                        caller.physicsComponent.destination += new Vector2(Constants.TILESIZE, 0);
                    }
                    else
                    {
                        caller.physicsComponent.destination += new Vector2(0, Constants.TILESIZE);
                    }
                }

                if (CheckColission(map, caller.physicsComponent.destination))
                {
                    caller.physicsComponent.destination = caller.physicsComponent.position;
                }
            }
        }

        private static bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }
    }
}
