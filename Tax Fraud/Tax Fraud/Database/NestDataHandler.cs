using System.Collections.Generic;
using Nest;

namespace Database
{
    public static class NestDataHandler
    {
        private static IElasticClient client = NestClientFactory.GetInstance().GetClient();

        public static IEnumerable<Dictionary<string, object>> GetAllDocuments(QueryContainer query, string indexName,
            int size = 10000)
        {
            var response = client.Search<Dictionary<string, object>>(d => d
                .Query(q => query).Index(indexName)
            );

            return response.Documents;
        }
    }
}