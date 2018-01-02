﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdelongFinalProject
{
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SimpleString helpString1, helpString2, helpString3, helpString4, helpString5, helpString6;
        private string msgTitle, msgHow, msgHow2, msgControls, msgControls2, msgControls3;
        private Vector2 str1Pos, str2Pos, str3Pos, str4Pos, str5Pos, str6Pos;

        public HelpScene(Game game,
            SpriteBatch spriteBatch,
            string message) : base(game)
        {
            this.spriteBatch = spriteBatch;
            msgTitle = "How To Play";
            msgHow = "Destroy all of the aliens before they destroy you.";
            msgControls = "- Use the Right and Left arrow keys to move your ship.";
            msgControls2 = "- Use the Space Bar to shoot lasers at the aliens and destroy them";
            msgControls3 = "- Once all of your lives are used up and the aliens are not yet destroyed, the game is over";
            msgHow2 = "- Return to the main menu at any time by pressing Escape";

            str1Pos = new Vector2(0, 100);

            helpString1 = new SimpleString(game, spriteBatch, str1Pos, msgTitle);
            
            this.Components.Add(helpString1);
            //this.Components.Add(helpString2);
            //this.Components.Add(helpString3);
            //this.Components.Add(helpString4);
            //this.Components.Add(helpString5);
            //this.Components.Add(helpString6);


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
