namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public ItemType ItemType { get; set; }

        public void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
        }

        public void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }

        public void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        public bool HasPassedSellByDate()
        {
            return SellIn < 0;
        }
    }
}