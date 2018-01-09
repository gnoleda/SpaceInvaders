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

            if (ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            { 
                laserSound.Play();
                Laser l = new Laser(game, spriteBatch, pos);
                l.Show();
                game.Components.Add(l);
                Shared.laserList.Add(l);
            }

            oldState = ks;            

            //if win or lose scene is up, hide lasers
            //if(Shared.winScene.Enabled || Shared.loseScene.Enabled)
            //{
            //    las
            //}

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
