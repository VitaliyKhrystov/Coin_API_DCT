using System.IO;
using System.Net;


namespace Coin_API__DCT.Models
{
    public class JsonFile
    {
        public string API { get; set; }
        public string FilePath { get; set; } = "Files/file.json";

        public JsonFile(string api)
        {
            API = api;
        }

        public void GetJsonFile()
        {
            string json;

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString(API);

            }

            int v = json.IndexOf('[');
            int v2 = json.IndexOf(']');

            json = json.Substring(v, v2 + 1);

            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);

            var writer = new BinaryWriter(fileStream);

            foreach (var item in json)
            {
                writer.Write(item);

                if (item == ']')
                {
                    break;
                }
            }

            writer.Close();
            fileStream.Close();
        }
    }
}
