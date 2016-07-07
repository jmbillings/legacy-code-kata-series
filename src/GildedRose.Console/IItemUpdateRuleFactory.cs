using System;

namespace GildedRose.Console
{
    public static class ItemUpdateRuleFactory
    {
        public static IItemUpdateRule CreateItemUpdateRule(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Aged:
                    return new AgedItemUpdateRule();
                case ItemType.Event:
                    return new EventItemUpdateRule();
                case ItemType.Legendary:
                    return new LegendaryItemUpdateRule();
                case ItemType.Conjured:
                    return new ConjuredItemUpdateRule();
                case ItemType.Perishable:
                    return new PerishableItemUpdateRule();
                default:
                    throw new InvalidOperationException($"Item Type was not specified for item type {itemType}");
            }
        }
    }
}
