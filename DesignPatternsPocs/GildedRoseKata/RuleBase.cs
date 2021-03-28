using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public abstract class RuleBase
    {
        public abstract bool IsMatch(ItemProxy item);
        public abstract void UpdateQuality(ItemProxy item);
    }
}
