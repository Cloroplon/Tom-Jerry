using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.Objects
{
    class Room : GameObjects
    {
        // this will be the class that will hold our environment. The background picture and the objects inside it.
        public Room(Vector2 position, Texture2D image) : base(position, image)
        {

        }
    }
}
