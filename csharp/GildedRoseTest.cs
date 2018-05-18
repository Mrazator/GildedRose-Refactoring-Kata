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
        public void BasicItem_AfterUpdate_LowersBothValues(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(--quality, items[0].Quality);
        }

        [TestCase("foo", -20, 2)]
        [TestCase("abcdedgh", -5, 20)]
        [TestCase("Basic Item", 0, 50)]
        public void BasicItem_SellDatePassed_QualityDegradesTwiceAsFast(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(quality -2, items[0].Quality);
        }

        [TestCase("foo", -20, 1)]
        [TestCase("abcdedgh", -5, 0)]
        [TestCase("Basic Item234", 10, 1)]
        [TestCase("Basic Item", 0, 2)]
        public void Item_AfterUpdate_QualityIsNeverNegative(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        [TestCase("Aged Brie", 1, 1)]
        [TestCase("Aged Brie", 50, 0)]
        [TestCase("Aged Brie", 0, 49)]
        public void AgedBrie_AfterUpdate_AgedBrieQualityIncreaces(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(++quality, items[0].Quality);
        }

        [TestCase("Aged Brie", -10, 50)]
        [TestCase("Aged Brie", 0, 49)]
        [TestCase("Aged Brie", 20, 50)]
        public void Item_AfterUpdate_QualityIsNeverMoreThanFifty(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", -10, 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", 50, 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80)]
        public void Sulfuras_AfterUpdate_QualityDoesntDecrease(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(sellIn, items[0].SellIn);
            Assert.AreEqual(quality, items[0].Quality);
        }
    }
}
