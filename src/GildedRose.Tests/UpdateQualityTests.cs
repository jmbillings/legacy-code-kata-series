using System.Collections.Generic;
using GildedRose.Core;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class UpdateQualityTests
    {
        [Test]
        public void StandardItemShouldLowerQualityAndSellInByOne()
        {
            var items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var program = new QualityUpdater();
            program.UpdateQuality(items);

            Assert.AreEqual(5, items[0].Quality);
            Assert.AreEqual(2, items[0].SellIn);
        }
    }
}