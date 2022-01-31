using System;
using System.Collections.Generic;
using Entity;

namespace Map
{
    public class MappingNode
    {
        private string _name;
        private Node _model;
        private Dictionary<string, Dictionary<string, string>> _attributes;
        static List<MappingNode> Nodes { get; } = new List<MappingNode>();

        public MappingNode(string name, string modelName)
        {
            _name = modelName;
            _model = Node.GetNodeByName(modelName);
            _attributes = new Dictionary<string, Dictionary<string, string>>();
            Nodes.Add(this);
        }

        public void AddAttribute(string field, string columnName, string isPrimaryKey)
        {
            _attributes.Add(field, new Dictionary<string, string>());
            _attributes[field].Add(columnName, isPrimaryKey);
        }

        public static MappingNode GetNodeByName(string name)
        {
            foreach (var node in Nodes)
            {
                if (node._name == name)
                {
                    return node;
                }
            }

            return null;
        }
    }
}