using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TomAndJerry.Objects.Items.Consumables
{
    public abstract class Consumable : Item
    {
        public int Points { get; protected set; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // if the fruit is outside the screen it should be removed in the next delete of objects in gameState.
            if (this.Image.Position.Y > 480)
            {
                this.MustRemove = true;
            }
        }
    }
}
