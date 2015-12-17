using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TomAndJerry.Interfaces;

namespace TomAndJerry.Objects.Characters
{
    public class Jerry : Character, IMovable
    {
        private Vector2 velocity;

        private float moveSpeed;

        public Jerry() : base()
        {
            this.Velocity = Vector2.Zero;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Image.SpriteSheetEffect.AmountOfFrames = 9; // for every object in the contstructor we must set how many frames does the spritesheet for the objects have.
            this.Image.SpriteSheetEffect.CurrentFrame = 1; // and the frame from which we want our object to start. Jerry's default state is frame 1.
        }

        public override void Update(GameTime gameTime)
        {
            // Jerry will move only to right and left
            base.Update(gameTime);
            if (Game1.InputManager.KeyIsDown(Keys.Left))
            {
                this.Velocity = new Vector2(-MoveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds, Velocity.Y);
            }
            else if (Game1.InputManager.KeyIsDown(Keys.Right))
            {
                this.Velocity = new Vector2(MoveSpeed*(float) gameTime.ElapsedGameTime.TotalSeconds, Velocity.Y);
            }
            else
            {
                this.Velocity = new Vector2(0,0);
            }
            this.Image.Position += this.Velocity;
        }

        public Vector2 Velocity
        {
            get
            {
                return this.velocity;
            }
            set { this.velocity = value; } 
        }

        public float MoveSpeed
        {
            get
            {
                return this.moveSpeed;
            }
            set
            {
                this.moveSpeed = value;
            }
        }
    }
}
