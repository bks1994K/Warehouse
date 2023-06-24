using System.Text.Json;

namespace Warehouse
{
    public class FileService<T>
    {
        private string _pathFile;

        // @".\pathFile.txt";

        public FileService(string pathFile)
        {
            _pathFile = pathFile;
        }

        public void RewriteFile(List<T> list)
        {
            using (StreamWriter file = new StreamWriter(_pathFile))
            {
                string serialiseForFile = JsonSerializer.Serialize(list);
                file.WriteLine(serialiseForFile);
            }
        }

        public List<T> ReturnFromFile()
        {
            if (File.Exists(_pathFile))
            {
                using (StreamReader file = new StreamReader(_pathFile))
                {
                    var deserialiseFromFile = file.ReadLine();

                    if (deserialiseFromFile is not null)
                    {
                        var result = JsonSerializer.Deserialize<List<T>>(deserialiseFromFile);

                        return result ?? new List<T>();
                    }
                }
            }

            return new List<T>();
        }
    }
}
