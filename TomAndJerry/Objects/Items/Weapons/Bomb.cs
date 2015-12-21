using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Items.Weapons
{
    public class Bomb : Weapon, IMovable
    {

        public bool Exploded { get; set; }
        public Vector2 Velocity { get; set; }
        public float MoveSpeed { get; set; }
        public Image ExplodeImage { get; set; }
        public bool ExplosionFirstTurn { get; private set; }

        public Bomb()
        {
            this.MoveSpeed = 150;
            this.Image = new Image();
            this.ExplodeImage = new Image();
        }

        public override void LoadContent()
        {
            this.Image.Path = "bombs";
            this.Image.Position = new Vector2(new Random().Next(5, 590), 0);
            this.Image.SourceRectangle = new Rectangle(2, 3, 27, 30);
            this.ExplodeImage.Path = "Explosion";
            this.ExplodeImage.LoadContent();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Velocity = new Vector2(Velocity.X, MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if (this.Image.Position.Y >= 400)
            {
                Exploded = true;
                this.ExplodeImage.Position = this.Image.Position;
                this.ExplodeImage.Update(gameTime);
            }
            this.Image.Update(gameTime);
            this.Image.Position += this.Velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Exploded)
            {
                base.Draw(spriteBatch);
            }
            else
            {
                if (ExplosionFirstTurn)
                {
                    this.ExplodeImage.SourceRectangle = new Rectangle(0, 8, 38, 41);
                }
                else
                {
                    this.ExplodeImage.SourceRectangle = new Rectangle(39, 1, 53, 52);
                    this.MustRemove = true;
                }
                ExplosionFirstTurn = false;
                this.ExplodeImage.Draw(spriteBatch);
            }
            
        }
    }
}
