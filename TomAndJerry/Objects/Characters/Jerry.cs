using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.Objects.Characters
{
    class Jerry : GameObjects
    {
        // the same as for Tom. We also might add an additional abstract class for characters which can hol their common properties when we decide what we want our characters to do. 
        public Jerry(Vector2 position, Texture2D image) : base(position, image)
        {
        }
    }
}
