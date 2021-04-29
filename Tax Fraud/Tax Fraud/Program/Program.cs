using System;
using System.Collections.Generic;
using System.Linq;
using ConfigReader;
using Newtonsoft.Json.Linq;
using Entity;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            RunModelsAndLinks();
            RunRelations();
        }

        public static void RunModelsAndLinks()
        {
            var fileReader = new FileReader("ontology.json");
            fileReader.LoadJsonFile();
            var jsonObject = fileReader.GetJsonObject();
            FindNodes(jsonObject);
            FindLinks(jsonObject);
        }

        public static void FindNodes(JToken jsonObject)
        {
            var parser = new JsonParser();
            var nodes = parser.GetNodes(jsonObject).ToList();
            InitialiseModels(parser, nodes);
        }

        public static void InitialiseModels(JsonParser parser, List<JToken> nodes)
        {
            foreach (var jToken in nodes)
            {
                var model = parser.GetNodeChildes(jToken).ToList();
                var modelName = model[0].First.ToString();
                var entity = new Node(modelName);
                var modelAttributes = model[1].First.Children().ToList();
                foreach (var modelAttribute in modelAttributes)
                {
                    entity.AddAttribute(modelAttribute.First.First.ToString(), modelAttribute.Last.First.ToString());
                }
            }
        }

        public static void FindLinks(JToken jsonObject)
        {
            var parser = new JsonParser();
            var links = parser.GetLinks(jsonObject).ToList();
            InitialiseLinks(parser, links);
        }

        public static void InitialiseLinks(JsonParser parser, List<JToken> links)
        {
            foreach (var jToken in links)
            {
                // Console.WriteLine();
                var link = parser.GetLinkChildes(jToken).ToList();
                var linkName = link[0].First.ToString();
                var source = link[1].First.ToString();
                var destination = link[2].First.ToString();
                var entity = new Link(linkName, source, destination);
                var modelAttributes = link[3].First.Children().ToList();
                foreach (var modelAttribute in modelAttributes)
                {
                    entity.AddAttribute(modelAttribute.First.First.ToString(), modelAttribute.Last.First.ToString());
                }
            }
        }

        public static void RunRelations()
        {
        }
    }
}