using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
    {
        [Test]
        public void PerishableItemShouldLowerQualityAndSellInByOne()
        {
            var item = new Item { SellIn = 3, Quality = 6 };

            UpdateItem(item);

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void PerishableItemShouldLowerQualityTwiceAsFastWhenSellInIsNegative()
        {
            var item = new Item { SellIn = -2, Quality = 6 };

            UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void PerishableItemShouldLowerQualityTwiceAsFastWhenSellInIsZero()
        {
            var item = new Item { SellIn = 0, Quality = 6 };

            UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void EventItemShouldIncreaseQualityTwiceAsFastWhenSellInLessThanElevenDays()
        {
            var item = new Item { SellIn = 10, Quality = 6, ItemType = ItemType.Event };

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void EventItemShouldIncreaseQualityThreeTimesAsFastWhenSellInLessThanSixDays()
        {
            var item = new Item { SellIn = 5, Quality = 6, ItemType = ItemType.Event };

            UpdateItem(item);

            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void EventItemShouldHaveZeroQualityWhenSellInBelowZero()
        {
            var item = new Item { SellIn = 0, Quality = 6, ItemType = ItemType.Event };

            UpdateItem(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgedItemQualityIncreasesTwiceAsFastWhenSellInIsLessThanZero()
        {
            var item = new Item { SellIn = 0, Quality = 6, ItemType = ItemType.Aged };

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgedItemQualityCanNeverBeMoreThanFifty()
        {
            var item = new Item { SellIn = -1, Quality = 50, ItemType = ItemType.Aged };

            UpdateItem(item);

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        [Test]
        public void PerishableItemQualityIsNeverNegative()
        {
            var item = new Item { SellIn = 10, Quality = 0 };

            UpdateItem(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void LegendaryItemNeverDecreasesInQualityAndNeverHasToBeSold()
        {
            var item = new Item { SellIn = 10, Quality = 80, ItemType = ItemType.Legendary };

            UpdateItem(item);

            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void ConjuredItemQualityDecreasesTwiceAsFast()
        {
            var item = new Item { SellIn = 6, Quality = 10, ItemType = ItemType.Conjured };

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(5, item.SellIn);
        }

        private void UpdateItem(Item item)
        {
            Program.UpdateQuality(new[] { item });
        }
    }
}