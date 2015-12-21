using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TomAndJerry.Interfaces;
using TomAndJerry.Objects.Items.Consumables;
using TomAndJerry.Objects.Items.Weapons;

namespace TomAndJerry.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
       

        public Weapon CreateWeapon(string weaponName)
        {
            var weaponType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(f => f.Name == weaponName);
            var weapon = Activator.CreateInstance(weaponType) as Weapon;

            return weapon;
        }
    }
}
