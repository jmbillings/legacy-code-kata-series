namespace GildedRose.Console
{
    internal class ConjuredItemUpdateRule
    {
        public static void UpdateItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.DecreaseSellIn();
        }
    }
}