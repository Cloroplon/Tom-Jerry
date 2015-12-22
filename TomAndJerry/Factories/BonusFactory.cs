using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TomAndJerry.Interfaces;
using TomAndJerry.Objects.Items.Bonuses;
using TomAndJerry.Objects.Items.Consumables;

namespace TomAndJerry.Factories
{
    public class BonusFactory : IBonusFactory
    {
        public Bonus CreateBonus(string bonusName)
        {
            var bonusType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(f => f.Name == bonusName);
            var bonus = Activator.CreateInstance(bonusType) as Bonus;

            return bonus;
        }
    }
}
