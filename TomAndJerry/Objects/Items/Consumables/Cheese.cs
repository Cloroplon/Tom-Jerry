using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Items.Consumables
{
    public class Cheese:Consumable
    {
        public Cheese()
        {
            this.MoveSpeed = 120;
            this.Points = 30;
            this.Image = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "cheese";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(0, 4, 29, 32);
            base.LoadContent();

        }

    }
}
