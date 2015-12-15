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

namespace TomAndJerry.States
{
    public class GameState : State
    {
        // here we will store all the objects we currently have and in the game we will just update all of the objects and the background picture.
        public static List<GameObjects> gameObjects;

        public Jerry Player;

        public GameState()
        {
            gameObjects = new List<GameObjects>();
            
        }

        public override void LoadContent()
        {
            base.LoadContent();
            XMLManager<Jerry> xmlManager = new XMLManager<Jerry>();
            Player = xmlManager.Load("../../../Load/Player.xml");
            // this is the image inherited from State. 
            Image.LoadContent();
            Player.LoadContent();
            foreach (var gameObject in gameObjects)
            {
                gameObject.LoadContent();
            }
         }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
            Player.UnloadContent();
            foreach (var gameObject in gameObjects)
            {
                gameObject.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);
            Player.Update(gameTime);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Image.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

    }
}
