using Heidur.Entities;
using Heidur.Entities.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Heidur.Entities.Processors;

namespace Heidur
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
    {
        // Engine and Game properties
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputManager inputManager;
        GameObjectManager gameObjectManager;
		UIManager uiManager;

        RenderTarget2D nativeRenderTarget;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            gameObjectManager = new GameObjectManager();
            inputManager = new InputManager(gameObjectManager.unit);
			uiManager = new UIManager();

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
            ParticlesProcessor.LoadContent(this);
            AudioProcessor.LoadContentAndPlay(this);
            gameObjectManager.LoadContent(this);
			uiManager.LoadContent(this);

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
            gameObjectManager.Update(delta);
            Camera.Update(gameObjectManager.unit);
            ParticlesProcessor.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(nativeRenderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
			gameObjectManager.Draw(spriteBatch);
			ParticlesProcessor.Draw(spriteBatch);
			spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(nativeRenderTarget, new Rectangle(0, 0, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_WIDTH, Constants.DEFAULT_ZOOMING_MODIFIER * Constants.RESOLUTION_HEIGHT), Color.White);
			uiManager.Draw(spriteBatch, gameObjectManager.unit);
			spriteBatch.End();

            base.Draw(gameTime);
        }

        private void CheckKeyboard(float delta)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputManager.Update(Keyboard.GetState());
        }

        private void CheckMouseActions(float delta)
        {
            // BUTTONS
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //BOUNDARIES
                inputManager.Update(Mouse.GetState().Position, gameObjectManager.npcs);
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                // Do cool stuff here
            }
        }
    }
}
