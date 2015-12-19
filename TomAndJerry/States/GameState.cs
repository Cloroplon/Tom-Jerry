using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TomAndJerry.Objects.Characters;
using TomAndJerry.Objects.Items.Consumables;


namespace TomAndJerry.States
{
    public class GameState : State
    {
        // here we will store all the objects we currently have and in the game we will just update all of the objects and the background picture.
        public static List<GameObject> gameObjects;
        // our counter so we can slow the creation of fruits
        private int creatorCounter = 0;
        public Jerry Player;
        // for random objects
        private Random random;
        private FruitFactory fruitFactory;
        public static int Points = 0;

        public GameState()
        {
            gameObjects = new List<GameObject>();
            random = new Random();
            fruitFactory = new FruitFactory();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            XMLManager<Jerry> xmlManager = new XMLManager<Jerry>();
            Player = xmlManager.Load("../../../Load/Player.xml");
            // this is the image inherited from State. 
          
            Player.LoadContent();
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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           
            Player.Update(gameTime);
            CreatingObjects();
            UpdatingObects(gameTime);
            RemovingObects();
        }

        private void UpdatingObects(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
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

        private void CreatingObjects()
        {
            creatorCounter++;
            // this is around 4 seconds.
            if (creatorCounter == 120)
            {
                creatorCounter = 0;
            // we need to think where to put Tom and the state of bombing. I guess with a boolean bombing and every 30 seconds or so to make it true and if it is not bombing to do this below if it is bombing we are going to run another code. 
            if (random.Next(10) > 8)
            {
                // generate a bonus
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
                      
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            Player.Draw(spriteBatch);
        }

    }
}
