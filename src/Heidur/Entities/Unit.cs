using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class Unit : IUnit
    {
        public Texture2D Texture { get; set; }

        public Vector2 position { get; set; }
        public Vector2 destination { get; set; }
        public int Speed { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Experience { get; set; }

        public bool IsSelected { get; set; }

        public int currentHP { get; set; }

        public bool MovementByDestination;

        private bool Up, Down, Left, Right;

        private List<Unit> nearbyUnits;

        public void Init()
        {
            nearbyUnits = new List<Unit>();
            position = new Vector2(10 * Constants.TILESIZE, 10 * Constants.TILESIZE);
            destination = position;
            Range = Constants.Unit.DEFAULT_RANGE;
            Speed = Constants.Unit.DEFAULT_SPEED;
            Damage = Constants.Unit.DEFAULT_DAMAGE;
            currentHP = HP = Constants.Unit.DEFAULT_HP;
            Experience = Constants.Unit.DEFAULT_EXPERIENCE;
            IsSelected = false;
            Up = Down = Left = Right = false;
        }

        public void MoveTo(Vector2 goTo)
        {
            destination = goTo;
        }

        private void SetDestination(GameMap map)
        {
            if (Up)
                destination = position - new Vector2(0, Constants.TILESIZE);
            if (Down)
                destination = position + new Vector2(0, Constants.TILESIZE);
            if(Right)
                destination = position + new Vector2(Constants.TILESIZE, 0);
            if (Left)
                destination = position - new Vector2(Constants.TILESIZE, 0);

            if (CheckColission(map, destination))
            {
                destination = position;
            }
        }

        private bool CheckColission(GameMap map, Vector2 point)
        {
            return !map.IsTileWalkable(point);
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
                else
                {
                    if (offset.X < -1 * frameSpeed)
                        offset.X = -1 * frameSpeed;
                }

                if (offset.Y > 0)
                {
                    if (offset.Y > frameSpeed)
                        offset.Y = frameSpeed;
                }
                else
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

        public int GetDistanceFromUnit(Unit target)
        {
            return Convert.ToInt32(position.LengthSquared() - target.position.LengthSquared());
        }

        private List<Unit> getInRangeUnits(List<NonPlayerCharacter> nearbyNPC)
        {
            var result = new List<Unit>();

            result.AddRange(nearbyNPC.Where(n => GetDistanceFromUnit(n) < Constants.Unit.DEFAULT_RANGE));

            return result;
        }

        public bool Attack()
        {
            var objective = nearbyUnits.Where(u => u.CheckIfAlive()).OrderBy(u => GetDistanceFromUnit(u)).FirstOrDefault();
            if (objective != null)
            {
                objective.TakeDamage(this.Damage);
            }

            return false;
        }

        public void TakeDamage(int damage)
        {
            currentHP -= damage;
        }

        public void Update(float deltaTime, List<NonPlayerCharacter> nearbyNPC, GameMap map)
        {
            nearbyUnits = getInRangeUnits(nearbyNPC);
            if (CheckIfAlive())
            {
                this.Move(deltaTime, map);
            }
            else
            {
                // Dead Unit logic
            }
        }

        public bool CheckIfAlive()
        {
            return (currentHP > 0);
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

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            if(CheckIfAlive())
            {
                spriteBatch.Draw(this.Texture, this.position - camera.position, Color.White);
            }
        }

        public void GainExperience(int experience)
        {
            Console.WriteLine($"You gained {experience} experience points!");
            this.Experience += experience;
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

        public void LoadContent(Game1 game)
        {
            this.Texture = game.Content.Load<Texture2D>(Constants.Unit.DEFAULT_UNIT_SPRITE);
        }
    }
}
