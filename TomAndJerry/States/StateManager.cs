using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// This is our StateManager class he is controlling and holding our current state and through it we are going to access every state in the game. 
/// </summary>
namespace TomAndJerry.States
{
    public class StateManager
    {
        private State currentState, nextState;
        [XmlIgnore]
        public static ContentManager Content { private set; get; }
        [XmlIgnore]
        public static GraphicsDevice GraphicsDevice { set; get; }
        [XmlIgnore]
        public static SpriteBatch SpriteBatch { set; get; }
        public XMLManager<State> xmlManager;

        // The idea is this is image to be used for the transition face. It is a small 1px black dot which scale we made to fit the whole screen. The state will fade and then the new scree will pop-up. I think we can use this for the transitiom between menu and gameState and gameState to gameOverState.
        public Image Image;
        [XmlIgnore]
        public static bool IsTransioning { get; private set; }

        public StateManager()
        {
            xmlManager = new XMLManager<State>();
            this.CurrentState = new GameState();
            xmlManager.Type = this.currentState.Type;
            this.CurrentState = xmlManager.Load(currentState.XmlPath);

        }

        public void LoadContent(ContentManager contentManager)
        {
            Content = contentManager;
            this.CurrentState.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            this.CurrentState.UnloadContent();
            Image.UnloadContent();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.CurrentState.Draw(spriteBatch);
            if (IsTransioning)
            {
                Image.Draw(spriteBatch);
            }
            
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentState.Update(gameTime);
            Transition(gameTime);
        }

        // Transitional methods

        public void ChangeStates(string stateName)
        {
            nextState = (State) Activator.CreateInstance(Type.GetType("TomAndJerry.States." + stateName));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            currentState.Image.FadeEffect.IsActive = true;
            Image.FadeEffect.IsActive = true;
            IsTransioning = true;
           
        }

        public void Transition(GameTime gameTime)
        {
            if (IsTransioning)
            {
                // here the image will start to update until Alpha becomes 1.0 and the new state will load. After that it will start to decrease because of the fade effect and when it gets to 0 the effect will be stopped.
                Image.Update(gameTime);
                // when it is set to 1.0f we want it to fade out and once it is faded out we want to change states.
                if (Image.Alpha == 1.0f)
                {
                    currentState.UnloadContent();
                    currentState = nextState;
                   
                    xmlManager.Type = currentState.Type;
                    // Maybe not all of our states will have an xml file for loading so we are first going to check if the file exists.
                    if (File.Exists(currentState.XmlPath))
                    {
                        currentState = xmlManager.Load(currentState.XmlPath);
                    }
                    currentState.LoadContent();
                 }
                else if(Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransioning = false;
                }
            }    
        }

        // Properties
        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }
}
