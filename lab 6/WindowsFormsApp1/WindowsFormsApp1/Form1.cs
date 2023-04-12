using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IXmlData _xmlData;
        private IJsonData _jsonData;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _xmlData = new XmlData(textBox1.Text);
            _jsonData = new XmlToJsonAdapter(_xmlData);
            textBox2.Text = _jsonData.GetJson();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _jsonData = new JsonData(textBox1.Text);
            _xmlData = new JsonToXmlAdapter(_jsonData);
            textBox2.Text = _xmlData.GetXml();
        }
        class XmlData : IXmlData
        {
            private readonly string _xml;

            public XmlData(string xml)
            {
                _xml = xml;
            }

            public string GetXml()
            {
                return _xml;
            }
        }

        // JSON data class
        class JsonData : IJsonData
        {
            private readonly string _json;

            public JsonData(string json)
            {
                _json = json;
            }

            public string GetJson()
            {
                return _json;
            }
        }
    }
}
