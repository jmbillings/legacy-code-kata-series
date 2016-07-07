namespace GildedRose.Console
{
    internal class ConjuredItemUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.DecreaseSellIn();
        }
    }
}