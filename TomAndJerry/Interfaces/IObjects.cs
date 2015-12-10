using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.Interfaces
{
    interface IObjects
    {
        Vector2 Position { get; set; }
        Texture2D Image { get; set; }

        void LoadContent();

        void UnloadContent();

        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
