using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TomAndJerry.Interfaces;
using TomAndJerry.Objects.Items.Consumables;

namespace TomAndJerry
{
    class FruitFactory : IFruitFactory
    {
        public Consumable CreateFruit(string fruitName)
        {

            var fruitType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(f => f.Name == fruitName);
            var fruit = Activator.CreateInstance(fruitType) as Consumable;

            return fruit;
        }
    }
}
