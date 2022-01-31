using Nest;
using Entity;

namespace Database
{
    public class NestQueryHandler
    {
        public MatchAllQuery GetMatchAllElasticQuery()
        {
            return new MatchAllQuery();
        }

        public TermsQuery GetTermsElasticQuery(string field, string modelName, string primaryKey)
        {
            return new TermsQuery()
            {
                Boost = 1.0,
                Field = field,
                Terms = ElasticData.GetModelPrimaryKeys(modelName, primaryKey)
            };
        }
    }
}