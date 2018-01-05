﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace AdelongFinalProject
{
    public class Explosion : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 Position { get; set; }
        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private float delay;
        private int delayCounter;

        private const int ROW = 3;
        private const int COL = 6;

        public Explosion(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            float delay) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;

            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);
            //stop/disable animation
            this.StopAnimation();

            //create frames
            CreateFrames();
        }

        public void StartAnimation()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void StopAnimation()
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
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y,
                        (int)dimension.X, (int)dimension.Y);

                    frames.Add(r);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > ROW * COL - 1)
                {
                    frameIndex = -1;
                    StopAnimation();
                }
                delayCounter = 0;
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();
                //version 4
                spriteBatch.Draw(tex, Position, frames[frameIndex], Color.White);

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
