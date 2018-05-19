namespace csharp.Strategies.Quality.Interfaces
{
    public interface IQualityStrategy
    {
        void UpdateQuality(Item item, bool sellByDateHasPassed);
    }
}
