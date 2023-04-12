using System;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    // Interfaces for XML data and JSON data
    interface IXmlData
    {
        string GetXml();
    }

    interface IJsonData
    {
        string GetJson();
    }

    // XML to JSON adapter
    class XmlToJsonAdapter : IJsonData
    {
        private readonly IXmlData _xmlData;

        public XmlToJsonAdapter(IXmlData xmlData)
        {
            _xmlData = xmlData;
        }

        public string GetJson()
        {
            // Convert XML to JSON
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(_xmlData.GetXml());
            return JsonConvert.SerializeXmlNode(xmlDoc);
        }
    }

    // JSON to XML adapter
    class JsonToXmlAdapter : IXmlData
    {
        private readonly IJsonData _jsonData;

        public JsonToXmlAdapter(IJsonData jsonData)
        {
            _jsonData = jsonData;
        }

        public string GetXml()
        {
            // Convert JSON to XML
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(_jsonData.GetJson());
            return xmlDoc.InnerXml;
        }
    }
}
