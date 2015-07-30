using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private readonly GildedRoseShop shop = new GildedRoseShop();

        [Fact]
        public void GivenDexterityVest_ShouldReduceItemQualityByOne()
        {
            var normalItem = GetNormalItemDexterityVest();
            int startingQuality = normalItem.Quality;

            var result = shop.UpdateItemQuality(normalItem);

            Assert.Equal(startingQuality-1, result.Quality);
        }

        private static Item GetNormalItemDexterityVest(){
            return new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        }
    }
}