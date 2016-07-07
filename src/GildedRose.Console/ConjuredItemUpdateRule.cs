namespace GildedRose.Console
{
    internal class ConjuredItemUpdateRule
    {
        public static void UpdateConjuredItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.DecreaseSellIn();
        }
    }
}