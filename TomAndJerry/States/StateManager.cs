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
    class StateManager
    {
        private State currentState;
        public static ContentManager Content { private set; get; }
        public static GraphicsDevice GraphicsDevice { set; get; }
        public static SpriteBatch SpriteBatch { set; get; }
        public XMLManager<State> xmlManager;

        public StateManager()
        {
            
            xmlManager = new XMLManager<State>();
            this.CurrentState = new GameState();
            xmlManager.Type = this.currentState.Type;
            this.CurrentState = xmlManager.Load("../../../Load/GameScreen.xml");

        }

        public void LoadContent(ContentManager contentManager)
        {
            Content = contentManager;
            this.CurrentState.LoadContent();
        }

        public void UnloadContent()
        {
            this.CurrentState.UnloadContent();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.CurrentState.Draw(spriteBatch);
            
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentState.Update(gameTime);
        }

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }
}
