using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ValidXmlDll
{
    static public class ValidXml
    {
        public static bool IsValid(string pathToXml, string pathToXsd)
        {
            try
            {
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add("", pathToXsd);
                XmlReader rd = XmlReader.Create(pathToXml);
                XDocument doc = XDocument.Load(rd);
                doc.Validate(schema, ValidationEventHandler);
            }
            catch { return false; }

            return true;
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }
    }
}
