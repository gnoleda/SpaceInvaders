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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D shipLaserTex, alienExpTex;
        private Ship ship;
        //private Laser shipLaser;
        private Vector2 pos;
        private SoundEffect hitSound;

       // private List<Alien> alienList;
        private const int ROW = 3;
        private const int COL = 5;
        private const int NUM_ALIENS = 5;
        private const int ALIEN1_DELAY = 20;
        private const int ALIEN2_DELAY = 22;
        private const int ALIEN3_DELAY = 24;
        private Game1 game;
        private Explosion alienExplosion;

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
            //shipLaser = new Laser(game, spriteBatch/*, shipLaserTex*/);

            //alien1
            Shared.alien1Tex = game.Content.Load<Texture2D>("images/alien1");
            Shared.alien2Tex = game.Content.Load<Texture2D>("images/alien2");
            Shared.alien3Tex = game.Content.Load<Texture2D>("images/alien3");
            Shared.alienSpeed = new Vector2(1.5f, 0);
            Shared.alienList = new List<Alien>();

            //explosion
            alienExpTex = game.Content.Load<Texture2D>("images/alienExplosion");
            alienExplosion = new Explosion(game, spriteBatch, alienExpTex, Vector2.Zero, 0.1f);
            hitSound = game.Content.Load<SoundEffect>("sounds/invaderkilled");

            //laser list
            Shared.laserList = new List<Laser>();

            this.Components.Add(alienExplosion);
            this.Components.Add(ship);
            //this.Components.Add(shipLaser);
            CreateMultipleAliens();
        }

        public void CreateMultipleAliens()
        {
            //also make multiple collision managers here for each alien.
            Shared.alien1Pos = new Vector2(0, Shared.alien1Tex.Height);
            Shared.alien2Pos = new Vector2(0, Shared.alien1Pos.Y+ Shared.alien1Tex.Height + Shared.ALIEN_SPACING);
            Shared.alien3Pos = new Vector2(0, Shared.alien2Pos.Y+ Shared.alien1Tex.Height + Shared.ALIEN_SPACING);

            //green alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = Shared.alien1Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien1Tex, ALIEN1_DELAY, Shared.alienSpeed);
                a.Show();
                CollisionManager cm = new CollisionManager(game, a, ship, hitSound, alienExplosion );
                this.Components.Add(cm);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien1Pos.X += Shared.ALIEN_SPACING + Shared.alien1Tex.Width;
            }
            //purple alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = Shared.alien2Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien2Tex, ALIEN2_DELAY, Shared.alienSpeed);
                a.Show();
                CollisionManager cm = new CollisionManager(game, a, ship, hitSound, alienExplosion);
                this.Components.Add(cm);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien2Pos.X += Shared.ALIEN_SPACING + Shared.alien2Tex.Width;
            }
            //blue alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = Shared.alien3Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien3Tex, ALIEN3_DELAY, Shared.alienSpeed);
                a.Show();

                CollisionManager cm = new CollisionManager(game, a, ship, hitSound, alienExplosion);
                this.Components.Add(cm);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien3Pos.X += Shared.ALIEN_SPACING + Shared.alien3Tex.Width;
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
