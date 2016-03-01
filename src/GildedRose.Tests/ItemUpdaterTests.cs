using System.Collections.Generic;
using GildedRose.Core;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
    {
        [Test]
        public void StandardItemShouldLowerQualityAndSellInByOne()
        {
            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 3, Quality = 6}
            };

            var program = new ItemUpdater();
            program.Update(items);

            Assert.AreEqual(5, items[0].Quality);
            Assert.AreEqual(2, items[0].SellIn);
        }

        [Test]
        public void ConjuredItemShouldLowerQualityByTwoAndSellInByOne()
        {
            var items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var program = new ItemUpdater();
            program.Update(items);

            Assert.AreEqual(4, items[0].Quality);
            Assert.AreEqual(2, items[0].SellIn);
        }

        [Test]
        public void ConjuredItemCanNeverHaveNegativeQuality()
        {
            var items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 1}
            };

            var program = new ItemUpdater();
            program.Update(items);

            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(2, items[0].SellIn);
        }
    }
}