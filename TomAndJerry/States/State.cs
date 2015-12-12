using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// Every state has the same 4 methods which are basi for a Monogame game and implements IState interface. 
/// </summary>
namespace TomAndJerry.States
{
    public abstract class State : IState
    {
        [XmlIgnore]
        private Vector2 dimensions;
        protected ContentManager contentManager;
        [XmlIgnore]
        public Type Type { get; private set; }

        public string XmlPath;

        public Image Image;

        public State()
        {
            this.Dimensions = new Vector2(640, 480); // the size of the screen is basic and it can be changed later if we decide.
                                                     // we are getting the type so we can give it to the xml
            this.Type = this.GetType();
            // this will give us the name of the xml file so we can load from it in the state manager.
            XmlPath = "../../../Load/" + this.Type.Name + ".xml";
        }

        public virtual void LoadContent()
        {
            // we are creating a new conent manager so it can load only the files we need for this specific content manager
            this.contentManager = new ContentManager(Game1.StateManager.Content.ServiceProvider, "Content");
        }


        public virtual void UnloadContent()
        {
            this.contentManager.Unload();
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }


        public virtual void Update(GameTime gameTime)
        {
            Game1.InputManager.Update();
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }
    }
}
