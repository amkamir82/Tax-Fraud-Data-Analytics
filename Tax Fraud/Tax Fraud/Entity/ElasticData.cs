using System;
using System.Collections.Generic;
using Nest;

namespace Entity
{
    public class ElasticData
    {
        public static Dictionary<string, List<ElasticData>> AllData { get; } =
            new Dictionary<string, List<ElasticData>>();


        public Dictionary<string, object> Data;
        public string Type;

        public ElasticData(string type, Dictionary<string, object> data)
        {
            this.Type = type;
            this.Data = data;
            if (!AllData.ContainsKey(type))
            {
                AllData.Add(type, new List<ElasticData>());
            }

            AllData[type].Add(this);
        }


        public static List<string> GetModelPrimaryKeys(string model, string primaryKey)
        {
            List<string> keys = new List<string>();
            foreach (var dictionary in AllData[model])
            {
                keys.Add(dictionary.Data[primaryKey].ToString());
            }

            return keys;
        }


        // public static List<Pattern> CreatePatterns(string modelName)
        // {
        //     List<Pattern> patterns = new List<Pattern>();
        //     foreach (var elasticData in allData[modelName])
        //     {
        //         List<ElasticData> data = new List<ElasticData>();
        //         data.Add(elasticData);
        //         var peopleRelation = GetElasticDataByModelAndPrimaryKey("PeopleRelation", "کدملی عضو خانواده",
        //             elasticData.Data["کدملی مالک"].ToString());
        //         data.Add(peopleRelation);
        //         var document =
        //             GetElasticDataByModelAndPrimaryKey("Document", "کد ملی", peopleRelation.Data["کدملی"].ToString());
        //         data.Add(document);
        //         patterns.Add(new Pattern(data));
        //     }
        //
        //     return patterns;
        // }

        public static ElasticData GetElasticDataByModelAndPrimaryKey(string modelName, string primaryKey,
            string propertyValue)
        {
            foreach (var elasticData in AllData[modelName])
            {
                if (elasticData.Data[primaryKey].ToString() == propertyValue)
                {
                    return elasticData;
                }
            }

            return default(ElasticData);
        }
    }
}