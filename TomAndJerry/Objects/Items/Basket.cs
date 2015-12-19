using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.Objects.Items
{
    public class Basket : Item
    {
        public bool ContainsFruit { get; set; }

        public Basket()
        {
            this.Image = new Image();
            ContainsFruit = false;
        }

        public override void LoadContent()
        {
            this.Image.Path = "Basket";
            base.LoadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!ContainsFruit)
            {
                // the coordinte are taken manually from the pic
                this.Image.SourceRectangle = new Rectangle(6, 11, 40, 19 );
                this.Image.Position.Y += 6;
            }
            else
            {
                this.Image.SourceRectangle = new Rectangle(52, 3, 48, 28);
                
            }
            this.Image.Draw(spriteBatch);
        }
    }
}
