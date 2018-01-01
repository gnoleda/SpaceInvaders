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
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SimpleString aboutString;

        public AboutScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/menuFont");

            aboutString = new SimpleString(game, spriteBatch, regularFont);

            this.Components.Add(aboutString);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
