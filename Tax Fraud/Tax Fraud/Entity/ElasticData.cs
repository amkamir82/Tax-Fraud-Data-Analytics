using System.Collections.Generic;

namespace Entity
{
    public class ElasticData
    {
        private static List<Node> Models = new List<Node>();
        static Dictionary<string, List<ElasticData>> allData = new Dictionary<string, List<ElasticData>>();
        private Dictionary<string, string> _datInformation;

        public ElasticData(string type)
        {
            var model = Node.GetNodeByName(type);

            //now we will get the attributes of model

            _datInformation = new Dictionary<string, string>();
            foreach (var attributesKey in model.Attributes.Keys)
            {
                //ToDo
                _datInformation.Add(attributesKey, "dataInformation");
            }

            if (allData[type] == null)
            {
                allData[type] = new List<ElasticData>();
            }

            allData[type].Add(this);
        }
    }
}