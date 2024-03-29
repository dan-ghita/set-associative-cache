using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace SetAssociativeCache.Test
{
    public abstract class AssociativeCacheUnitTests
    {
        [Fact]
        public void Add_PersistsElement()
        {
            int tag = new Random().Next();
            string value = "testValue";

            m_cache.Add(tag, value);

            Assert.Equal(1, m_cache.Count);
            Assert.Equal(value, m_cache.Get(tag));
        }


        [Fact]
        public void Add_CacheIsFull_PersistsNewElements()
        {
            FillCacheAndValidate();

            for (int i = m_cacheSize; i < 2 * m_cacheSize; ++i)
            {
                m_cache.Add(i, i.ToString());
                Assert.Equal(m_cacheSize, m_cache.Count);
                Assert.Equal(i.ToString(), m_cache.Get(i));
            }
        }

        protected void FillCacheAndValidate()
        {
            for (int i = 0; i < m_cacheSize; ++i)
                m_cache.Add(i, i.ToString());

            Assert.Equal(m_cacheSize, m_cache.Count);

            for (int i = 0; i < m_cacheSize; ++i)
                Assert.Equal(i.ToString(), m_cache.Get(i));
        }

        protected int m_cacheSize = 5;

        protected IAssociativeCache<string> m_cache;
    }
}
