namespace csharp.Strategies.Quality.Common
{
    public class CommonQualityStrategy
    {
        internal static void IncreaseQualityBy(Item item, int by = 1)
        {
            var result = item.Quality + by;
            item.Quality = result >= 50 ? 50 : result;
        }

        internal static void LowerQualityBy(Item item, int by = 1)
        {
            var result = item.Quality - by;
            item.Quality = result <= 0 ? 0 : result;
        }
    }
}
