using System.Collections.Generic;

namespace GildedRose.Console
{
    public class GildedRoseShop
    {
        public IList<Item> UpdateDailyQualities(IList<Item> items)
        {
            var itemsUpdated = new List<Item>();
            foreach (Item item in items)
            {
                var result = UpdateItemQuality(item);
                itemsUpdated.Add(result);
            }
            return itemsUpdated;
        }

        public Item UpdateItemQuality(Item item)
        {
            if (item.Name == "+5 Dexterity Vest")
                item = UpdateItemAsDexterity(item);

            if (item.Name == "Aged Brie")
                item = UpdateItemAsAgedBrie(item);

            if (item.Name == "Sulfuras, Hand of Ragnaros")
                item = UpdateItemAsSulfuras(item);

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                item = UpdateItemAsBackStage(item);

            if (item.Name == "Conjured Item")
                item = UpdateItemAsConjured(item);

            return item;
        }

        private Item UpdateItemAsDexterity(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 1)
                item.Quality -= 2;
            else
                item.Quality -= 1;

            if (item.Quality < 0)
                item.Quality = 0;

            return item;
        }

        private Item UpdateItemAsAgedBrie(Item item)
        {
            if (item.SellIn > 0)
                item.Quality += 1;
            else
                item.Quality += 2;

            if (item.Quality > 50)
                item.Quality = 50;
            return item;
        }

        private Item UpdateItemAsSulfuras(Item item)
        {
            return item;
        }

        private Item UpdateItemAsBackStage(Item item)
        {
            if (item.SellIn > 10)
                item.Quality += 1;

            if (item.SellIn <= 10 && item.SellIn > 5)
                item.Quality += 2;

            if (item.SellIn <= 5 && item.SellIn > 0)
                item.Quality += 3;

            if (item.SellIn == 0)
                item.Quality = 0;

            return item;
        }

        private Item UpdateItemAsConjured(Item item)
        {
            item.SellIn -= 1;
            item.Quality -= 2;

            if (item.Quality < 0)
                item.Quality = 0;

            return item;
        }
    }
}