using Entity;
using Database;
using static Entity.ElasticData;
using System.Collections.Generic;

namespace Program
{
    class PatternGenerator
    {
        private Cache _patternCache;

        public PatternGenerator()
        {
            _patternCache = new Cache();
        }

        public void Process(string modelName)
        {
            Dictionary<string, List<ElasticData>> allData = AllData;
            foreach (var elasticData in allData[modelName])
            {
                List<ElasticData> data = new List<ElasticData>();
                data.Add(elasticData);
                var peopleRelation = GetElasticDataByModelAndPrimaryKey("PeopleRelation",
                    "کدملی عضو خانواده",
                    elasticData.Data["کدملی مالک"].ToString());
                data.Add(peopleRelation);
                var document =
                    GetElasticDataByModelAndPrimaryKey("Document", "کد ملی",
                        peopleRelation.Data["کدملی"].ToString());
                data.Add(document);
                Pattern pattern = new Pattern(data);
                _patternCache.CacheRecord(pattern.Id, pattern.Nodes);
            }
        }
    }
}