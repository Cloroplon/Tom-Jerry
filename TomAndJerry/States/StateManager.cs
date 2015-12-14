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
/// This is our StateManager class he is controlling and holding our current state and through it we are going to access every state in the game. It is also responsible for the transition between states.
/// </summary>
namespace TomAndJerry.States
{
    public class StateManager
    {
        private State currentState, nextState;
        [XmlIgnore]
        public ContentManager Content { private set; get; }
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice { set; get; }
        [XmlIgnore]
        public SpriteBatch SpriteBatch { set; get; }
        public XMLManager<State> xmlManager;

        // The idea is this is image to be used for the transition face. It is a small 1px black dot which scale was made to fit the whole screen. The state will fade and then the new scree will pop-up. I think we can use this for the transitiom between menu and gameState and gameState to gameOverState.
        public Image Image;
        [XmlIgnore]
        public bool IsTransioning { get; private set; }

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
            // We are activating the effects of the image here so it can flash until the state has transitioned.
            this.Image.Effects.Split(':')
                .ToList()
                .ForEach(effect => 
                this.Image.ActivateEffect(effect));

            this.CurrentState.Image.Effects.Split(':')
                .ToList()
                .ForEach(effect => 
                this.CurrentState.Image.ActivateEffect(effect));
            IsTransioning = true;
           
        }

        public void Transition(GameTime gameTime)
        {
            if (IsTransioning)
            {
                // here the image will start to update until Alpha becomes 1.0 and the new state will load. After that it will start to decrease because of the fade effect and when it gets to 0 the effect will be stopped.
                Image.Update(gameTime);
                // when it is set to 1.0f we want it to fade out and once it is faded out we want to change states.
                if (Image.Alpha >= 1.0f)
                {
                   CurrentState.UnloadContent();
                   CurrentState = nextState;
                   
                    xmlManager.Type = CurrentState.Type;
                    // Maybe not all of our states will have an xml file for loading so we are first going to check if the file exists.
                    if (File.Exists(currentState.XmlPath))
                    {
                      CurrentState = xmlManager.Load(currentState.XmlPath);
                    }
                   CurrentState.LoadContent();
                    IsTransioning = false;
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
