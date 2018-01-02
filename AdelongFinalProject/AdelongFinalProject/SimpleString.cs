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
    public class SimpleString : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Vector2 pos;
        private string message;
        //private Color color;

        public SimpleString(Game game,
            SpriteBatch spriteBatch,
            Vector2 pos,
            string message
            ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            spriteFont = game.Content.Load<SpriteFont>("fonts/menuFont");
            this.message = message;
            this.pos = pos;
            //color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(spriteFont, message,pos, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
