using System;
using System.Collections.Generic;
using System.Linq;
using ConfigReader;
using Newtonsoft.Json.Linq;
using Entity;
using Map;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            RunModelsAndLinks();
            RunRelations();
        }

        static void RunModelsAndLinks()
        {
            var fileReader = new FileReader("Ontology.json");
            fileReader.LoadJsonFile();
            var jsonObject = fileReader.GetJsonObject();
            FindNodes(jsonObject);
            FindLinks(jsonObject);
        }

        static void FindNodes(JToken jsonObject)
        {
            var parser = new JsonParser();
            var nodes = parser.GetNodes(jsonObject).ToList();
            InitialiseModels(parser, nodes);
        }

        static void InitialiseModels(JsonParser parser, List<JToken> nodes)
        {
            foreach (var jToken in nodes)
            {
                var model = parser.GetNodeChildren(jToken).ToList();
                var modelName = model[0].First.ToString();
                var entity = new Node(modelName);
                var modelAttributes = model[1].First.Children().ToList();
                foreach (var modelAttribute in modelAttributes)
                {
                    entity.AddAttribute(modelAttribute.First.First.ToString(), modelAttribute.Last.First.ToString());
                }
            }
        }

        static void FindLinks(JToken jsonObject)
        {
            var parser = new JsonParser();
            var links = parser.GetLinks(jsonObject).ToList();
            InitialiseLinks(parser, links);
        }

        static void InitialiseLinks(JsonParser parser, List<JToken> links)
        {
            foreach (var jToken in links)
            {
                var link = parser.GetLinkChildren(jToken).ToList();
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

        static void RunRelations()
        {
            var fileReader = new FileReader("Relations.json");
            fileReader.LoadJsonFile();
            var jsonObject = fileReader.GetJsonObject();
            FindMappingNodes(jsonObject);
            FindMappingLinks(jsonObject);
        }

        static void FindMappingNodes(JToken jsonObject)
        {
            var parser = new JsonParser();
            var mappingNodes = parser.GetNodes(jsonObject).ToList();
            InitialiseMappingNodes(parser, mappingNodes);
        }

        static void InitialiseMappingNodes(JsonParser parser, List<JToken> nodes)
        {
            foreach (var jToken in nodes)
            {
                var model = parser.GetNodeChildren(jToken).ToList();
                var name = model[0].First.ToString();
                var dataModelName = model[1].First.ToString();
                var entity = new MappingNode(name, dataModelName);
                var modelAttributes = model[2].First.Children().ToList();
                foreach (var modelAttribute in modelAttributes)
                {
                    entity.AddAttribute(modelAttribute.First.ToString(), modelAttribute.First.Next.ToString(),
                        modelAttribute.Last.ToString());
                }
            }
        }

        static void FindMappingLinks(JToken jsonObject)
        {
            var parser = new JsonParser();
            var mappingLinks = parser.GetLinks(jsonObject).ToList();
            InitialiseMappingLinks(parser, mappingLinks);
        }

        static void InitialiseMappingLinks(JsonParser parser, List<JToken> nodes)
        {
            foreach (var jToken in nodes)
            {
                var model = parser.GetLinkChildren(jToken).ToList();
                var name = model[0].First.ToString();
                var sourceNode = model[1].First.ToString();
                var destinationNode = model[2].First.ToString();
                var entity = new MappingLink(name, sourceNode, destinationNode);


                var attributes = model[2].First.Children().ToList();
                foreach (var attribute in attributes)
                {
                    entity.AddAttribute(attribute.First.ToString(), attribute.Last.ToString());
                }
            }
        }
    }
}