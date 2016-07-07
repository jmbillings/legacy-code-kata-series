namespace GildedRose.Console
{
    internal class PerishableItemUpdateRule
    {
        public void UpdateItem(Item item)
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