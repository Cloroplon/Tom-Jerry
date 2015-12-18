using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomAndJerry.Objects.Items.Consumables;

namespace TomAndJerry.Interfaces
{
    public interface IFruitFactory
    {
        Consumable CreateFruit(string fruitName);
    }
}
