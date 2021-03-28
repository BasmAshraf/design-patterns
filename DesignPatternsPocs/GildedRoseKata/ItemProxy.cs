using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public class ItemProxy
    {
        private Item _item;
        public string Name => _item.Name;
        public int SellIn => _item.SellIn;
        public int Quality => _item.Quality;
        public ItemProxy(Item item)
        {
            _item = item;
        }

        public void DecrementQuality()
        {
            if (_item.Quality > 0)
                _item.Quality--;
        }

        public void ResetQuality()
        {
            _item.Quality = 0;
        }

        public void IncrementQuality()
        {
            if (_item.Quality < 50)
                _item.Quality++;
        }

        public void DecrementSellIn()
        {
            _item.SellIn--;
        }
    }
}
