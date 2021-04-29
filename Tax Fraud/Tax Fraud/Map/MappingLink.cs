using System;
using System.Collections.Generic;
using Entity;

namespace Map
{
    public class MappingLink
    {
        private string _name;
        private Node _source;
        private Node _destination;
        private Dictionary<MappingNode, string> _attributes;

        public MappingLink(string name, string sourceName, string destinationName)
        {
            _name = name;
            _source = Node.GetNodeByName(sourceName);
            _destination = Node.GetNodeByName(destinationName);
            _attributes = new Dictionary<MappingNode, string>();
        }

        public void AddAttribute(string node, string indexName)
        {
            _attributes.Add(MappingNode.GetNodeByName(node), indexName);
        }
    }
}