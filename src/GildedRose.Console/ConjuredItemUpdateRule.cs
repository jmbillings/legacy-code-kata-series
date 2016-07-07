namespace GildedRose.Console
{
    internal class ConjuredItemUpdateRule : IItemUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.DecreaseSellIn();
        }
    }
}