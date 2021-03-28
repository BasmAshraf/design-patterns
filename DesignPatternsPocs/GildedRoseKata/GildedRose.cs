using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var engine = new ItemQualityRuleEngine.Builder()
                .WithAgedBrieItemRule()
                .WithBackStageItemRule()
                .WithConjuredItemRule()
                .WithSulfurasItemRule()
                .Build();

            for (var i = 0; i < Items.Count; i++)
            {
                var item = new ItemProxy(Items[i]);
                engine.ApplyRules(item);
            }
        }
    }
}
