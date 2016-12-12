using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace RSSE
{

    public class PersistableObject
    {
        public static T Load<T>(string fileName) where T : PersistableObject, new()
        {
            T result = default(T);

            using (FileStream stream = File.OpenRead(fileName))
            {
                result = new XmlSerializer(typeof(T)).Deserialize(stream) as T;
            }

            return result;
        }

        public void Save<T>(string fileName) where T : PersistableObject
        {
            using (FileStream stream = new FileStream(fileName, FileMode.CreateNew))
            {
                new XmlSerializer(typeof(T)).Serialize(stream, this);
            }
        }
    }
}
