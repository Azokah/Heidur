using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Components
{
    public class PhysicsComponent : IComponent
    {
        public enum FacingDirections
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public Vector2 position { get; set; }
        public Vector2 destination { get; set; }

        public FacingDirections FacingDirection;
        public List<GameObject> NearbyUnits;
        
        private float Clock;
        private bool Up, Down, Left, Right;
        public int Speed { get; set; }
        public bool IsSelected { get; set; }


        public PhysicsComponent()
        {
            this.NearbyUnits = new List<GameObject>();
            position = new Vector2(10 * Constants.TILESIZE, 10 * Constants.TILESIZE);
            destination = position;
            Speed = Constants.Unit.DEFAULT_SPEED;
            Up = Down = Left = Right = false;
            FacingDirection = FacingDirections.DOWN;
            IsSelected = false;
        }

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            Clock += deltaTime;
            NearbyUnits = getInRangeUnits(nearbyNPC);
            this.Move(deltaTime, map);
        }

        public void MoveTo(Vector2 goTo)
        {
            destination = goTo;
        }

        private void SetDestination(GameMap map)
        {
            if (Up)
            {
                destination = position - new Vector2(0, Constants.TILESIZE);
                FacingDirection = FacingDirections.UP;
            }

            if (Down)
            {
                destination = position + new Vector2(0, Constants.TILESIZE);
                FacingDirection = FacingDirections.DOWN;
            }

            if (Right)
            {
                destination = position + new Vector2(Constants.TILESIZE, 0);
                FacingDirection = FacingDirections.RIGHT;
            }

            if (Left)
            {
                destination = position - new Vector2(Constants.TILESIZE, 0);
                FacingDirection = FacingDirections.LEFT;
            }


            if (CheckColission(map, destination))
            {
                destination = position;
            }
        }

        private bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
        }

        public int GetDistanceFromUnit(GameObject target)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(this.position.X - target.physicsComponent.position.X, 2) + Math.Pow(this.position.Y - target.physicsComponent.position.Y, 2)) / Constants.TILESIZE);
        }

        private List<GameObject> getInRangeUnits(List<GameObject> nearbyNPC)
        {
            var result = new List<GameObject>();

            result.AddRange(nearbyNPC.Where(n => GetDistanceFromUnit(n) < Constants.Unit.DEFAULT_RANGE));

            return result;
        }


        private void Move(float deltaTime, GameMap map)
        {
            if (position == destination)
            {
                SetDestination(map);
            }
            else
            {
                var frameSpeed = Constants.Unit.DEFAULT_SPEED * deltaTime;
                Vector2 offset = destination - position;
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

                position += offset;

                if (position == destination)
                {
                    SetDestination(map);
                }
            }
        }

        public bool CheckIfClicked(Vector2 clickPosition)
        {
            if (clickPosition.X > this.position.X && clickPosition.X < this.position.X + 64)
            {
                if (clickPosition.Y > this.position.Y && clickPosition.Y < this.position.Y + 64)
                {
                    IsSelected = !IsSelected;
                    return true;
                }
            }
            return false;
        }

        public void MoveUp()
        {
            Up = true;
        }

        public void MoveDown()
        {
            Down = true;
        }

        public void MoveLeft()
        {
            Left = true;
        }

        public void MoveRight()
        {
            Right = true;
        }

        public void StopMoveUp()
        {
            Up = false;
        }

        public void StopMoveDown()
        {
            Down = false;
        }

        public void StopMoveLeft()
        {
            Left = false;
        }

        public void StopMoveRight()
        {
            Right = false;
        }
    }
}
