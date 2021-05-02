using System.Collections.Generic;

namespace Entity
{
    public class ElasticData
    {
        static Dictionary<string, List<ElasticData>> allData = new Dictionary<string, List<ElasticData>>();
        private Dictionary<string, string> _dataInformation;

        public ElasticData(string type)
        {
            var model = Node.GetNodeByName(type);

            //now we will get the attributes of model

            _dataInformation = new Dictionary<string, string>();
            foreach (var attributesKey in model.Attributes.Keys)
            {
                //ToDo
                _dataInformation.Add(attributesKey, "dataInformation");
            }

            if (allData[type] == null)
            {
                allData[type] = new List<ElasticData>();
            }

            allData[type].Add(this);
        }
    }
}