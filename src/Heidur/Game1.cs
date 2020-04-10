using Heidur.Entities.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Heidur.Entities.Managers.Models.Scenes;
using System.Collections.Generic;

namespace Heidur
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
    {
		public GraphicsDeviceManager graphics;
		public RenderTarget2D nativeRenderTarget;
		public SpriteBatch spriteBatch;

		public SceneManager sceneManager;

		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

			sceneManager = new SceneManager(new MainGameScene());
		}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Window options
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = Constants.RESOLUTION_WIDTH;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = Constants.RESOLUTION_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d); // Caps framerate to 60fps

            nativeRenderTarget = new RenderTarget2D(GraphicsDevice, Constants.RESOLUTION_WIDTH, Constants.RESOLUTION_HEIGHT);

            //Mouse options
            //Mouse.SetCursor(MouseCursor.FromTexture2D(Content.Load<Texture2D>("cursor"), 0, 0));
            this.IsMouseVisible = true;

			// TODO: Add your initialization logic here
			sceneManager.Initialize(this);


			base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			sceneManager.LoadContent(this);
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.CheckKeyboard(delta);

            this.CheckMouseActions(delta);

			// TODO: Add your update logic here
			sceneManager.Update(delta);


			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
			// TODO: Add your drawing code here
			sceneManager.Draw(this);

            base.Draw(gameTime);
        }

        private void CheckKeyboard(float delta)
        {
			sceneManager.CheckKeyboard(this, delta);
        }

        private void CheckMouseActions(float delta)
        {
			sceneManager.CheckMouseActions(delta);
        }
    }
}
