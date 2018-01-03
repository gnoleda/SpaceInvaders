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
    public class Alien : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos;
        private Vector2 speed;

        public Alien(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex
            /*Vector2 speed*/) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            pos = new Vector2(0, 0);
            //this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            //switch images of alien in update..
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
