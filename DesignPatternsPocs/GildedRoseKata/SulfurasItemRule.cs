
namespace GildedRoseKata
{
    public class SulfurasItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public override void UpdateQuality(ItemProxy item)
        {
        }
    }
}
