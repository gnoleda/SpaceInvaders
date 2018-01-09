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
    class CollisionManagerShip : GameComponent
    {
        private Alien alien;
        private Ship ship;
        private SoundEffect hitSound;

        public CollisionManagerShip(Game game,
            Alien alien,
            Ship ship,
            SoundEffect hitSound
            ) : base(game)
        {
            this.alien = alien;
            this.ship = ship;
            this.hitSound = hitSound;
        }

        public override void Update(GameTime gameTime)
        {
            //alien collision with ship
            for (int i = 0; i < Shared.alienList.Count; i++)
            {
                if (Shared.alienList[i].Enabled)
                {
                    if (Shared.alienList[i].getBound().Intersects(ship.getBound()))
                    {
                        Shared.isShipDestroyed = true;
                        hitSound.Play();
                        ship.Hide();
                        alien.StopAllAliens();
                    }
                }
            }

            base.Update(gameTime);
        }
    }
}
