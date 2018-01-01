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
        private Color color;

        public SimpleString(Game game,
            SpriteBatch spriteBatch,
            SpriteFont spriteFont
            ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            pos = new Vector2(Shared.stage.X  / 2, Shared.stage.Y /2); ;
            message = "Made by Aubrey Delong";
            color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(spriteFont, message,pos, color);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
