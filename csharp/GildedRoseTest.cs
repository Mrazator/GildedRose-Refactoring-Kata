using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase("foo", 1, 1)]
        [TestCase("abcdedgh", 30, 1)]
        [TestCase("Unknown Item", 150, 50)]
        public void UnknownItem_AfterUpdate_LowersBothValues(string name, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual(name, items[0].Name);
            Assert.AreEqual(--sellIn, items[0].SellIn);
            Assert.AreEqual(--quality, items[0].Quality);
        }
    }
}
