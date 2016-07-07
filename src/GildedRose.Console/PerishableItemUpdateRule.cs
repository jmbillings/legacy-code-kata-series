namespace GildedRose.Console
{
    internal class PerishableItemUpdateRule
    {
        public static void UpdatePerishableItem(Item item)
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