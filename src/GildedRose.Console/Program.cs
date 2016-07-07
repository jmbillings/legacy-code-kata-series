using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        private IList<Item> Items;

        internal static void Main(string[] args)
        {
            UpdateAndPrintItems();

            System.Console.ReadKey();
        }

        internal static void UpdateAndPrintItems()
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, ItemType = ItemType.Aged},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, ItemType = ItemType.Legendary},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20,
                        ItemType = ItemType.Event
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, ItemType = ItemType.Conjured}
                }
            };

            app.UpdateQuality();

            PrintItems(app);
        }

        private static void PrintItems(Program app)
        {
            foreach (var item in app.Items)
            {
                System.Console.WriteLine("{0}|{1}|{2}", item.Name, item.Quality, item.SellIn);
            }
        }

        public void UpdateQuality()
        {
            UpdateQuality(Items.ToArray());
        }

        public static void UpdateQuality(Item[] items)
        {
            foreach (var item in items)
            {
                switch (item.ItemType)
                {
                    case ItemType.Aged:
                        UpdateAgeingItem(item);
                        break;
                    case ItemType.Event:
                        UpdateDesirableEventItem(item);
                        break;
                    case ItemType.Legendary:
                        UpdateLegendaryItem(item);
                        break;
                    case ItemType.Conjured:
                        UpdateConjuredItem(item);
                        break;
                    case ItemType.Perishable:
                        UpdatePerishableItem(item);
                        break;
                    default:
                        throw new InvalidOperationException(
                            $"Item Type was not specified for item {item.Name}, of type {item.ItemType}");
                }
            }
        }

        private static void UpdateConjuredItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.DecreaseSellIn();
        }

        private static void UpdateAgeingItem(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.IncreaseQuality();
            }
        }

        private static void UpdateDesirableEventItem(Item item)
        {
            // Tickets are more valuable when an event is closer
            if (item.SellIn <= 10)
            {
                item.IncreaseQuality();
            }

            // They increase in value much more the closer we are to the event
            if (item.SellIn <= 5)
            {
                item.IncreaseQuality();
            }

            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.Quality = 0;
            }
        }

        private static void UpdateLegendaryItem(Item item)
        {
        }

        private static void UpdatePerishableItem(Item item)
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