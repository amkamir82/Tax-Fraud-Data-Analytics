using System;
using System.Collections.Generic;
using Nest;

namespace Entity
{
    public class ElasticData
    {
        static Dictionary<string, List<ElasticData>> allData =
            new Dictionary<string, List<ElasticData>>();

        private static
            Dictionary<ElasticData, Dictionary<ElasticData, List<ElasticData>>>
            resultObjects =
                new Dictionary<ElasticData, Dictionary<ElasticData, List<ElasticData>>>();

        public Dictionary<string, object> data;

        public ElasticData(string type, Dictionary<string, object> data)
        {
            this.data = data;
            if (!allData.ContainsKey(type))
            {
                allData.Add(type, new List<ElasticData>());
            }

            allData[type].Add(this);
        }


        public static List<string> GetModelPrimaryKeys(string model, string primaryKey)
        {
            List<string> keys = new List<string>();
            foreach (var dictionary in allData[model])
            {
                keys.Add(dictionary.data[primaryKey].ToString());
            }

            return keys;
        }

        public static void UpdateDocumentsResults(string firstModelName)
        {
            foreach (var data in allData[firstModelName])
            {
                resultObjects.Add(data, new Dictionary<ElasticData, List<ElasticData>>());
            }
        }

        public static void UpdateRelationsResults(string modelName)
        {
            foreach (var resultObject in resultObjects.Keys)
            {
                foreach (var elasticData in allData[modelName])
                {
                    if (elasticData.data["کدملی"].ToString() == resultObject.data["کد ملی"].ToString())
                    {
                        resultObjects[resultObject].Add(elasticData, new List<ElasticData>());
                    }
                }
            }
        }

        public static void UpdateCarsAndHousesResults(string modelName)
        {
            foreach (var resultObject in resultObjects.Values)
            {
                foreach (var resultObjectKey in resultObject.Keys)
                {
                    foreach (var elasticData in allData[modelName])
                    {
                        if (elasticData.data["کدملی مالک"].ToString() ==
                            resultObjectKey.data["کدملی عضو خانواده"].ToString())
                        {
                            resultObject[resultObjectKey].Add(elasticData);
                        }
                    }
                }
            }
        }

        public static Dictionary<ElasticData, Dictionary<ElasticData, List<ElasticData>>> GetResultObjects()
        {
            Dictionary<ElasticData, Dictionary<ElasticData, List<ElasticData>>> finalResult =
                new Dictionary<ElasticData, Dictionary<ElasticData, List<ElasticData>>>();
            foreach (var resultObjectsValue in resultObjects.Keys)
            {
                Dictionary<ElasticData, List<ElasticData>> value =
                    new Dictionary<ElasticData, List<ElasticData>>();
                foreach (var elasticData in resultObjects[resultObjectsValue].Keys)
                {
                    List<ElasticData> da = new List<ElasticData>();
                    foreach (var elasticData1 in resultObjects[resultObjectsValue][elasticData])
                    {
                        if (Int64.Parse(elasticData1.data["قیمت معامله"].ToString()) >= 90000000000)
                        {
                            da.Add(elasticData1);
                        }
                    }

                    if (da.Count != 0)
                    {
                        value.Add(elasticData, da);
                    }
                }

                if (value.Count != 0)
                {
                    finalResult.Add(resultObjectsValue, value);
                }
            }

            return finalResult;
        }
    }
}