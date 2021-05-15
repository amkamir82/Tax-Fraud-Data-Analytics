using System.Collections.Generic;

namespace Database
{
    public class Cache
    {
        private Dictionary<string, object> _cache;

        public Cache()
        {
            _cache = new Dictionary<string, object>();
        }

        public TRecord GetRecord<TRecord>(string recordId) where TRecord : class
        {
            if (_cache.ContainsKey(recordId))
                return _cache[recordId] as TRecord;

            return default(TRecord);
        }

        public void CacheRecord<TRecord>(string recordId, TRecord record) where TRecord : class
        {
            if (!_cache.TryAdd(recordId, record))
            {
                _cache[recordId] = record;
            }
        }
    }
}