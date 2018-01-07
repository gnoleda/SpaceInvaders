
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
    class CollisionManager : GameComponent
    {
        private Alien alien;
        private SoundEffect hitSound;
        private Explosion explosion;

        public CollisionManager(Game game,
            Alien alien,
            //Ship ship,
            SoundEffect hitSound,
            Explosion explosion
            ) : base(game)
        {
            this.alien = alien;
            this.hitSound = hitSound;
            this.explosion = explosion;
        }

        public override void Update(GameTime gameTime)
        {

            //laser collision with alien
            if(Shared.laserList != null)
            {
                for (int i = 0; i < Shared.laserList.Count; i++)
                {
                    if(Shared.laserList[i].Enabled)
                    {
                        for (int j = 0; j < Shared.alienList.Count; j++)
                        {
                            if (Shared.alienList[j].Enabled)
                            {
                                if (Shared.laserList[i].getBound().Intersects(Shared.alienList[j].getBound()))
                                {
                                    hitSound.Play();
                                    Shared.deadAlienCount++;
                                    Shared.laserList[i].Hide();
                                    Shared.alienList[j].Hide();
                                    explosion.Position = new Vector2(Shared.alienList[j].getBound().X, Shared.alienList[j].getBound().Y);

                                    explosion.StartAnimation();
                                }
                            }

                        }
                    }

                }
            }            
           
            base.Update(gameTime);
        }
    }
}
