using System.Collections.Generic;

namespace Entity
{
    public class GraphDataResult
    {
        private List<ElasticData> resultObject;

        public GraphDataResult()
        {
            this.resultObject = new List<ElasticData>();
        }

        public void AddDataForResultObject(ElasticData elasticData)
        {
            this.resultObject.Add(elasticData);
        }
        
        
    }
}
