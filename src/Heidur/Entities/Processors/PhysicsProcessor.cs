using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Processors
{
    public static class PhysicsProcessor
    {
        public static void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map, PhysicsComponent physicsComponent)
        {
            physicsComponent.Clock += deltaTime;
            physicsComponent.NearbyUnits = getInRangeUnits(nearbyNPC, physicsComponent);
            Move(deltaTime, map, physicsComponent);
			if (physicsComponent.objective != null &&
				!StatsProcessor.CheckIfAlive(physicsComponent.objective.statsComponent))
			{
				physicsComponent.objective = null;
			}
        }

        public static void MoveTo(Vector2 goTo, PhysicsComponent physicsComponent)
        {
            physicsComponent.destination = goTo;
        }

        private static void SetDestination(GameMap map, PhysicsComponent physicsComponent)
        {
            if (physicsComponent.Up)
            {
                physicsComponent.destination = physicsComponent.position - new Vector2(0, Constants.TILESIZE);
                physicsComponent.FacingDirection = FacingDirections.UP;
            }

            if (physicsComponent.Down)
            {
                physicsComponent.destination = physicsComponent.position + new Vector2(0, Constants.TILESIZE);
                physicsComponent.FacingDirection = FacingDirections.DOWN;
            }

            if (physicsComponent.Right)
            {
                physicsComponent.destination = physicsComponent.position + new Vector2(Constants.TILESIZE, 0);
                physicsComponent.FacingDirection = FacingDirections.RIGHT;
            }

            if (physicsComponent.Left)
            {
                physicsComponent.destination = physicsComponent.position - new Vector2(Constants.TILESIZE, 0);
                physicsComponent.FacingDirection = FacingDirections.LEFT;
            }

            if (CheckColission(map, physicsComponent.destination))
            {
                physicsComponent.destination = physicsComponent.position;
            }
        }

        private static bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }

        public static int GetDistanceFromUnit(PhysicsComponent target, PhysicsComponent source)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(source.position.X - target.position.X, 2) + Math.Pow(source.position.Y - target.position.Y, 2)) / Constants.TILESIZE);
        }

        private static List<GameObject> getInRangeUnits(List<GameObject> allNpc, PhysicsComponent source)
        {
            var result = new List<GameObject>();

            result.AddRange(allNpc.Where(n => GetDistanceFromUnit(n.physicsComponent, source) < Constants.Unit.DEFAULT_RANGE));

            return result;
        }

        private static void Move(float deltaTime, GameMap map, PhysicsComponent physicsComponent)
        {
            if (physicsComponent.position == physicsComponent.destination)
            {
                physicsComponent.IsMoving = false;
                SetDestination(map, physicsComponent);
            }
            else
            {
                physicsComponent.IsMoving = true;
                var frameSpeed = physicsComponent.Speed * deltaTime;
                Vector2 offset = physicsComponent.destination - physicsComponent.position;
                if (offset.X > 0)
                {
                    if (offset.X > frameSpeed)
                        offset.X = frameSpeed;
                }
                else if (offset.X < 0)
                {
                    if (offset.X < -1 * frameSpeed)
                        offset.X = -1 * frameSpeed;
                }

                if (offset.Y > 0)
                {
                    if (offset.Y > frameSpeed)
                        offset.Y = frameSpeed;
                }
                else if (offset.Y < 0)
                {
                    if (offset.Y < -1 * frameSpeed)
                        offset.Y = -1 * frameSpeed;
                }

                physicsComponent.position += offset;

                if (physicsComponent.position == physicsComponent.destination)
                {
                    SetDestination(map, physicsComponent);
                }
            }
        }

        public static bool CheckIfClicked(Vector2 clickPosition, PhysicsComponent physicsComponent)
        {
            if (clickPosition.X > physicsComponent.position.X && clickPosition.X  < physicsComponent.position.X + Constants.TILESIZE)
            {
                if (clickPosition.Y > physicsComponent.position.Y && clickPosition.Y < physicsComponent.position.Y + Constants.TILESIZE)
                {
                    physicsComponent.IsSelected = !physicsComponent.IsSelected;
                    return true;
                }
            }

			if ((clickPosition.X / Constants.TILESIZE)-1 == physicsComponent.position.X / Constants.TILESIZE)
			{
				if ((clickPosition.Y / Constants.TILESIZE) -1 == physicsComponent.position.Y / Constants.TILESIZE)
				{
					physicsComponent.IsSelected = !physicsComponent.IsSelected;
					return true;
				}
			}
            return false;
        }

        public static void MoveUp(PhysicsComponent physicsComponent)
        {
            physicsComponent.Up = true;
        }

        public static void MoveDown(PhysicsComponent physicsComponent)
        {
            physicsComponent.Down = true;
        }

        public static void MoveLeft(PhysicsComponent physicsComponent)
        {
            physicsComponent.Left = true;
        }

        public static void MoveRight(PhysicsComponent physicsComponent)
        {
            physicsComponent.Right = true;
        }

        public static void StopMoveUp(PhysicsComponent physicsComponent)
        {
            physicsComponent.Up = false;
        }

        public static void StopMoveDown(PhysicsComponent physicsComponent)
        {
            physicsComponent.Down = false;
        }

        public static void StopMoveLeft(PhysicsComponent physicsComponent)
        {
            physicsComponent.Left = false;
        }

        public static void StopMoveRight(PhysicsComponent physicsComponent)
        {
            physicsComponent.Right = false;
        }

        public static void StopAllMovement(PhysicsComponent physicsComponent)
        {
            physicsComponent.Right = false;
            physicsComponent.Up = false;
            physicsComponent.Left = false;
            physicsComponent.Down = false;
        }
    }
}
