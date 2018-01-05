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
    public class Laser : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos;
        private Vector2 speed;

        public Laser(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            pos = new Vector2(Shared.shipPos.X + Shared.shipTex.Width / 2 - tex.Width / 2, Shared.shipPos.Y - tex.Height);
            speed = new Vector2(0, 10);
        }

        public Laser(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = ((Game1)game).Content.Load<Texture2D>("images/shipLaser");
            pos = new Vector2(Shared.shipPos.X + Shared.shipTex.Width / 2 - tex.Width / 2, Shared.shipPos.Y - tex.Height);
            speed = new Vector2(0, 10);
        }

        public virtual void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public virtual void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            
            //if (ks.IsKeyDown(Keys.Space) && this.Enabled) 
          //  {
                pos -= speed;
          //  }
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
