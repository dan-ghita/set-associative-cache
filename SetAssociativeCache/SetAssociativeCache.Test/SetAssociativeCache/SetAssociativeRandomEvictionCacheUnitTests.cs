namespace SetAssociativeCache.Test.SetAssociativeCache
{
    public class SetAssociativeRandomEvictionCacheUnitTests : SetAssociativeCacheUnitTests
    {
        public SetAssociativeRandomEvictionCacheUnitTests()
        {
            m_cache = new SetAssociativeCache<string, string>(m_cacheSizeInKb, m_numberOfWays,
                (size) => new RandomEvictionAssociativeCache<string>(size));
        }

        public override void RegisterCacheWithMock()
        {
            // 1 * 1024 / 64 = 16 -> first 4 bit for set index
            m_cache = new SetAssociativeCache<string, string>(1, 1,
                (size) => new RandomEvictionAssociativeCache<string>(size));
        }
    }
}