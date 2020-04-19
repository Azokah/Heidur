using Heidur.Entities.Components;
using Heidur.Entities.Factories;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Heidur.Entities.Managers.Models.Scenes
{
	public class MainGameScene : IScene
	{
		// Engine and Game properties
		public InputManager inputManager;
		public GameObjectManager gameObjectManager;
		public Constants.Scene.SCENE_STATE State { get; set; }

		public void Initialize(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.INITIALIZING;
			gameObjectManager = new GameObjectManager();
			inputManager = new InputManager(gameObjectManager.unit);
		}

		public void LoadContent(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.LOADING;

			SpriteProcessor.LoadContent(game);
			ParticlesProcessor.LoadContent(game);
			AudioProcessor.LoadContentAndPlay(game);
			UIProcessor.LoadContent(game);
			gameObjectManager.LoadContent(game);
		}

		public void Update(float delta)
		{
			State = Constants.Scene.SCENE_STATE.RUNNING;
			gameObjectManager.Update(delta);
			Camera.Update(gameObjectManager.unit);
			ParticlesProcessor.Update();
			UIProcessor.Update(delta);
		}

		public void Draw(Game1 game)
		{
			var spriteBatch = game.spriteBatch;

			game.GraphicsDevice.SetRenderTarget(game.nativeRenderTarget);
			game.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
			gameObjectManager.Draw(spriteBatch);
			ParticlesProcessor.Draw(spriteBatch);
			spriteBatch.End();

			game.GraphicsDevice.SetRenderTarget(null);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			spriteBatch.Draw(game.nativeRenderTarget, new Rectangle(0, 0, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_WIDTH, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_HEIGHT), Color.White);
			UIProcessor.Draw(spriteBatch, gameObjectManager.unit);
			spriteBatch.End();
		}

		public void CheckKeyboard(Game1 game, float delta)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				game.Exit();

			inputManager.Update(Keyboard.GetState());
		}

		public void CheckMouseActions(float delta)
		{
			// BUTTONS
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				//BOUNDARIES
				inputManager.Update(Mouse.GetState().Position, gameObjectManager.npcs);
				if (UIProcessor.statsWindow.Enabled)
				{
					foreach (var button in UIProcessor.statsWindow.Components)
					{
						inputManager.Update(Mouse.GetState().Position, button);
					}
				}
				if (UIProcessor.inventoryWindow.Enabled)
				{
					foreach (var button in UIProcessor.inventoryWindow.Components)
					{
						inputManager.Update(Mouse.GetState().Position, button);
					}
				}
			}

			if (Mouse.GetState().RightButton == ButtonState.Pressed)
			{
				// Do cool stuff here
			}
		}
	}
}
