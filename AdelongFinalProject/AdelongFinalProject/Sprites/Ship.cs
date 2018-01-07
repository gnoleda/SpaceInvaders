using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace AdelongFinalProject
{
    public class Ship : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public Vector2 pos;
        public Vector2 speed;
        private Texture2D tex;
        private Game1 game;
        private SoundEffect laserSound;
        private KeyboardState oldState;

        public Ship(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 shipPos
            ) : base(game)
        {
            this.game = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = shipPos;
           // this.pos = shipPos;
            //Shared.shipPos = new Vector2(Shared.stage.X / 2 - tex.Width / 2, Shared.stage.Y - tex.Height);
            speed = new Vector2(4, 0);
            laserSound = game.Content.Load<SoundEffect>("sounds/shoot");
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
            //if (ks.IsKeyDown(Keys.Right))
            //{
            //    //we add the x and y components of pos and speed together. 
            //    //because the y variable of speed is 0, the ship never goes up.
            //    pos += speed;
            //    if (pos.X > Shared.stage.X - tex.Width)
            //    {
            //        pos.X = Shared.stage.X - tex.Width;
            //    }
            //}
            //if (ks.IsKeyDown(Keys.Left))
            //{
            //    pos -= speed;
            //    if (pos.X < 0)
            //    {
            //        pos.X = 0;
            //    }
            //}

            if (ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                laserSound.Play();
                Laser l = new Laser(game, spriteBatch, pos);
                l.Show();
                game.Components.Add(l);
                Shared.laserList.Add(l);
            }

            oldState = ks;
            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, /*Shared.shipPos*/pos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
