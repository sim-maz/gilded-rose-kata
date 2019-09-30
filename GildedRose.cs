using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        private const int MAX_ITEM_QUALITY = 50;
        private const int MIN_ITEM_QUALITY = 0;
        private const int QUALITY_SINGLE_INCREMENT = 1;
        private const int SELL_IN_DATE = 0;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var type = item.Name.GetItemType();

                if (type == ItemType.Legendary) continue;

                item.SellIn -= 1;

                HandleItemQuality(item, type);
            }
        }

        private void HandleItemQuality(Item item, ItemType type)
        {
            if (item.Quality > MAX_ITEM_QUALITY || item.Quality <= MIN_ITEM_QUALITY) return;

            switch (type)
            {
                case ItemType.Aged:
                    HandleAgedItemQuality(item);
                    break;
                case ItemType.BackstagePass:
                    HandleBackstagePassItemQuality(item);
                    break;
                case ItemType.Conjured:
                    HandleConjuredItemQuality(item);
                    break;
                case ItemType.Regular:
                    HandleRegularItemQuality(item);
                    break;
                default:
                    break;
            }
        }

        private void HandleRegularItemQuality(Item item) 
        {
            if (item.SellIn < SELL_IN_DATE)
                item.Quality -= QUALITY_SINGLE_INCREMENT * 2;
            
            else
                item.Quality -= QUALITY_SINGLE_INCREMENT;
        }

        private void HandleAgedItemQuality(Item item)
        {
            if (item.SellIn < SELL_IN_DATE)
                item.Quality += QUALITY_SINGLE_INCREMENT * 2;

            else
                item.Quality += QUALITY_SINGLE_INCREMENT;
        }

        private void HandleBackstagePassItemQuality(Item item) 
        {
            if (item.SellIn < SELL_IN_DATE)
            {            
                item.Quality = MIN_ITEM_QUALITY;
                return;
            }

            if (item.SellIn <= 5)
                item.Quality += QUALITY_SINGLE_INCREMENT * 3;

            else if (item.SellIn <= 10)
                item.Quality += QUALITY_SINGLE_INCREMENT * 2;

            else
                item.Quality += QUALITY_SINGLE_INCREMENT;
        }

        private void HandleConjuredItemQuality(Item item) 
        {
            if (item.SellIn < SELL_IN_DATE)
                item.Quality -= QUALITY_SINGLE_INCREMENT * 4;

            else
                item.Quality -= QUALITY_SINGLE_INCREMENT * 2;
        }
    }
}
