using Heidur.Entities.Processors;
using Heidur.Entities.Processors.Models.UI;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Heidur.Entities.Managers.Models.Scenes
{
	public class StartingCreditsScene : IScene
	{
		// Engine and Game properties
		public Texture2D AzoSoftwareLogo;
		public Game1 gameReference = null;
		public Clock clock;

		public Constants.Scene.SCENE_STATE State { get; set; }

		public void Initialize(Game1 game)
		{
			State = Constants.Scene.SCENE_STATE.INITIALIZING;
			clock = new Clock()
			{
				Value = 0,
				lastTick = 10
			};
			gameReference = game;
		}

		public void LoadContent(Game1 game)
		{
			AudioProcessor.LoadContentAndPlay(game);
			State = Constants.Scene.SCENE_STATE.LOADING;
			AzoSoftwareLogo = game.Content.Load<Texture2D>("Logos/AzoSoftware");
		}

		public void Update(float delta)
		{
			State = Constants.Scene.SCENE_STATE.RUNNING;
			clock.Update(delta);
			if (clock.isIntervalTicked(0))
			{
				gameReference.sceneManager.SetScene(gameReference, new TitleScene());
			}
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
			
			spriteBatch.Draw(game.nativeRenderTarget, new Rectangle(0, 0, Constants.RESOLUTION_WIDTH, Constants.RESOLUTION_HEIGHT), Color.White);
			spriteBatch.Draw(AzoSoftwareLogo, new Rectangle((((Constants.RESOLUTION_WIDTH / AzoSoftwareLogo.Width)/2)* AzoSoftwareLogo.Width) - AzoSoftwareLogo.Width/2, Constants.RESOLUTION_HEIGHT/2 - AzoSoftwareLogo.Height/2, AzoSoftwareLogo.Width, AzoSoftwareLogo.Height), Color.White);
			spriteBatch.End();
		}

		public void CheckKeyboard(Game1 game, float delta)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				game.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Enter))
				gameReference.sceneManager.SetScene(gameReference, new TitleScene());
		}

		public void CheckMouseActions(float delta)
		{
		}
	}
}
