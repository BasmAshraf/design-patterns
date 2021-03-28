using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public class ConjuredItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured Mana Cake";
        }

        public override void UpdateQuality(ItemProxy item)
        {
            item.DecrementSellIn();
            item.DecrementQuality();
            item.DecrementQuality();
            if (item.SellIn <= 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }

        }
    }
}
