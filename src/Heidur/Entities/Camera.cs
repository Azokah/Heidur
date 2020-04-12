using Heidur.Entities.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public static class Camera
    {
        public const int Width = Constants.RESOLUTION_WIDTH;
        public const int Height = Constants.RESOLUTION_HEIGHT;

        public static Vector2 position = position = new Vector2()
        {
            X = 0,
            Y = 0
        };

        private static bool UP = false, DOWN = false, LEFT = false, RIGHT = false;

        public static void Update(GameObject unit = null)
        {
            if (unit != null)
            {
                Camera.CenterCameraAtUnit(unit);
            }

            position.Y -= UP ? Constants.Camera.CAMERA_SPEED : 0;
            position.Y += DOWN ? Constants.Camera.CAMERA_SPEED : 0;
            position.X += RIGHT ? Constants.Camera.CAMERA_SPEED : 0;
            position.X -= LEFT ? Constants.Camera.CAMERA_SPEED : 0;
        }

        public static void MoveUp()
        {
            UP = true;
        }

        public static void MoveDown()
        {
            DOWN = true;
        }

        public static void MoveLeft()
        {
            LEFT = true;
        }

        public static void MoveRight()
        {
            RIGHT = true;
        }

        public static void StopMoveUp()
        {
            UP = false;
        }

        public static void StopMoveDown()
        {
            DOWN = false;
        }

        public static void StopMoveLeft()
        {
            LEFT = false;
        }

        public static void StopMoveRight()
        {
            RIGHT = false;
        }

        public static void MoveCameraAtBoundaries(Point mousePosition)
        {
            if (mousePosition.X > Constants.RESOLUTION_WIDTH - Constants.Camera.CAMERA_BORDERS)
            {
                Camera.MoveRight();
            }
            else
            {
                Camera.StopMoveRight();
            }

            if (mousePosition.X < Constants.Camera.CAMERA_BORDERS)
            {
                Camera.MoveLeft();
            }
            else
            {
                Camera.StopMoveLeft();
            }

            if (mousePosition.Y > Constants.RESOLUTION_HEIGHT - Constants.Camera.CAMERA_BORDERS)
            {
                Camera.MoveDown();
            }
            else
            {
                Camera.StopMoveDown();
            }

            if (mousePosition.Y < Constants.Camera.CAMERA_BORDERS)
            {
                Camera.MoveUp();
            }
            else
            {
                Camera.StopMoveUp();
            }
        }

        public static void CenterCameraAtUnit(GameObject unit)
        {
            Camera.position = unit.PhysicsComponent.position - new Vector2((Constants.RESOLUTION_WIDTH/2)/Constants.DEFAULT_ZOOMING_MODIFIER, (Constants.RESOLUTION_HEIGHT/2) / Constants.DEFAULT_ZOOMING_MODIFIER);
        }

		public static Vector2 GetRealPosition()
		{
			return Camera.position;
		}
           
    }
}
