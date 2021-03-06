﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Items.Consumables
{
    public class Cherry: Consumable
    {
        public Cherry()
        {
            this.MoveSpeed = 90;
            this.Points = 15;
            this.Image = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "cherry";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(0, 4, 20, 32);
            base.LoadContent();

        }


    }
}
