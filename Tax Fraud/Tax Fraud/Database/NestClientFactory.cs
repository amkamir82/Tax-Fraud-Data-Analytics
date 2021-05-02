using Nest;
using System;

namespace Database
{
    public class NestClientFactory
    {
        private static NestClientFactory singletonInstance = new NestClientFactory();
        private IElasticClient _client = null;

        private NestClientFactory()
        {
        }

        public void CreateInitialClient()
        {
            var uri = new Uri("127.0.0.1:9200");
            var connectionSettings = new ConnectionSettings(uri);
            _client = new ElasticClient(connectionSettings);
        }

        public IElasticClient GetClient()
        {
            if (_client == null)
            {
                throw new Exception("Client not found");
            }

            return _client;
        }

        public static NestClientFactory GetInstance()
        {
            return singletonInstance;
        }
    }
}