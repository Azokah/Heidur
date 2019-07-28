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
