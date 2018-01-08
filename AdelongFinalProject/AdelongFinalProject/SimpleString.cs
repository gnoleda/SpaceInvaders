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
        public Vector2 Position { get; set; }
        public string Value { get; set; }

        public SimpleString(Game game,
            SpriteBatch spriteBatch,
            SpriteFont spriteFont,
            Vector2 pos,
            string value
            ) : base(game)

        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            Position = pos;
            Value = value;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(spriteFont, Value, Position, Color.Red);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
