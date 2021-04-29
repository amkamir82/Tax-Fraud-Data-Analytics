using System.Collections.Generic;

namespace Program
{
    public class Nodes
    {
        
        
        public Nodes(string type, Dictionary<string, string> attribtes)
        {
            Type = type;
            Attributes = attribtes;
        }

        public string Type { get; }

        public Dictionary<string, string> Attributes { get; }
    }
}