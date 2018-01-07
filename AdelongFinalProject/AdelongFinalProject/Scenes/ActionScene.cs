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
        private Texture2D shipLaserTex, alienExpTex, shipExpTex;
        private Ship ship;
        private Vector2 pos, shipPos;
        private SoundEffect hitSound, shipHitSound;
        KeyboardState ks = Keyboard.GetState();

        // private List<Alien> alienList;
        private const int ROW = 3;
        private const int COL = 5;
        private const int NUM_ALIENS = 5;
        private const int NUM_ALIENS_L2 = 8;
        private const int ALIEN1_DELAY = 20;
        private const int ALIEN2_DELAY = 22;
        private const int ALIEN3_DELAY = 24;
        private Game1 game;
        private Explosion alienExplosion;
        //private ExplosionShip shipExplosion;

        //score
        private Score score;
        private SpriteFont scoreFont;
        private float scoreNew = 0;
        private Vector2 scorePos;

        public ActionScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            //ship
            Shared.shipTex = game.Content.Load<Texture2D>("images/tank");
            shipPos = new Vector2(Shared.stage.X / 2 - Shared.shipTex.Width / 2, Shared.stage.Y - Shared.shipTex.Height);
            ship = new Ship(game, spriteBatch, Shared.shipTex, shipPos);
            shipLaserTex = game.Content.Load<Texture2D>("images/shipLaser");

            //score
            scorePos = new Vector2(10, 2);
            scoreFont = game.Content.Load<SpriteFont>("fonts/scoreFont");
            score = new Score(game, spriteBatch, scoreFont, scorePos/*, scoreString*/);

            //alien1
            Shared.alien1Tex = game.Content.Load<Texture2D>("images/alien1");
            Shared.alien2Tex = game.Content.Load<Texture2D>("images/alien2");
            Shared.alien3Tex = game.Content.Load<Texture2D>("images/alien3");
            Shared.alienSpeed = new Vector2(2.5f, 0);
            Shared.alienList = new List<Alien>();

            //explosion
            alienExpTex = game.Content.Load<Texture2D>("images/alienExplosion");
            shipExpTex = game.Content.Load<Texture2D>("images/shipExplosion");
            hitSound = game.Content.Load<SoundEffect>("sounds/invaderkilled");
            shipHitSound = game.Content.Load<SoundEffect>("sounds/shipHitSound");
            alienExplosion = new Explosion(game, spriteBatch, alienExpTex, Vector2.Zero, 0.1f);

            //laser list
            Shared.laserList = new List<Laser>();

            CreateMultipleAliens();
            this.Components.Add(ship);
            this.Components.Add(score);
            this.Components.Add(alienExplosion);

        }

        public void CreateLevel2Aliens()
        {
            //first delete exisiting aliens
            if (Shared.alienList != null)
            {
                for (int i = 0; i < Shared.alienList.Count; i++)
                {
                    Shared.alienList[i].Hide();
                }
                Shared.deadAlienCount = 0;
            }

            //also make multiple collision managers here for each alien.
            Shared.alien1Pos = new Vector2(0, Shared.alien1Tex.Height);
            Shared.alien2Pos = new Vector2(0, Shared.alien1Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);
            Shared.alien3Pos = new Vector2(0, Shared.alien2Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);

            //changed spped
            Shared.alienSpeed = new Vector2(4f, 0);

            //green alien
            for (int i = 0; i < NUM_ALIENS_L2; i++)
            {
                pos = Shared.alien1Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien1Tex, ALIEN1_DELAY, Shared.alienSpeed);
                a.Show();
                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien1Pos.X += Shared.ALIEN_SPACING + Shared.alien1Tex.Width;
            }
            //purple alien
            for (int i = 0; i < NUM_ALIENS_L2; i++)
            {
                pos = Shared.alien2Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien2Tex, ALIEN2_DELAY, Shared.alienSpeed);
                a.Show();
                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien2Pos.X += Shared.ALIEN_SPACING + Shared.alien2Tex.Width;
            }
            //blue alien
            for (int i = 0; i < NUM_ALIENS_L2; i++)
            {
                pos = Shared.alien3Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien3Tex, ALIEN3_DELAY, Shared.alienSpeed);
                a.Show();

                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien3Pos.X += Shared.ALIEN_SPACING + Shared.alien3Tex.Width;
            }
        }

        public void CreateMultipleAliens()
        {
            //first delete exisiting aliens
            if (Shared.alienList != null)
            {
                for (int i = 0; i < Shared.alienList.Count; i++)
                {
                    Shared.alienList[i].Hide();
                }
                Shared.deadAlienCount = 0;
            }

            //also make multiple collision managers here for each alien.
            Shared.alien1Pos = new Vector2(0, Shared.alien1Tex.Height);
            Shared.alien2Pos = new Vector2(0, Shared.alien1Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);
            Shared.alien3Pos = new Vector2(0, Shared.alien2Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);

            //green alien
            for (int i = 0; i < NUM_ALIENS; i++)
            {
                pos = Shared.alien1Pos;

                Alien a = new Alien(game, spriteBatch, pos, Shared.alien1Tex, ALIEN1_DELAY, Shared.alienSpeed);
                a.Show();
                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
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
                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
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

                CollisionManager cm = new CollisionManager(game, a, hitSound, alienExplosion);
                CollisionManagerShip cmShip = new CollisionManagerShip(game, a, ship, shipHitSound/*, shipExplosion*/);

                this.Components.Add(cm);
                this.Components.Add(cmShip);
                this.Components.Add(a);
                Shared.alienList.Add(a);

                Shared.alien3Pos.X += Shared.ALIEN_SPACING + Shared.alien3Tex.Width;
            }
        }

        public void UpdateScore()
        {
            if (Shared.laserList != null)
            {
                for (int i = 0; i < Shared.laserList.Count; i++)
                {
                    if (Shared.laserList[i].Enabled)
                    {
                        for (int j = 0; j < Shared.alienList.Count; j++)
                        {
                            if (Shared.alienList[j].Enabled)
                            {
                                if (Shared.laserList[i].getBound().Intersects(Shared.alienList[j].getBound()))
                                {
                                    scoreNew += 10;
                                    score.Value = "SCORE: " + scoreNew;
                                }
                            }

                        }
                    }

                }
            }
        }       

        public void UpdateShipPos()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                //we add the x and y components of pos and speed together. 
                //because the y variable of speed is 0, the ship never goes up.
                ship.pos += ship.speed;
                if (ship.pos.X > Shared.stage.X - Shared.shipTex.Width)
                {
                    ship.pos.X = Shared.stage.X - Shared.shipTex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                ship.pos -= ship.speed;
                if (ship.pos.X < 0)
                {
                    ship.pos.X = 0;
                }
            }
        }

        public void Level2()
        {
            //reset ship pos
            ship.pos = new Vector2(Shared.stage.X / 2 - Shared.shipTex.Width / 2, Shared.stage.Y - Shared.shipTex.Height);

            Shared.deadAlienCount = 0;

            CreateLevel2Aliens();

        }

        public void ResetValuesToLevel1() //referenced by game1
        {
            //reset score
            int initScore = 0;
            score.Value = "SCORE: " + initScore;
            scoreNew = 0;

            //reset ship pos
            ship.pos = new Vector2(Shared.stage.X / 2 - Shared.shipTex.Width / 2, Shared.stage.Y - Shared.shipTex.Height);

            //reset aliens
            CreateMultipleAliens();
        }

        public override void Update(GameTime gameTime)
        {
            //update ship position with user input
            UpdateShipPos();

            //checkscore
            UpdateScore();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
