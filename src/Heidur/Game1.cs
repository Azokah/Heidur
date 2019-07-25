using Heidur.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Heidur
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        AudioManager audio;
        GameMap gameMap;
        Unit unit;
        List<NonPlayerCharacter> npcs;
        Camera camera;

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
            graphics.PreferredBackBufferWidth = Constants.RESOLUTION_WIDTH;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = Constants.RESOLUTION_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            //Mouse options
            //Mouse.SetCursor(MouseCursor.FromTexture2D(Content.Load<Texture2D>("cursor"), 0, 0));
            this.IsMouseVisible = true;

            // TODO: Add your initialization logic here
            audio = new AudioManager();

            camera = new Camera();
            camera.Init();
            gameMap = new GameMap();
            gameMap.Init();
            unit = new Unit();
            unit.Init();
            npcs = new List<NonPlayerCharacter>() { new NonPlayerCharacter(), new NonPlayerCharacter() , new NonPlayerCharacter() , new NonPlayerCharacter() };
            npcs.ForEach(n => n.Init());

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
            //audio.LoadContentAndPlay(this);
            gameMap.LoadContent(this); 
            unit.LoadContent(this); 
            npcs.ForEach(n => n.LoadContent(this));
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
            unit.Update(delta, npcs);
            npcs.ForEach(n => n.Update(delta, npcs));
            camera.Update(unit);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            gameMap.Draw(camera, spriteBatch);
            unit.Draw(camera, spriteBatch);
            npcs.ForEach(n => n.Draw(camera, spriteBatch));
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void CheckKeyboard(float delta)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            unit.KeyActions(Keyboard.GetState());
        }

        private void CheckMouseActions(float delta)
        {
            // BUTTONS
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                // Do cool stuff here
                unit.CheckIfClicked(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                // Do cool stuff here

            }

            //BOUNDARIES
            // camera.MoveCameraAtBoundaries(Mouse.GetState().Position);
        }
    }
}
