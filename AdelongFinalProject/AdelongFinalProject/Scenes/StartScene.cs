using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdelongFinalProject
{
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }
        private SpriteBatch spriteBatch;

        string[] menuItems =    {"Start Game",
                                "Help",
                                "About",
                                "Quit"};

        public StartScene(Game game, 
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/menuFont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("fonts/hilightFont");
            

            Menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems);

            this.Components.Add(Menu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin();

            spriteBatch.End();
        }
    }
}
