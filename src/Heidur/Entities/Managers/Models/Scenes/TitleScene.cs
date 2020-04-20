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
		public List<UIButton> uiButtons;
		public Texture2D HeidurLogo;

		public Constants.Scene.SCENE_STATE State { get; set; }

		public void Initialize(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.INITIALIZING;
			inputManager = new InputManager();
		}

		public void LoadContent(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.LOADING;
			HeidurLogo = game.Content.Load<Texture2D>("HeidurLogo");
			UIProcessor.LoadContent(game);
			var startSprite = game.Content.Load<Texture2D>("NewGameButton");
			var exitSprite = game.Content.Load<Texture2D>("ExitButton");
			uiButtons = new List<UIButton>()
			{
				new UIButton()
				{
					Sprite = startSprite,
					Position = new Rectangle(
						Constants.RESOLUTION_WIDTH/2 - startSprite.Width/2,
						Constants.RESOLUTION_HEIGHT/2,
						startSprite.Width,
						startSprite.Height),
					Action = () =>
					{
						game.sceneManager.SetScene(game, new MainGameScene());
					}
				},
				new UIButton()
				{
					Sprite = exitSprite,
					Position = new Rectangle(
						Constants.RESOLUTION_WIDTH/2 - exitSprite.Width/2,
						Constants.RESOLUTION_HEIGHT/2+startSprite.Height,
						exitSprite.Width,
						exitSprite.Height),
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
			game.GraphicsDevice.Clear(Color.DarkSlateGray);
			spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
			spriteBatch.End();

			game.GraphicsDevice.SetRenderTarget(null);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			
			spriteBatch.Draw(game.nativeRenderTarget, new Rectangle(0, 0, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_WIDTH, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_HEIGHT), Color.White);
			foreach(var button in uiButtons)
			{
				UIProcessor.DrawSprite(spriteBatch, button);
			}
			spriteBatch.Draw(HeidurLogo, new Rectangle((((Constants.RESOLUTION_WIDTH / HeidurLogo.Width)/2)* HeidurLogo.Width) - HeidurLogo.Width/2, 0, HeidurLogo.Width, HeidurLogo.Height), Color.White);
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
