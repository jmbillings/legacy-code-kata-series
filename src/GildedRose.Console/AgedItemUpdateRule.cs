namespace GildedRose.Console
{
    internal class AgedItemUpdateRule
    {
        public static void UpdateAgeingItem(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.IncreaseQuality();
            }
        }
    }
}