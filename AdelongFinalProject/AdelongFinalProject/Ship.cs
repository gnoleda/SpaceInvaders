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
    public class Ship : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        //public Vector2 shipPos;
        private Vector2 speed;
        private Texture2D tex;

        public Ship(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            //pos = new Vector2(Shared.stage.X / 2 - tex.Width /2, 0);
            //pos = new Vector2(Shared.stage.X - tex.Width / 2, Shared.stage.Y - tex.Height);
            Shared.shipPos = new Vector2(Shared.stage.X / 2 - tex.Width / 2, Shared.stage.Y - tex.Height);
            speed = new Vector2(4, 0);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                //we add the x and y components of pos and speed together. 
                //because the y variable of speed is 0, the ship never goes up.
                Shared.shipPos += speed;
                if (Shared.shipPos.X > Shared.stage.X - tex.Width)
                {
                    Shared.shipPos.X = Shared.stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                Shared.shipPos -= speed;
                if (Shared.shipPos.X < 0)
                {
                    Shared.shipPos.X = 0;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, Shared.shipPos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
