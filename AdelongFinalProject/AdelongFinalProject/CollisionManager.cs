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
    class CollisionManager : GameComponent
    {
        private Alien alien;
        private Ship ship;
        private Laser laser;
        //private SoundEffect hitSound;
        private Explosion explosion;

        public CollisionManager(Game game,
            Alien alien,
            Ship ship,
            Laser laser,
            //SoundEffect hitSound,
            Explosion explosion
            ) : base(game)
        {
            this.alien = alien;
            this.ship = ship;
            this.laser = laser;
            //this.hitSound = hitSound;
            this.explosion = explosion;
        }

        public override void Update(GameTime gameTime)
        {
            if (alien.getBound().Intersects(ship.getBound()))
            {
                //game over!!
            }

            if (laser.getBound().Intersects(alien.getBound()))
            {
                alien.Hide();
                laser.Hide();
                //hitSound.Play();
                explosion.Position = new Vector2(alien.getBound().X, alien.getBound().Y);
                explosion.startAnimation();
            }
            base.Update(gameTime);
        }
    }
}
