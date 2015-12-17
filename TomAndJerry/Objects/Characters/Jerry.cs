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

        public bool IsMoving { get; set; }

        public bool IsHit { get; set; }

        public bool HasCatchedAFruit { get; set; }

        public bool IsIdle { get; set; }

        // properties for drawing
             
        public const int FrameWidth= 53;
        public const int FrameWidthMoving = 80;
        public const int FrameWidthHit = 45;

        public Jerry() : base()
        {
            this.Velocity = Vector2.Zero;
            this.IsIdle = true;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            
        }

        public override void Update(GameTime gameTime)
        {
            // Jerry will move only to right and left
            base.Update(gameTime);
            if (Game1.InputManager.KeyIsDown(Keys.Left))
            {
                this.Velocity = new Vector2(-MoveSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds, Velocity.Y);
                this.IsMoving = true;
                this.IsIdle = false;
             }
            else if (Game1.InputManager.KeyIsDown(Keys.Right))
            {
                this.Velocity = new Vector2(MoveSpeed*(float) gameTime.ElapsedGameTime.TotalSeconds, Velocity.Y);
                this.IsMoving = true;
                this.IsIdle = false;
            }
            else
            {
                this.Velocity = new Vector2(0,0);
                this.IsMoving = false;
                this.IsIdle = true;
            }

            this.Image.Update(gameTime);
            this.Image.Position += this.Velocity;
            if (this.Image.Position.X < 5)
            {
                this.Image.Position.X = 5;
            }
            else if (this.Image.Position.X > 595)
            {
                this.Image.Position.X = 595;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsMoving)
            {
                // the coordinates of the pic for running
                Image.SourceRectangle = new Rectangle(0, 0, FrameWidthMoving, Image.Texture.Height);
            }
            else if(IsIdle)
            {
                Image.SourceRectangle = new Rectangle(FrameWidthMoving, 0, FrameWidth, Image.Texture.Height);
            }
            else if(HasCatchedAFruit)
            {
                // 238 is the position of the pic we want to take after Jerry has catched a fruit
                Image.SourceRectangle = new Rectangle(238, 0, FrameWidth, Image.Texture.Height);
            }
            else if(IsHit)
            {
                // 393 is the position of the pic we want to take after Jerry has been hit
                Image.SourceRectangle = new Rectangle(393, 0, FrameWidthHit, Image.Texture.Height);
            }
            Image.Draw(spriteBatch);
        }

        // PROPERTIES

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
