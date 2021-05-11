using System.Collections.Generic;
using System;

namespace Entity
{
    public class Pattern
    {
        public List<ElasticData> Nodes { get; set; }
        public string Id { get; set; }

        public Pattern(List<ElasticData> nodes, string id)
        {
            Nodes = nodes;
            Id = Guid.NewGuid().ToString();
        }
    }
}
