using System.Collections.Generic;

namespace Entity
{
    public class ElasticData
    {
        static Dictionary<string, List<Dictionary<string, object>>> allData =
            new Dictionary<string, List<Dictionary<string, object>>>();

        public ElasticData(string type, Dictionary<string, object> data)
        {
            if (!allData.ContainsKey(type))
            {
                allData.Add(type, new List<Dictionary<string, object>>());
            }

            allData[type].Add(data);
        }


        public static List<string> GetModelPrimaryKeys(string model, string primaryKey)
        {
            List<string> codes = new List<string>();
            foreach (var dictionary in allData[model])
            {
                codes.Add(dictionary[primaryKey].ToString());
            }

            return codes;
        }
    }
}