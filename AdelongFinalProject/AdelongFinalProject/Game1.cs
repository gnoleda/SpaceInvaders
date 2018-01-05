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
        private ActionScene actionScene;
        private AboutScene aboutScene;
        private HelpScene helpScene;

        private Texture2D startBackground, actionBackground, helpBackground;
        private Song menuTheme, actionTheme;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
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
            actionScene = new ActionScene(this, spriteBatch);
            aboutScene = new AboutScene(this, spriteBatch);
            helpScene = new HelpScene(this, spriteBatch);

            //backgrounds and images
            startBackground = Content.Load<Texture2D>("images/background");
            actionBackground = Content.Load<Texture2D>("images/actionBackground");
            helpBackground = Content.Load<Texture2D>("images/helpBackground");

            //sounds
            menuTheme = Content.Load<Song>("sounds/menuTheme");
            actionTheme = Content.Load<Song>("sounds/actionTheme");

            Components.Add(startScene);
            Components.Add(actionScene);
            Components.Add(aboutScene);
            Components.Add(helpScene);

            //enable only one start scene
            startScene.Show();
            StartMusic();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public void StartMusic()
        {
            if(startScene.Enabled || aboutScene.Enabled || helpScene.Enabled)
            {
                MediaPlayer.Play(menuTheme);
            }
            else if (actionScene.Enabled)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(actionTheme);
            }

            MediaPlayer.IsRepeating = true;
        }


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
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if(startScene.Enabled)
            {
                //check which menu item selected
                selectedIndex = startScene.Menu.SelectedIndex;

                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    actionScene.Show();
                    StartMusic();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.Show();
                    StartMusic();
                }
                else if(selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    aboutScene.Show();
                    StartMusic();
                }
                else if(selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            if (startScene.Enabled && ks.IsKeyDown(Keys.Escape))
            {
                HideAllScenes();
                startScene.Show();
            }
            if (ks.IsKeyDown(Keys.Escape) && !startScene.Enabled)
            {
                HideAllScenes();
                startScene.Show();
                StartMusic();
            }
            

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
            }
            else if (actionScene.Enabled)
            {
                spriteBatch.Draw(actionBackground, Vector2.Zero, Color.White);
            }
            else if (aboutScene.Enabled)
            {
                spriteBatch.Draw(startBackground, Vector2.Zero, Color.White);
            }
            else if (helpScene.Enabled)
            {
                spriteBatch.Draw(helpBackground, Vector2.Zero, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
