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
            position = destination = new Vector2(10 * Constants.TILESIZE, 10 * Constants.TILESIZE);
            Range = Constants.Unit.DEFAULT_RANGE;
            Speed = Constants.Unit.DEFAULT_SPEED;
            Damage = Constants.Unit.DEFAULT_DAMAGE;
            currentHP = HP = Constants.Unit.DEFAULT_HP;
            Experience = Constants.Unit.DEFAULT_EXPERIENCE;
            IsSelected = false;
            Up = Down = Left = Right = false;
            MovementByDestination = false;
        }

        public void MoveTo(Vector2 goTo)
        {
            destination = goTo;
        }

        private void Move(float deltaTime)
        {
            if (MovementByDestination)
            {
                if (position != destination)
                {
                    position =
                        new Vector2(
                        position.X > destination.X ? position.X + Speed * deltaTime : position.X - Speed * deltaTime,
                        position.Y > destination.Y ? position.Y + Speed * deltaTime : position.Y - Speed * deltaTime
                        );
                }
            }
            else
            {
                position = Up ? position - new Vector2(0, Speed) : position;
                position = Down ? position + new Vector2(0, Speed) : position;
                position = Right ? position + new Vector2(Speed, 0) : position;
                position = Left ? position - new Vector2(Speed, 0) : position;
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

        public bool Attack(Unit target)
        {
            if (GetDistanceFromUnit(target) < Range)
            {
                target.TakeDamage(Damage);
                return true;
            }

            return false;
        }

        public void TakeDamage(int damage)
        {
            currentHP -= damage;
        }

        public void Update(float deltaTime, List<NonPlayerCharacter> nearbyNPC)
        {
            nearbyUnits = getInRangeUnits(nearbyNPC);
            if (CheckIfAlive())
            {
                this.Move(deltaTime);
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

        public void KeyActions(KeyboardState keyBoardState)
        {
            if(keyBoardState.IsKeyDown(Keys.Z))
            {
                var objective = nearbyUnits.Where(u => u.CheckIfAlive()).OrderBy(u => GetDistanceFromUnit(u)).FirstOrDefault();
                if (objective != null)
                {
                    objective.TakeDamage(this.Damage);
                    Console.WriteLine($"Did {this.Damage} damage to Objective!");
                    if (!objective.CheckIfAlive())
                    {
                        Console.WriteLine($"You Killed the Objective!");
                        this.GainExperience(Constants.Unit.DEFAULT_EXPERIENCE_GAIN);
                    }
                }
            }

            if (keyBoardState.IsKeyDown(Keys.Up))
            {
                MoveUp();
            }
            else
            {
                StopMoveUp();
            }

            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                MoveDown();
            }
            else
            {
                StopMoveDown();
            }

            if (keyBoardState.IsKeyDown(Keys.Left))
            {
                MoveLeft();
            }
            else
            {
                StopMoveLeft();
            }

            if (keyBoardState.IsKeyDown(Keys.Right))
            {
                MoveRight();
            }
            else
            {
                StopMoveRight();
            }

        }

        private void MoveUp()
        {
            Up = true;
        }

        private void MoveDown()
        {
            Down = true;
        }

        private void MoveLeft()
        {
            Left = true;
        }

        private void MoveRight()
        {
            Right = true;
        }

        private void StopMoveUp()
        {
            Up = false;
        }

        private void StopMoveDown()
        {
            Down = false;
        }

        private void StopMoveLeft()
        {
            Left = false;
        }

        private void StopMoveRight()
        {
            Right = false;
        }
    }
}
