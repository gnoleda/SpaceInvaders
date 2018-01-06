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
    public class Shared
    {
        public static Vector2 stage, shipPos, alienSpeed;
        public static Texture2D shipTex, alien1Tex, alien2Tex, alien3Tex;
        public static Vector2  alien1Pos, alien2Pos, alien3Pos;
        public const int ALIEN_SPACING = 2;
        public static List<Rectangle> frames;
        public static List<Laser> laserList;
        public static List<Alien> alienList/*, deadAlienList*/;
        public static int deadAlienCount;
        //public static bool isGameOver;
        public static float scoreValue;
        //public static Vector2 initShipPos = new Vector2(Shared.stage.X / 2 - shipTex.Width / 2, Shared.stage.Y - shipTex.Height);
        //public static Vector2 alien1InitPos =  new Vector2(0, alien1Tex.Height);
        //public static Vector2 alien2InitPos = new Vector2(0, alien1Pos.Y+ alien1Tex.Height + ALIEN_SPACING);
        //public static Vector2 alien3InitPos = new Vector2(0, alien2Pos.Y+ alien1Tex.Height + ALIEN_SPACING);

            //set initial values
        public static void StartLevel1()
        {
            deadAlienCount = 0;
            //isGameOver = false;
            laserList.Clear();
            scoreValue = 0;
            shipPos = new Vector2(stage.X / 2 - shipTex.Width / 2, stage.Y - shipTex.Height);
            alien1Pos = new Vector2(0, Shared.alien1Tex.Height);
            alien2Pos = new Vector2(0, Shared.alien1Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);
            alien3Pos = new Vector2(0, Shared.alien2Pos.Y + Shared.alien1Tex.Height + Shared.ALIEN_SPACING);

        }
    }
}
