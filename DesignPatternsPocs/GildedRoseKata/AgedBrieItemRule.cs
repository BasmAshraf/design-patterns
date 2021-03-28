
namespace GildedRoseKata
{
    public class AgedBrieItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }

        public override void UpdateQuality(ItemProxy item)
        {
            item.DecrementSellIn();
            item.IncrementQuality();
            if(item.SellIn<=0)
                item.IncrementQuality();
        }
    }
}
