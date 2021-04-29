using System.IO;
using Newtonsoft.Json.Linq;

namespace ConfigReader
{
    public class FileReader
    {
        private string _fileName;
        private JObject _jObject;

        public FileReader(string fileName)
        {
            _fileName = fileName;
        }

        public void LoadJsonFile()
        {
            _jObject = JObject.Parse(File.ReadAllText(_fileName));
        }

        public JToken GetJsonObject()
        {
            return _jObject;
        }
    }
}