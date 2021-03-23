using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DetailMaterialEntityClass.XmlUtils
{
    public class XmlUtil
    {
        public static string ObjectToXml(object obj, bool toBeIndented, Type type)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            UTF8Encoding encoding = new UTF8Encoding(false);
            XmlSerializer serializer = new XmlSerializer(type);
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, encoding);
            writer.Formatting = (toBeIndented ? Formatting.Indented : Formatting.None);
            serializer.Serialize(writer, obj);
            string xml = encoding.GetString(stream.ToArray());
            writer.Close();
            return xml;
        }

        public static object XmlToObject(string xml, Type type)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            object o = null;
            XmlSerializer serializer = new XmlSerializer(type);
            StringReader strReader = new StringReader(xml);
            XmlReader reader = new XmlTextReader(strReader);
            try
            {
                o = serializer.Deserialize(reader);
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                reader.Close();
            }
            return o;
        }
    }

}
