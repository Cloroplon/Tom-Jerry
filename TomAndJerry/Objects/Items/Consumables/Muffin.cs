using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Items.Consumables
{
    public class Muffin:Consumable
    {
        public Muffin()
        {
            this.MoveSpeed = 100;
            this.Points = 25;
            this.Image = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "muffin";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(0, 10, 27, 30);
            base.LoadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Velocity = new Vector2(Velocity.X, MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            this.Image.Update(gameTime);
            this.Image.Position += this.Velocity;
        }
    }
}
