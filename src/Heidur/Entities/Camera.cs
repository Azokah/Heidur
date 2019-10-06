using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class Camera
    {
        public const int Width = Constants.RESOLUTION_WIDTH;
        public const int Height = Constants.RESOLUTION_HEIGHT;

        public Vector2 position;

        private bool UP, DOWN, LEFT, RIGHT;


        public void Init()
        {
            UP = DOWN = LEFT = RIGHT = false;
            position = new Vector2()
            {
                X = 0,
                Y = 0
            };
        }

        public void Update(GameObject unit = null)
        {
            if (unit != null)
            {
                this.CenterCameraAtUnit(unit);
            }

            position.Y -= UP ? Constants.Camera.CAMERA_SPEED : 0;
            position.Y += DOWN ? Constants.Camera.CAMERA_SPEED : 0;
            position.X += RIGHT ? Constants.Camera.CAMERA_SPEED : 0;
            position.X -= LEFT ? Constants.Camera.CAMERA_SPEED : 0;
        }

        public void MoveUp()
        {
            UP = true;
        }

        public void MoveDown()
        {
            DOWN = true;
        }

        public void MoveLeft()
        {
            LEFT = true;
        }

        public void MoveRight()
        {
            RIGHT = true;
        }

        public void StopMoveUp()
        {
            UP = false;
        }

        public void StopMoveDown()
        {
            DOWN = false;
        }

        public void StopMoveLeft()
        {
            LEFT = false;
        }

        public void StopMoveRight()
        {
            RIGHT = false;
        }

        public void MoveCameraAtBoundaries(Point mousePosition)
        {
            if (mousePosition.X > Constants.RESOLUTION_WIDTH - Constants.Camera.CAMERA_BORDERS)
            {
                this.MoveRight();
            }
            else
            {
                this.StopMoveRight();
            }

            if (mousePosition.X < Constants.Camera.CAMERA_BORDERS)
            {
                this.MoveLeft();
            }
            else
            {
                this.StopMoveLeft();
            }

            if (mousePosition.Y > Constants.RESOLUTION_HEIGHT - Constants.Camera.CAMERA_BORDERS)
            {
                this.MoveDown();
            }
            else
            {
                this.StopMoveDown();
            }

            if (mousePosition.Y < Constants.Camera.CAMERA_BORDERS)
            {
                this.MoveUp();
            }
            else
            {
                this.StopMoveUp();
            }
        }

        public void CenterCameraAtUnit(GameObject unit)
        {
            this.position = unit.physicsComponent.position - new Vector2((Constants.RESOLUTION_WIDTH/2)/Constants.DEFAULT_ZOOMING_MODIFIER, (Constants.RESOLUTION_HEIGHT/2) / Constants.DEFAULT_ZOOMING_MODIFIER);
        }
           
    }
}
