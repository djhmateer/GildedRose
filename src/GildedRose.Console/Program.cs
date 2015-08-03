using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        static IList<Item> _currentItemsInShop;

        static void Main()
        {
            _currentItemsInShop = new List<Item>{
                new Item{Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item{Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item{Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item{Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item{Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 15,Quality = 20},
                new Item{Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var shop = new GildedRoseShop();
            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < _currentItemsInShop.Count; j++)
                {
                    System.Console.WriteLine(_currentItemsInShop[j].Name + ", " + _currentItemsInShop[j].SellIn + ", " + _currentItemsInShop[j].Quality);
                }
                System.Console.WriteLine("");
                _currentItemsInShop = shop.UpdateDailyQualities(_currentItemsInShop);
            }

            System.Console.ReadKey();
        }
    }
}
