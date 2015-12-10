using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.Objects.Characters
{
    class Tom : GameObjects
    {
        // more fields according to what we decide we want him to do. Also we will draw just part of the image from the sprite. 
        public Tom(Vector2 position, Texture2D image) : base(position, image)
        {
        }
    }
}
