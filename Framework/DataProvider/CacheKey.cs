namespace Framework.DataProvider
{
    public class CacheKey<T>
    {
        public static object Instance { get; } = new CacheKey<T>();

        private CacheKey() { }
    }
}
