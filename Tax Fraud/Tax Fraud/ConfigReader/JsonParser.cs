using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ConfigReader
{
    public class JsonParser
    {
        public JEnumerable<JToken> GetNodes(JToken jToken)
        {
            return jToken.First.First.Children();
        }

        public JEnumerable<JToken> GetNodeChildren(JToken jToken)
        {
            return jToken.Children();
        }

        public JEnumerable<JToken> GetLinks(JToken jToken)
        {
            return jToken.Last.First.Children();
        }

        public JEnumerable<JToken> GetLinkChildren(JToken jToken)
        {
            return jToken.Children();
        }
    }
}