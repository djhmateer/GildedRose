using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class aDexterity : TestBase
    {
        [Fact]
        public void aReduceSellInByOne()
        {
            var normalItem = GetNormalItemDexterityVest();
            int startingSellIn = normalItem.SellIn;

            var result = shop.UpdateItemQuality(normalItem);

            Assert.Equal(startingSellIn - 1, result.SellIn);
        }

        [Fact]
        public void bReduceItemQualityByOne()
        {
            var normalItem = GetNormalItemDexterityVest();
            int startingQuality = normalItem.Quality;

            var result = shop.UpdateItemQuality(normalItem);

            Assert.Equal(startingQuality-1, result.Quality);
        }

        [Fact]
        public void cReduceItemQualityByTwoOnceSellInLessThan1()
        {
            var normalItem = GetNormalItemDexterityVest(sellIn:0);
            int startingQuality = normalItem.Quality;

            var result = shop.UpdateItemQuality(normalItem);

            Assert.Equal(startingQuality - 2, result.Quality);
        }

        [Fact]
        public void dNotReduceItemQualityBelowZero()
        {
            var normalItem = GetNormalItemDexterityVest(quality:0);

            var result = shop.UpdateItemQuality(normalItem);

            Assert.Equal(0, result.Quality);
        }

        private static Item GetNormalItemDexterityVest(int sellIn = 10, int quality = 20){
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
        }
    }

    public class bAgedBrie : TestBase
    {
        [Fact]
        public void aIncreaseQualityOfAgedBrie()
        {
            var agedBrie = GetAgedBrie();
            int startingQuality = agedBrie.Quality;

            var result = shop.UpdateItemQuality(agedBrie);

            Assert.Equal(startingQuality + 1, result.Quality);
        }

        [Fact]
        public void bNotIncreaseQualityOfAgedBriePast50()
        {
            var agedBrie = GetAgedBrie(quality: SystemMaxQuality);
            int startingQuality = agedBrie.Quality;

            var result = shop.UpdateItemQuality(agedBrie);

            Assert.Equal(SystemMaxQuality, result.Quality);
        }

        [Fact]
        public void cIncreaseQualityOfAgedBrieByTwoAfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn:0);
            int startingQuality = agedBrie.Quality;

            var result = shop.UpdateItemQuality(agedBrie);

            Assert.Equal(startingQuality + 2, result.Quality);
        }

        private static Item GetAgedBrie(int sellIn = 10, int quality = 20)
        {
            return new Item{Name = "Aged Brie",SellIn = sellIn,Quality = quality};
        }
    }

    public class cSulfuras : TestBase
    {
        [Fact]
        public void aNotChangeTheQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingQuality = sulfuras.Quality;

            var result = shop.UpdateItemQuality(sulfuras);

            Assert.Equal(startingQuality, result.Quality);
        }

        [Fact]
        public void bNotChangeTheSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingSellIn = sulfuras.SellIn;

            var result = shop.UpdateItemQuality(sulfuras);

            Assert.Equal(startingSellIn, result.SellIn);
        }

        private static Item GetSulfuras()
        {
            return new Item{Name = "Sulfuras, Hand of Ragnaros",SellIn = 0,Quality = 80};
        }
    }

    public class dBackStagePasses : TestBase
    {
        [Fact]
        public void aIncreaseTheQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var backstagePass = GetBackstagePasses(sellIn: 11);
            int startingQuality = backstagePass.Quality;

            var result = shop.UpdateItemQuality(backstagePass);

            Assert.Equal(startingQuality+1, result.Quality);
        }

        [Fact]
        public void bIncreaseTheQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var backstagePass = GetBackstagePasses(sellIn: 10);
            int startingQuality = backstagePass.Quality;

            var result = shop.UpdateItemQuality(backstagePass);

            Assert.Equal(startingQuality + 2, result.Quality);
        }

        [Fact]
        public void cIncreaseTheQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var backstagePass = GetBackstagePasses(sellIn: 6);
            int startingQuality = backstagePass.Quality;

            var result = shop.UpdateItemQuality(backstagePass);

            Assert.Equal(startingQuality + 2, result.Quality);
        }

        [Fact]
        public void dIncreaseTheQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var backstagePass = GetBackstagePasses(sellIn: 5);
            int startingQuality = backstagePass.Quality;

            var result = shop.UpdateItemQuality(backstagePass);

            Assert.Equal(startingQuality + 3, result.Quality);
        }

        [Fact]
        public void eSetQualityOfBackstagePassesToZeroWith0DaysLeft()
        {
            var backstagePass = GetBackstagePasses(sellIn: 0);

            var result = shop.UpdateItemQuality(backstagePass);

            Assert.Equal(0, result.Quality);
        }

        private static Item GetBackstagePasses(int sellIn = 10, int quality = 20){
            return new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,Quality = quality
            };
        }
    }

    public class eConjuredItems : TestBase
    {
        [Fact]
        public void aDecreaseTheQualityBy2()
        {
            var conjuredItem = GetConjuredItem();
            int startingQuality = conjuredItem.Quality;

            var result = shop.UpdateItemQuality(conjuredItem);

            Assert.Equal(startingQuality - 2, result.Quality);
        }

        [Fact]
        public void bReduceSellInBy1()
        {
            var conjuredItem = GetConjuredItem();
            int startingSellIn = conjuredItem.SellIn;

            var result = shop.UpdateItemQuality(conjuredItem);

            Assert.Equal(startingSellIn - 1, result.SellIn);
        }

        [Fact]
        public void bNotReduceQualityBelowZero()
        {
            var conjuredItem = GetConjuredItem(quality:0);
            int startingQuality = conjuredItem.Quality;

            var result = shop.UpdateItemQuality(conjuredItem);

            Assert.Equal(0, result.Quality);
        }

        private static Item GetConjuredItem(int sellIn = 10, int quality = 20)
        {
            return new Item{Name = "Conjured Item",SellIn = sellIn,Quality = quality};
        }
    }
}