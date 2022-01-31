using System;
using System.Collections.Generic;

namespace Entity
{
    public class Node
    {
        public static List<Node> Nodes { get; } = new List<Node>();
        private string _modelName;
        private Dictionary<string, string> _attributes;
        private string _primaryKey;

        public Node(string modelName)
        {
            _modelName = modelName;
            _attributes = new Dictionary<string, string>();
            Nodes.Add(this);
        }

        public void AddAttribute(string field, string type)
        {
            _attributes.Add(field, type);
        }

        public string ModelName
        {
            get { return _modelName; }
        }

        public Dictionary<string, string> Attributes
        {
            get { return _attributes; }
        }

        public static Node GetNodeByName(string name)
        {
            foreach (var node in Nodes)
            {
                if (node._modelName == name)
                {
                    return node;
                }
            }

            return null;
        }
    }
}