using Heidur.Entities.Commands;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Heidur.Entities.Managers
{
	public class InputManager
    {
        private GameObject player;
        private ICommand moveUp, moveDown, moveLeft, moveRight;
        private ICommand stopMoveUp, stopMoveDown, stopMoveLeft, stopMoveRight;
        private ICommand attack, rangedAttack;

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
			rangedAttack = new RangedAttackCommand();
		}

		public InputManager()
		{
			moveUp = new MoveUpCommand();
			moveDown = new MoveDownCommand();
			moveRight = new MoveRightCommand();
			moveLeft = new MoveLeftCommand();
			stopMoveUp = new StopMoveUpCommand();
			stopMoveLeft = new StopMoveLeftCommand();
			stopMoveRight = new StopMoveRightCommand();
			stopMoveDown = new StopMoveDownCommand();
			attack = new AttackCommand();
			rangedAttack = new RangedAttackCommand();
		}

		public void Update(Point mousePositionInWindow, List<GameObject> entities)
        {
			foreach(var entity in entities)
			{
				if (PhysicsProcessor.CheckIfClicked(mousePositionInWindow.ToVector2() / Constants.DEFAULT_ZOOMING_MODIFIER + Camera.position, entity.PhysicsComponent))
				{
					player.PhysicsComponent.objective = entity;
					return;
				}
			}
			player.PhysicsComponent.objective = null;
		}

        public void Update(KeyboardState keyBoardState)
        {
            if (keyBoardState.IsKeyDown(Keys.LeftControl))
            {
                attack.execute(this.player);
            }

			if (keyBoardState.IsKeyDown(Keys.LeftAlt))
			{
				rangedAttack.execute(this.player);
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
