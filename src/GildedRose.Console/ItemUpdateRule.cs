namespace GildedRose.Console
{
    internal class ItemUpdateRule : IItemUpdateRule
    {
        public void UpdateItem(Item item)
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