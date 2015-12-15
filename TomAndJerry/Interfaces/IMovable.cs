using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TomAndJerry.Interfaces
{
    interface IMovable
    {
        Vector2 Velocity { get; set; }

        float MoveSpeed { get; set; }
    }
}
