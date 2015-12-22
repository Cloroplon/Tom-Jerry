using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TomAndJerry.Factories;
using TomAndJerry.Interfaces;
using TomAndJerry.Objects.Characters;
using TomAndJerry.Objects.Items.Bonuses;
using TomAndJerry.Objects.Items.Consumables;
using TomAndJerry.Objects.Items.Weapons;


namespace TomAndJerry.States
{
    public class GameState : State
    {
        // here we will store all the objects we currently have and in the game we will just update all of the objects and the background picture.
        public static List<GameObject> gameObjects;
        private FruitFactory fruitFactory;
        private BonusFactory bonusFactory;
        // our counter so we can slow the creation of fruits
        private int creatorCounterPoints;
        private int creatorCounterMax = 120; 


        public Jerry Player;
        public Tom Tom;

        // this will show us when we are in tom mode
        private bool tomMode = false;

        // for random objects
        private Random random;

        public static int points = 0;
        public static double secondsLeft = 60;

        // position of text at background.
        Vector2 scorePosition = new Vector2(100, 100);
        Vector2 timePosition = new Vector2(400, 100);

        public GameState()
        {
            gameObjects = new List<GameObject>();
            random = new Random();
            fruitFactory = new FruitFactory();
            bonusFactory = new BonusFactory();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            // Jerry Load
            XMLManager<Jerry> xmlManagerPlayer = new XMLManager<Jerry>();
            Player = xmlManagerPlayer.Load("../../../Load/Player.xml");
            Player.LoadContent();
            // Tom Load
            XMLManager<Tom> xmlManagerTom = new XMLManager<Tom>();
            Tom = xmlManagerTom.Load("../../../Load/Tom.xml");
            Tom.LoadContent();

            foreach (var gameObject in gameObjects)
            {
                gameObject.LoadContent();
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            Player.UnloadContent();
            foreach (var gameObject in gameObjects)
            {
                gameObject.UnloadContent();
            }
            Tom.UnloadContent();
        }
        #region Update()
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            secondsLeft -= gameTime.ElapsedGameTime.TotalSeconds;
            if (secondsLeft <= 30)
            {
                tomMode = true;
                creatorCounterMax = 150; // we are slowing the creation of fruit because the main part in this mode is the bombs.
                if (secondsLeft < 15)
                {
                    tomMode = false;
                    creatorCounterMax = 120; // we re reversing to initial value
                }
            }

            Player.Update(gameTime);

            if (tomMode)
            {
                Tom.Update(gameTime);

            }
            CreatingFruits();
            UpdatingObects(gameTime);
            RemovingObects();
            CheckingTimeClock();

        }

        private void CheckingTimeClock()
        {
            if (secondsLeft <= 0 && !Game1.StateManager.IsTransioning)
            {
                secondsLeft = 0;
                Game1.StateManager.ChangeStates("GameOverState");
            }
        }

        private void UpdatingObects(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
                if (gameObject is Bomb)
                {
                    Bomb bomb = gameObject as Bomb;
                    if (bomb.Exploded && PlayerIsHit(bomb))
                    {
                        Player.IsHit = true;
                        Player.IsMoving = false;
                        Player.IsIdle = false;
                        points -= 10;
                    }
                }
                else
                {
                    // checking if the image is in the sam position as the basket image.
                    if ((gameObject.Image.Position.Y > this.Player.Basket.Image.Position.Y - 10 &&
                         gameObject.Image.Position.Y < this.Player.Basket.Image.Position.Y + 7) && (
                             gameObject.Image.Position.X > this.Player.Basket.Image.Position.X - 15 &&
                             gameObject.Image.Position.X < this.Player.Basket.Image.Position.X + 25))
                    {
                        Player.PutInBasket(gameObject);
                    }
                }
            }
        }

        private bool PlayerIsHit(Bomb bomb)
        {
            // we must take the two ends of X position of player and bomb so we can compare and make a suggestion that player is hit by the bomb.
            float bombLefEnd = bomb.ExplodeImage.Position.X;
            float bombRightEnd = bombLefEnd + 50; // 50 is width of the drawing.
            float playerLeftEnd = Player.Image.Position.X;
            float playerRightEnd;
            // we have different image width for his states
            if (Player.IsMoving)
            {
                playerRightEnd = playerLeftEnd + 80;
            }
            else
            {
                playerRightEnd = playerLeftEnd + 65;
            }
            return (bombLefEnd < playerRightEnd && bombLefEnd > playerLeftEnd) ||
                               (bombRightEnd > playerLeftEnd && bombRightEnd < playerRightEnd);
        }

        private void RemovingObects()
        {
            // we are creating a new list because otherwise when an item from the list is removed while we are in foreach an exception is thrown.
            List<GameObject> objectsAfterRemoval = new List<GameObject>();
            foreach (var gameObject in gameObjects)
            {
                if (!gameObject.MustRemove)
                {
                    objectsAfterRemoval.Add(gameObject);
                }
            }
            gameObjects = objectsAfterRemoval;
        }

        private void CreatingFruits()
        {
            creatorCounterPoints++;
            // this is around 4 seconds.
            if (creatorCounterPoints == creatorCounterMax)
            {
                creatorCounterPoints = 0;
                // we need to think where to put Tom and the state of bombing. I guess with a boolean bombing and every 30 seconds or so to make it true and if it is not bombing to do this below if it is bombing we are going to run another code. 
                if (random.Next(10) > 8)
                {
                    Bonus timeBonus = bonusFactory.CreateBonus("TimeBonus");
                    timeBonus.LoadContent();
                    gameObjects.Add(timeBonus);
                }
                else
                {
                    // fruit
                    switch (random.Next(6))
                    {

                        case 0:
                            Consumable fruitStrawberry = fruitFactory.CreateFruit("Strawberry");
                            fruitStrawberry.LoadContent();
                            gameObjects.Add(fruitStrawberry);
                            break;
                        case 1:
                            Consumable fruitCherry = fruitFactory.CreateFruit("Cherry");
                            fruitCherry.LoadContent();
                            gameObjects.Add(fruitCherry);
                            break;
                        case 2:
                            Consumable fruitCheese = fruitFactory.CreateFruit("Cheese");
                            fruitCheese.LoadContent();
                            gameObjects.Add(fruitCheese);
                            break;
                        case 3:
                            Consumable fruitCake = fruitFactory.CreateFruit("Cake");
                            fruitCake.LoadContent();
                            gameObjects.Add(fruitCake);
                            break;
                        case 4:
                            Consumable fruitMuffin = fruitFactory.CreateFruit("Muffin");
                            fruitMuffin.LoadContent();
                            gameObjects.Add(fruitMuffin);
                            break;
                        case 5:
                            Consumable fruitSalami = fruitFactory.CreateFruit("Salami");
                            fruitSalami.LoadContent();
                            gameObjects.Add(fruitSalami);
                            break;
                        default: break;
                    }
                }
            }
        }
#endregion
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(this.Image.Font, $"Score: {points}", scorePosition, Color.White);
            spriteBatch.DrawString(this.Image.Font, $"Time left: {secondsLeft:f2}", timePosition, Color.White);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            Player.Draw(spriteBatch);
            if (tomMode)
            {
                Tom.Draw(spriteBatch);
            }
        }

    }
}
