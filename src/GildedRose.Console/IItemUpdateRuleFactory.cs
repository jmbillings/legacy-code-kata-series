namespace GildedRose.Console
{
    public static class ItemUpdateRuleFactory
    {
        public static IItemUpdateRule CreateItemUpdateRule()
        {
            return new  PerishableItemUpdateRule();
        }
    }
}
