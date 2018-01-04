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
        private Vector2 pos, alien1Pos, alien2Pos, alien3Pos;
        private const int NUM_ALIENS = 5;
        private const int ALIEN_SPACING = 5;
        private const int ALIEN1_DELAY = 20;
        private const int ALIEN2_DELAY = 22;
        private const int ALIEN3_DELAY = 24;
        private Game1 game;
        //private Alien alien1;
        //private int delay = 20;

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
            Shared.alien2Tex = game.Content.Load<Texture2D>("images/alien2");
            Shared.alien3Tex = game.Content.Load<Texture2D>("images/alien3");

            this.Components.Add(ship);
            this.Components.Add(shipLaser);
            CreateMultipleAliens();
        }

        public void CreateMultipleAliens()
        {
            //also make multiple collision managers here for each alien.
            alien1Pos = new Vector2(0, Shared.alien1Tex.Height);
            alien2Pos = new Vector2(0, alien1Pos.Y+ Shared.alien1Tex.Height + ALIEN_SPACING);
            alien3Pos = new Vector2(0, alien2Pos.Y+ Shared.alien1Tex.Height + ALIEN_SPACING);

            //green alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = alien1Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien1Tex, ALIEN1_DELAY);
                a.Show();
                this.Components.Add(a);

                alien1Pos.X += ALIEN_SPACING + Shared.alien1Tex.Width;
            }
            //purple alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = alien2Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien2Tex, ALIEN2_DELAY);
                a.Show();
                this.Components.Add(a);

                alien2Pos.X += ALIEN_SPACING + Shared.alien2Tex.Width;
            }
            //blue alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = alien3Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien3Tex, ALIEN3_DELAY);
                a.Show();
                this.Components.Add(a);

                alien3Pos.X += ALIEN_SPACING + Shared.alien3Tex.Width;
            }
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
