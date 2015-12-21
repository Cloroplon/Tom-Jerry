using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomAndJerry.Objects.Items.Weapons;

namespace TomAndJerry.Interfaces
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(string name);
    }
}
