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
    public class Tank : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Vector2 pos;
        Vector2 speed;
        Texture2D tex;

        public Tank(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            //pos = new Vector2(Shared.stage.X / 2 - tex.Width /2, 0);
            //pos = new Vector2(Shared.stage.X - tex.Width / 2, Shared.stage.Y - tex.Height);
            pos = new Vector2(0, 0);
            speed = new Vector2(4,0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, pos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
