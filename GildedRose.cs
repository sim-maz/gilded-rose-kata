using System.Collections.Generic;

namespace csharp
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
            foreach (var item in Items)
            {
                if (item.Name.GetItemType() == ItemType.Legendary)
                    continue;

                if (item.Name.GetItemType() != ItemType.Aged && item.Name.GetItemType() != ItemType.BackstagePass)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name.GetItemType() != ItemType.Legendary)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name.GetItemType() == ItemType.BackstagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name.GetItemType() != ItemType.Legendary)
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name.GetItemType() != ItemType.Aged)
                    {
                        if (item.Name.GetItemType() != ItemType.BackstagePass)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name.GetItemType() != ItemType.BackstagePass)
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }
    }
}
