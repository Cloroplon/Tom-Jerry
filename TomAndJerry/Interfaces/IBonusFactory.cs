using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomAndJerry.Objects.Items.Bonuses;

namespace TomAndJerry.Interfaces
{
    public interface IBonusFactory
    {
        Bonus CreateBonus(string bonusName);
    }
}
