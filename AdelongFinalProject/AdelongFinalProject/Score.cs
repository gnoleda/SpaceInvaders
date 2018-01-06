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

        public Score(Game game,
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
            color = Color.Red;
        }

        public override void Update(GameTime gameTime)
        {
            //laser collision with alien
            //to update score
            if (Shared.laserList != null)
            {
                for (int i = 0; i < Shared.laserList.Count; i++)
                {
                    if (Shared.laserList[i].Enabled)
                    {
                        for (int j = 0; j < Shared.alienList.Count; j++)
                        {
                            if (Shared.alienList[j].Enabled)
                            {
                                if (Shared.laserList[i].getBound().Intersects(Shared.alienList[j].getBound()))
                                {
                                    Shared.scoreValue += 10;
                                    this.Value = "SCORE: " + Shared.scoreValue;
                                }
                            }

                        }
                    }

                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(spriteFont, Value, Position, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

}


