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
        private Vector2 dimension;
        //private Game1 game;

        private List<Rectangle> frames;
        private List<Texture2D> aliens;

        //create frames
        private int frameIndex = 0;
        private const int ROW = 1;
        private const int COL = 2;
        private int delay;
        private int delayCounter;

        public Alien(Game game,
            SpriteBatch spriteBatch,
            Vector2 pos,
            Texture2D tex,
            int delay
            /*Vector2 speed*/) : base(game)
        {
            //this.game = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.pos = pos;
            this.tex = tex;
            this.delay = delay;            
            //this.speed = speed;
            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);
            
            this.startAnimation();
            CreateFrames();

        }
        public void startAnimation()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        //public void stopAnimation()
        //{
        //    this.Enabled = false;
        //    this.Visible = false;
        //}
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

        private void CreateFrames()
        {
            frames = new List<Rectangle>();

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = j * (int)dimension.X; //for ex. 3(row)*64 = 192
                    int y = i * (int)dimension.Y;//for ex.1(col)*64 = 64 
                    //creates the rectangle:
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    //add to the frames
                    frames.Add(r);
                }
            }
        }
        //}

        public override void Update(GameTime gameTime)
        {
            //switch images of alien in update..
            delayCounter++;
            if(delayCounter > delay)
            {
                //change frames
                frameIndex++;
                if (frameIndex > ROW * COL - 1)//if it reaches the highest index, it stops itself
                {
                    frameIndex = 0;
                    //frameIndex = -1; //designates its not a valid index
                    //stopAnimation();
                }
                delayCounter = 0;

                ////change positions
                ////it hits left side
                //if(pos.X <= Shared.stage.X)
                //{
                //    pos = new Vector2()
                //}
                //pos = new Vector2(pos.X+5, pos.Y)
                ////check to see if you hit wall..
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, pos, frames[frameIndex],Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
