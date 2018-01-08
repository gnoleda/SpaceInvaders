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
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        public Vector2 Position { get; set; }
        public string Value { get; set; }
        private Color color;
        private float initScore = 0;

        public Score(Game game,
            SpriteBatch spriteBatch,
            SpriteFont spriteFont,
            Vector2 pos
            ) : base(game)

        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            Position = pos;
            Value = "SCORE: " + initScore;
            color = Color.Red;
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


