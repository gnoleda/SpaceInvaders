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
        public static List<Alien> alienList;
    }
}
