using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Interfaces;

namespace TomAndJerry
{
    /// <summary>
    /// This is the basic class for all our objects. Every objects needs to have a an Image which will be displayed on the position and every objects must know how to draw itself, update, load and unload so the state will contain lists of the objects that are inside it and will call their Methods. 
    /// </summary>
    public abstract class GameObject : IObjects, IBasicMethods
    {
        public Image Image { get; set; }

        public bool MustRemove { get; set; }

        public virtual void LoadContent()
        {
            Image.LoadContent();
        }

        public virtual void UnloadContent()
        {
           Image.UnloadContent();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime)
        {
           Image.Update(gameTime);
        }
    }
}
