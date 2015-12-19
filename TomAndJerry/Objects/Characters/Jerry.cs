using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TomAndJerry.Interfaces;
using TomAndJerry.Objects.Items;
using TomAndJerry.Objects.Items.Consumables;
using TomAndJerry.States;

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
        // we need Jerry to hold a basket so we can say the when the fruits on a position as his basket he puts them inside.
        private Basket basket;
        // properties for drawing
             
        public const int FrameWidth= 65;
        public const int FrameWidthMoving = 80;
        public const int FrameWidthHit = 65;

        public Jerry() : base()
        {
            this.Velocity = Vector2.Zero;
            this.IsIdle = true;
            this.basket = new Basket();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.basket.LoadContent();
            
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
            if (this.Image.Position.X < 0)
            {
                this.Image.Position.X = 0;
            }
            else if (this.Image.Position.X > 590)
            {
                this.Image.Position.X = 590;
            }
            // this magic numbers are added to satisfy our needs
            this.basket.Image.Position.X = this.Image.Position.X + 25;
            this.basket.Image.Position.Y = this.Image.Position.Y + 10;
            this.basket.Update(gameTime);
            // here we re checing the position of the basket with every fruit in the game and if the coordinates match we put the fruit in the basket.
            PutInBasket();
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
                // for the original Jerry 129 is FrameWithMoving
                Image.SourceRectangle = new Rectangle(129, 0, FrameWidth, Image.Texture.Height);
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
            this.basket.Draw(spriteBatch);
        }

        // it is Jerry's responsibility to put the objects in the basket that is why this method is here and not in GameState.
        public void PutInBasket()
        {
            foreach (var gameObject in GameState.gameObjects)
            {
                // this is used only for the fruits. It can serve us for bonuses as well. 
                if (gameObject is Consumable)
                {
                    // checking if the image is in the sam position as the basket image.
                    if ((gameObject.Image.Position.Y > this.basket.Image.Position.Y - 2 && gameObject.Image.Position.Y < this.basket.Image.Position.Y + 2) && (
                    gameObject.Image.Position.X > this.basket.Image.Position.X - 10 && gameObject.Image.Position.X < this.basket.Image.Position.X + 25))
                    {
                        // we don't have access to the points of the fruit if we do not cast it to consumable first
                        var fruitConsumed = gameObject as Consumable;
                        GameState.Points += fruitConsumed.Points;
                        fruitConsumed.MustRemove = true;

                        this.basket.ContainsFruit = true;
                    }
                }
            }
            

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
