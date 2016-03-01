using GildedRose.Core;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
    {
        [Test]
        public void StandardItemShouldLowerQualityAndSellInByOne()
        {
            var item = new Item {Name = "+5 Dexterity Vest", SellIn = 3, Quality = 6};

            new ItemUpdater().Update(item);

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void ConjuredItemShouldLowerQualityByTwoAndSellInByOne()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

            new ItemUpdater().Update(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void ConjuredItemCanNeverHaveNegativeQuality()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 1};

            new ItemUpdater().Update(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }
    }
}