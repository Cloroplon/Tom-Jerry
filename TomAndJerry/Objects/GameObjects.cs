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
    /// This is the basic class for all our objects. Every objects needs to have a position which to show where to be drawn, an image which will be displayed on the position and every objects must know how to draw itself, update, load and unload so the state will contain lists of the objects that are inside it and will call their Methods. 
    /// </summary>
    abstract class GameObjects : IObjects
    {
        private Vector2 position;
        private Texture2D image;

        public GameObjects(Vector2 position, Texture2D image)
        {
            this.Position = position;
            this.Image = image;
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public void LoadContent()
        {
            // TODO
        }

        public void UnloadContent()
        {
            // TODO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
