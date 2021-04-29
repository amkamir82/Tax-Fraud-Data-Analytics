using System;
using System.Collections.Generic;

namespace Entity
{
    public class Link
    {
        public static List<Link> Links { get; } = new List<Link>();
        private string _linkName;
        private string _source;
        private string _destination;
        private Dictionary<string, string> _attributes;

        public Link(string modelName, string source, string destination)
        {
            _linkName = modelName;
            _source = source;
            _destination = destination;
            _attributes = new Dictionary<string, string>();
            Links.Add(this);
        }

        public void AddAttribute(string field, string type)
        {
            _attributes.Add(field, type);
        }

        public string LinkName
        {
            get { return _linkName; }
        }

        public string Source
        {
            get { return _source; }
        }

        public string Destination
        {
            get { return _destination; }
        }

        public Dictionary<string, string> Attributes
        {
            get { return _attributes; }
        }
    }
}