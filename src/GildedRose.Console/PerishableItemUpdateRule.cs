namespace GildedRose.Console
{
    internal class PerishableItemUpdateRule
    {
        public static void UpdateItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.DecreaseQuality();
            }
        }
    }
}