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
        public static Vector2  alienSpeed;
        public static Vector2 stage;
        public static Texture2D shipTex, alien1Tex, alien2Tex, alien3Tex, alien4Tex;
        public static Vector2  alien1Pos, alien2Pos, alien3Pos, alien4Pos;
        public const int ALIEN_SPACING = 2;
        public const int TOTAL_ALIENS = 15;
        public const int TOTAL_ALIENS_L2 = 24;

        public static List<Rectangle> frames;
        public static List<Laser> laserList;
        public static List<Alien> alienList;
        public static int deadAlienCount, deadAlienCountLevel2;
        public static bool isShipDestroyed;
        public static float scoreValue;
        public static bool isLevel2 = false;
    }
}
