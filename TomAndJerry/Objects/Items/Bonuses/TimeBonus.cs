using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TomAndJerry.States;

namespace TomAndJerry.Objects.Items.Bonuses
{
    public class TimeBonus : Bonus
    {
        private const int secondsToAdd = 5;

        public TimeBonus ()
        {
            this.MoveSpeed = 150;
            this.Image = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "clock";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(0, 4, 29, 26);
            base.LoadContent();
        }

        public override void ExecuteEffect()
        {
            GameState.secondsLeft += secondsToAdd;
        }
    }
}
