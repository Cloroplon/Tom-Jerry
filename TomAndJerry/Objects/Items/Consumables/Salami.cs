﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Items.Consumables
{
    public class Salami:Consumable
    {
        public Salami()
        {
            this.MoveSpeed = 130;
            this.Points = 25;
            this.Image = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "salami";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(0, 10, 27, 35);
            base.LoadContent();

        }

    }
}
