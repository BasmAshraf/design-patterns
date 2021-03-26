namespace GildedRoseKata
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public abstract void UpdateQuality();
    }

    public class NormalItem : Item
    {
        public override void UpdateQuality()
        {
            SellIn -= 1;
            if (Quality > 0)
            {
                Quality -= 1;
            }
            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }
        }
    }

    public class AgedBrieItem : Item
    {
        public override void UpdateQuality()
        {
            SellIn -= 1;
            if (Quality < 50)
            {
                Quality += 1;
            }
            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality += 1;
                }
            }
        }
    }

    public class SulfurasItem : Item
    {
        public override void UpdateQuality()
        {
        }
    }

    public class BackstageItem : Item
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }
                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }
            }
            SellIn -= 1;
            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }

    public class ConjuredItem : Item
    {
        public override void UpdateQuality()
        {
            SellIn -= 1;
            if (Quality > 0)
            {
                Quality -= 1;
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }
            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality -= 1;
                    if (Quality > 0)
                    {
                        Quality -= 1;
                    }
                }
            }
        }
    }
}