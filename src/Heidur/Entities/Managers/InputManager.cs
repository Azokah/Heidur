using Heidur.Entities.Commands;
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
        private IUnit player;
        private ICommand moveUp, moveDown, moveLeft, moveRight;
        private ICommand stopMoveUp, stopMoveDown, stopMoveLeft, stopMoveRight;
        private ICommand attack;

        public InputManager(IUnit player)
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

        public void Update(KeyboardState keyBoardState)
        {
            if (keyBoardState.IsKeyDown(Keys.Z))
            {
                attack.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.Up))
            {
                moveUp.execute(this.player);
            }
            else
            {
                stopMoveUp.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                moveDown.execute(this.player);
            }
            else
            {
                stopMoveDown.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.Left))
            {
                moveLeft.execute(this.player);
            }
            else
            {
                stopMoveLeft.execute(this.player);
            }

            if (keyBoardState.IsKeyDown(Keys.Right))
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
