using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase("foo", 1, 1)]
        [TestCase("abcdedgh", 30, 1)]
        [TestCase("Basic Item", 150, 50)]
        [TestCase("+5 Dexterity Vest", 10, 20)]
        [TestCase("Elixir of the Mongoose", 5, 7)]
        public void Item_AfterUpdate_LowersBothValues(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(--quality, items[0].Quality);
        }

        //Aged Brie increases in quality twice as fast
        [TestCase("foo", -20, 2)]
        [TestCase("abcdedgh", -5, 20)]
        [TestCase("Basic Item", 0, 50)]
        [TestCase("+5 Dexterity Vest", 0, 20)]
        [TestCase("Elixir of the Mongoose", 0, 7)]
        public void Item_SellDatePassed_QualityDegradesTwiceAsFast(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(quality -2, items[0].Quality);
        }

        [TestCase("foo", -20, 1)]
        [TestCase("abcdedgh", -5, 0)]
        [TestCase("Basic Item234", 10, 1)]
        [TestCase("Basic Item", 0, 2)]
        [TestCase("+5 Dexterity Vest", 0, 0)]
        [TestCase("Elixir of the Mongoose", 0, 0)]
        public void Item_AfterUpdate_QualityIsNeverNegative(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(0, items[0].Quality);
        }

        [TestCase("Aged Brie", 1, 1)]
        [TestCase("Aged Brie", 50, 0)]
        [TestCase("Aged Brie", 0, 49)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 11, 30)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 150, 49)]
        public void SpecielItem_AfterUpdate_QualityIncreaces(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(++quality, items[0].Quality);
        }

        [TestCase("Aged Brie", -10, 50)]
        [TestCase("Aged Brie", 0, 49)]
        [TestCase("Aged Brie", 20, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 6, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 11, 50)]
        public void Item_AfterUpdate_QualityIsNeverMoreThanFifty(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(50, items[0].Quality);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", -10, 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", 50, 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80)]
        public void Sulfuras_AfterUpdate_QualitAndSellInStaysTheSame(string name, int sellIn, int quality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(sellIn, items[0].SellIn);
            Assert.AreEqual(quality, items[0].Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 40, 0)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 10, 13)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 3, 5)]
        public void BackstagePasses_SellInValueApproaches_SpecialQualityBehaviour(string name, int sellIn, int quality, int expectedQuality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(expectedQuality, items[0].Quality);
        }

        [TestCase("Conjured Mana Cake", 5, 30, 28)]
        //[TestCase("Conjured Mana Cake", 0, 50, 46)]
        //[TestCase("Conjured Mana Cake", -3, 2, -2)]

        public void Conjured_AfterUpdate_DegradeTwiceAsFast(string name, int sellIn, int quality, int expectedQuality)
        {
            var items = GildedRoseUpdate(name, sellIn, quality);

            Assert.AreEqual(expectedQuality, items[0].Quality);
        }

        private List<Item> GildedRoseUpdate(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            return items;
        }
    }
}
