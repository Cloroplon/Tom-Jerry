using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
/// <summary>
/// We will use it to load and save our states.
/// </summary>
namespace TomAndJerry
{
    public class XMLManager<T>
    {
        public Type Type { get; set; }

        public XMLManager()
        {
            this.Type = typeof (T);
        } 

        public T Load(string path)
        {
            T instance;
            using (TextReader text = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T) xml.Deserialize(text);
            }
            return instance;
        }

        public void Save(string path, object obj)
        {
            using (TextWriter textWriter = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(textWriter, obj);
            }
        }
    }
}
