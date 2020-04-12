using Heidur.Entities.GameObjects;
using Heidur.Entities.Skills;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Processors
{
	public static class AIBehaviorProcessor
    {
        public static void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map, NonPlayerCharacter caller)
        {
            caller.aiBehaviorComponent.Clock.Update(deltaTime);

			caller.PhysicsComponent.objective = nearbyNPC.Where(u => PhysicsProcessor.GetDistanceFromUnit(u.PhysicsComponent, caller.PhysicsComponent) < caller.StatsComponent.Vision).FirstOrDefault();
            if (caller.PhysicsComponent.objective != null)
            {
                AIAgressive(caller, map);
            }
            else
            {
                AIIdle(caller, map);
            }
        }

        private static void AIAgressive(NonPlayerCharacter caller, GameMap map)
        {
            PhysicsProcessor.StopAllMovement(caller.PhysicsComponent);
			

            if (caller.aiBehaviorComponent.Clock.isIntervalTicked(Constants.NPC.DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE))
            {

                if (caller.PhysicsComponent.objective.PhysicsComponent.position.Y < caller.PhysicsComponent.position.Y)
                {
                    PhysicsProcessor.MoveUp(caller.PhysicsComponent);
                    caller.PhysicsComponent.FacingDirection = FacingDirections.UP;
                }

                if (caller.PhysicsComponent.objective.PhysicsComponent.position.Y > caller.PhysicsComponent.position.Y)
                {
                    PhysicsProcessor.MoveDown(caller.PhysicsComponent);
                    caller.PhysicsComponent.FacingDirection = FacingDirections.DOWN;
                }

                if (caller.PhysicsComponent.objective.PhysicsComponent.position.X > caller.PhysicsComponent.position.X)
                {
                    PhysicsProcessor.MoveRight(caller.PhysicsComponent);
                    caller.PhysicsComponent.FacingDirection = FacingDirections.RIGHT;
                }

                if (caller.PhysicsComponent.objective.PhysicsComponent.position.X < caller.PhysicsComponent.position.X)
                {
                    PhysicsProcessor.MoveLeft(caller.PhysicsComponent);
                    caller.PhysicsComponent.FacingDirection = FacingDirections.LEFT;
                }

                if (CheckColission(map, caller.PhysicsComponent.destination))
                {
                    caller.PhysicsComponent.destination = caller.PhysicsComponent.position;
                }
            }

			caller.SkillSet.Where(s => s is MeleeSkill).FirstOrDefault().Execute(caller, caller.PhysicsComponent.objective);
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
                        caller.PhysicsComponent.destination += new Vector2(-1 * Constants.TILESIZE, 0);
                    }
                    else
                    {
                        caller.PhysicsComponent.destination += new Vector2(0, -1 * Constants.TILESIZE);
                    }
                }
                else
                {
                    // X or Y
                    if (RandomNumbersHelper.ReturnRandomNumber(2) == 1)
                    {
                        caller.PhysicsComponent.destination += new Vector2(Constants.TILESIZE, 0);
                    }
                    else
                    {
                        caller.PhysicsComponent.destination += new Vector2(0, Constants.TILESIZE);
                    }
                }

                if (CheckColission(map, caller.PhysicsComponent.destination))
                {
                    caller.PhysicsComponent.destination = caller.PhysicsComponent.position;
                }
            }
        }

        private static bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }
    }
}
