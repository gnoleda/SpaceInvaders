using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdelongFinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private StartScene startScene;
        private Texture2D startBackground, title;
        private Vector2 titlePos;
        //private SoundEffect menuTheme;
        private Song menuTheme;

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
            // TODO: Add your initialization logic here
            //initializes the super global variable
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        private void HideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.Hide();
                }
            }
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

            //instantiate scenes
            startScene = new StartScene(this, spriteBatch);

            //backgrounds and images
            startBackground = Content.Load<Texture2D>("images/background");
            title = Content.Load<Texture2D>("images/title");

            //positions
            titlePos = new Vector2(Shared.stage.X /2  - title.Width / 2, 50);

            //sounds
            menuTheme = Content.Load<Song>("sounds/menuTheme");
            MediaPlayer.Play(menuTheme);
            MediaPlayer.IsRepeating = true;

            Components.Add(startScene);

            //enable only one start scene
            startScene.Show();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        //public void PlayMusic()
        //{
        //    if(startScene.Enabled)
        //    {
        //        MediaPlayer.IsRepeating = true;
        //        MediaPlayer.Play(menuTheme);
        //    }
        //}

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            

            if(startScene.Enabled)
            {
                spriteBatch.Draw(startBackground, Vector2.Zero, Color.White);
                spriteBatch.Draw(title, titlePos, Color.White);

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
