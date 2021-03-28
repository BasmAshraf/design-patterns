using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public class NormalItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Normal Item";
        }

        public override void UpdateQuality(ItemProxy item)
        {
            item.DecrementSellIn();
            item.DecrementQuality();
            if (item.SellIn <= 0)
                item.DecrementQuality();
        }
    }
}
