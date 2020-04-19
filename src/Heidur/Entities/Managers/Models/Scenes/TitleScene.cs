using Heidur.Entities.Processors;
using Heidur.Entities.Processors.Models.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Heidur.Entities.Managers.Models.Scenes
{
	public class TitleScene : IScene
	{
		// Engine and Game properties
		public InputManager inputManager;
		public List<UITextButton> uiButtons;

		public Constants.Scene.SCENE_STATE State { get; set; }

		public void Initialize(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.INITIALIZING;
			inputManager = new InputManager();
		}

		public void LoadContent(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.LOADING;
			UIProcessor.LoadContent(game);
			uiButtons = new List<UITextButton>()
			{
				new UITextButton()
				{
					TextString = "New Game",
					Position = new Rectangle(
						Constants.RESOLUTION_WIDTH/2,
						Constants.RESOLUTION_HEIGHT/2,
						Convert.ToInt32(UIProcessor.font.MeasureString("New Game").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("New Game").Y)),
					Action = () =>
					{
						game.sceneManager.SetScene(game, new MainGameScene());
					}
				},
				new UITextButton()
				{
					TextString = "Exit",
					Position = new Rectangle(
						Constants.RESOLUTION_WIDTH/2,
						Constants.RESOLUTION_HEIGHT/2+Constants.UI.DEFAULT_UI_FONT_SIZE,
						Convert.ToInt32(UIProcessor.font.MeasureString("Exit").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Exit").Y)),
					Action = () =>
					{
						game.Exit();
					}
				}
			};
		}

		public void Update(float delta)
		{
			State = Constants.Scene.SCENE_STATE.RUNNING;
		}

		public void Draw(Game1 game)
		{
			var spriteBatch = game.spriteBatch;

			game.GraphicsDevice.SetRenderTarget(game.nativeRenderTarget);
			game.GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
			spriteBatch.End();

			game.GraphicsDevice.SetRenderTarget(null);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			spriteBatch.Draw(game.nativeRenderTarget, new Rectangle(0, 0, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_WIDTH, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_HEIGHT), Color.White);
			foreach(var button in uiButtons)
			{
				UIProcessor.DrawText(spriteBatch, button.TextString, new Vector2(button.Position.X, button.Position.Y), Color.Red);
			}
			spriteBatch.End();
		}

		public void CheckKeyboard(Game1 game, float delta)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				game.Exit();

			var actions = new List<IUIAction>();
			uiButtons.ForEach(a => actions.Add(a));
			inputManager.Update(Keyboard.GetState(), actions);
		}

		public void CheckMouseActions(float delta)
		{
			// BUTTONS
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				//BOUNDARIES
				foreach(var button in uiButtons)
				{
					inputManager.Update(Mouse.GetState().Position, button);
				}
			}

			if (Mouse.GetState().RightButton == ButtonState.Pressed)
			{
				// Do cool stuff here
			}
		}
	}
}
