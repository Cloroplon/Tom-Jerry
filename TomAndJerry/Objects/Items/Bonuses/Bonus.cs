using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TomAndJerry.Interfaces;
using TomAndJerry.States;

namespace TomAndJerry.Objects.Items.Bonuses
{
    public abstract class Bonus : Item, IBonus, IMovable
    {

        public Vector2 Velocity { get; set; }
        public float MoveSpeed { get; set; }

        public abstract void ExecuteEffect();

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Velocity = new Vector2(Velocity.X, MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            this.Image.Update(gameTime);
            this.Image.Position += this.Velocity;

            // if the fruit is outside the screen it should be removed in the next delete of objects in gameState.
            if (this.Image.Position.Y > 480)
            {
                this.MustRemove = true;
            }
        }
    }
}
