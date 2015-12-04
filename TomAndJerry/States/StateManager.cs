using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// This is our StateManager class he is controlling and holding our current state and through it we are going to access every state in the game. 
/// </summary>
namespace TomAndJerry.States
{
    static class StateManager
    {
        static private State currentState;
        
        static public void LoadContent(ContentManager contentManager)
        {
            currentState.LoadContent(contentManager);
        }

       static public void UnloadContent()
        {
            
        }

       static public void Draw(SpriteBatch spriteBatch)
        {
           
            currentState.Draw(spriteBatch);
            
        }

       static public void Update(GameTime gameTime)
        {
            
        }

        public static State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }
}
