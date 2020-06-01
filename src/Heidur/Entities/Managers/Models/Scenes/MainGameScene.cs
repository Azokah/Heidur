using Heidur.Entities.Components;
using Heidur.Entities.Factories;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Heidur.Entities.Managers.Models.Scenes
{
	public class MainGameScene : IScene
	{
		// Engine and Game properties
		public Camera2D camera;
		public InputManager inputManager;
		public GameObjectManager gameObjectManager;
		public Constants.Scene.SCENE_STATE State { get; set; }

		public void Initialize(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.INITIALIZING;
			gameObjectManager = new GameObjectManager();
			inputManager = new InputManager(gameObjectManager.unit);
			camera = new Camera2D(game);
			camera.SetCameraSource(gameObjectManager.unit);
		}

		public void LoadContent(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.LOADING;

			TemplatesProcessor.LoadTemplates();
			SpriteProcessor.LoadContent(game);
			ParticlesProcessor.LoadContent(game);
			UIProcessor.LoadContent(game);
			gameObjectManager.LoadContent(game);
		}

		public void Update(float delta)
		{
			State = Constants.Scene.SCENE_STATE.RUNNING;
			gameObjectManager.Update(delta);
			camera.Update(delta);
			ParticlesProcessor.Update();
			UIProcessor.Update(delta);
		}

		public void Draw(Game1 game)
		{
			var spriteBatch = game.spriteBatch;

			game.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin(SpriteSortMode.Deferred, samplerState: SamplerState.PointClamp, transformMatrix: camera.camera.GetViewMatrix());
			gameObjectManager.Draw(spriteBatch);
			ParticlesProcessor.Draw(spriteBatch);
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
				inputManager.Update(camera.camera.ScreenToWorld(Mouse.GetState().Position.ToVector2()), gameObjectManager.npcs);
				if (UIProcessor.statsWindow.Enabled)
				{
					foreach (var button in UIProcessor.statsWindow.Components)
					{
						inputManager.Update(camera.camera.ScreenToWorld(Mouse.GetState().Position.ToVector2()), button);
					}
				}
				if (UIProcessor.inventoryWindow.Enabled)
				{
					foreach (var button in UIProcessor.inventoryWindow.Components)
					{
						inputManager.Update(camera.camera.ScreenToWorld(Mouse.GetState().Position.ToVector2()), button);
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
