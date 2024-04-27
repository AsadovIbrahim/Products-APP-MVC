using System.Text.Json;

namespace Products_Project.Models
{
    public class JsonHandler
    {
        public static void WriteData<T>(T? list, string filename)
        {
            JsonSerializerOptions op = new();
            op.WriteIndented = true;
            File.WriteAllText(filename + ".json", JsonSerializer.Serialize(list, op));
        }

        public static T? ReadData<T>(string filename) where T : new()
        {
            T? readData = new T();

            JsonSerializerOptions op = new JsonSerializerOptions();
            op.WriteIndented = true;
            using FileStream fs = new FileStream(filename + ".json", FileMode.OpenOrCreate);
            if (fs.Length != 0) readData = JsonSerializer.Deserialize<T>(fs, op);

            return readData;
        }
    }
}
