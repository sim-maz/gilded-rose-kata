using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_AnyItem_NotNegative()
        {
            IList<Item> Items = new List<Item> 
            { 
                new Item { Name = "Regular Item", SellIn = -1, Quality = 0 },
                new Item { Name = "Regular Item", SellIn = 5, Quality = 0 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[1].Quality);
        }

        [Test]
        public void UpdateQuality_AnyItem_SellInDaysDecreases()
        {
            IList<Item> Items = new List<Item> 
            { 
                new Item { Name = "Regular Item", SellIn = 5, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 70 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(4, Items[1].SellIn);
            Assert.AreEqual(5, Items[2].SellIn);
            Assert.AreEqual(4, Items[3].SellIn);
        }

        [Test]
        public void UpdateQuality_RegularSellDateNotPassed_DegradesQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Regular Item", SellIn = 6, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_RegularSellDateHasPassed_DegradesDouble()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Regular Item", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredSellDateNotPassed_DegradesQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredSellDateHasPassed_DegradesDouble()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_AgedSellDateHasPassed_IncreasesQuality()
        {
            IList<Item> Items = new List<Item> 
            {
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_AgedSellDateNotPassed_IncreasesQuality()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 3, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 50}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(50, Items[1].Quality);
        }

        [Test]
        public void UpdateQuality_Sulfuras_UnchangedQuality()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 70 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(70, Items[1].Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_ZeroAfterSellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_IncreasesQualityBeforeSellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(12, Items[1].Quality);
            Assert.AreEqual(13, Items[2].Quality);
        }
    }
}
