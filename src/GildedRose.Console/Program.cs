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
                        new ItemUpdateRule().UpdateItem(item);
                        break;
                    case ItemType.Event:
                        new EventItemUpdateRule().UpdateItem(item);
                        break;
                    case ItemType.Legendary:
                        new LegendaryItemUpdateRule().UpdateItem(item);
                        break;
                    case ItemType.Conjured:
                        new ConjuredItemUpdateRule().UpdateItem(item);
                        break;
                    case ItemType.Perishable:
                        new PerishableItemUpdateRule().UpdateItem(item);
                        break;
                    default:
                        throw new InvalidOperationException(
                            $"Item Type was not specified for item {item.Name}, of type {item.ItemType}");
                }
            }
        }
    }
}