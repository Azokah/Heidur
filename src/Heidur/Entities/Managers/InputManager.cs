using Heidur.Entities.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Managers
{
    public class InputManager
    {
        private GameObject player;
        private ICommand moveUp, moveDown, moveLeft, moveRight;
        private ICommand stopMoveUp, stopMoveDown, stopMoveLeft, stopMoveRight;
        private ICommand attack;

        public InputManager(GameObject player)
        {
            this.player = player;
            moveUp = new MoveUpCommand();
            moveDown = new MoveDownCommand();
            moveRight = new MoveRightCommand();
            moveLeft = new MoveLeftCommand();
            stopMoveUp = new StopMoveUpCommand();
            stopMoveLeft = new StopMoveLeftCommand();
            stopMoveRight = new StopMoveRightCommand();
            stopMoveDown = new StopMoveDownCommand();
            attack = new AttackCommand();
        }

        public void Update(Point mousePositionInWindow)
        {
            int centerX = Constants.RESOLUTION_WIDTH / 2;
            int centerY = Constants.RESOLUTION_HEIGHT / 2;

            if (mousePositionInWindow.Y < Constants.Camera.MOUSE_MOVEMENT_HEIGHT_ACTIVE_ZONE)
            {
                moveUp.execute(this.player);
            }
            else
            {
                stopMoveUp.execute(this.player);
            }

            if (mousePositionInWindow.Y > Constants.RESOLUTION_HEIGHT - Constants.Camera.MOUSE_MOVEMENT_HEIGHT_ACTIVE_ZONE)
            {
                moveDown.execute(this.player);
            }
            else
            {
                stopMoveDown.execute(this.player);
            }

            if (mousePositionInWindow.X < Constants.Camera.MOUSE_MOVEMENT_WIDTH_ACTIVE_ZONE)
            {
                moveLeft.execute(this.player);
            }
            else
            {
                stopMoveLeft.execute(this.player);
            }

            if (mousePositionInWindow.X > Constants.RESOLUTION_WIDTH - Constants.Camera.MOUSE_MOVEMENT_WIDTH_ACTIVE_ZONE)
            {
                moveRight.execute(this.player);
            }
            else
            {
                stopMoveRight.execute(this.player);
            }
        }

        public void Update(KeyboardState keyBoardState)
        {
            if (keyBoardState.IsKeyDown(Keys.LeftControl))
            {
                attack.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.W))
            {
                moveUp.execute(this.player);
            }
            else
            {
                stopMoveUp.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.S))
            {
                moveDown.execute(this.player);
            }
            else
            {
                stopMoveDown.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.A))
            {
                moveLeft.execute(this.player);
            }
            else
            {
                stopMoveLeft.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.D))
            {
                moveRight.execute(this.player);
            }
            else
            {
                stopMoveRight.execute(this.player);
            }
        }
    }
}
