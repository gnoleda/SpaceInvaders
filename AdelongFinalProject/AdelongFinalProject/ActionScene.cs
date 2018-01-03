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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D shipLaserTex;
        private Ship ship;
        private Laser shipLaser;
        private Alien alien1;

        public ActionScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            
            //ship
            Shared.shipTex = game.Content.Load<Texture2D>("images/tank");
            ship = new Ship(game, spriteBatch, Shared.shipTex);
            shipLaserTex = game.Content.Load<Texture2D>("images/shipLaser");
            shipLaser = new Laser(game, spriteBatch, shipLaserTex);

            //alien1
            Shared.alien1Tex = game.Content.Load<Texture2D>("images/alien1");
            alien1 = new Alien(game, spriteBatch, Shared.alien1Tex);

            this.Components.Add(ship);
            this.Components.Add(shipLaser);
            this.Components.Add(alien1);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            shipLaser.Hide();

            if(ks.IsKeyDown(Keys.Space))
            {
                shipLaser.Show();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
