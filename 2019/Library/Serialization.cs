using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library {
    public class Serialization {
        public static void Serialize(string path, object obj) {
            var fs        = File.Create(path);
            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static object Deserialize(string path) {
            var fs        = File.OpenRead(path);
            var formatter = new BinaryFormatter();
            var array     = formatter.Deserialize(fs);
            fs.Close();
            return array;
        }
    }
}