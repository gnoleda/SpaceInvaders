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
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SimpleString aboutString;
        string message;
        private Vector2 pos;

        public AboutScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            message = "Made by Aubrey Delong";
            pos = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
            aboutString = new SimpleString(game, spriteBatch, pos, message);

            this.Components.Add(aboutString);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
