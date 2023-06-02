
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Scripts.Services {
    public class BinarySaveLoad : ISaver, ILoader
    {
        private readonly string _saveDirectory;
        private readonly PathBuilder _pathBuilder;
        private readonly BinaryFormatter _formatter;
        public BinarySaveLoad(string pathToData)
        {
            _saveDirectory = pathToData;
            _pathBuilder = new PathBuilder(pathToData);
            _formatter = GetFormatter();
        }

        private BinaryFormatter GetFormatter()
        {
            var formatter = new BinaryFormatter();
            return formatter;
        }

        public void Save<T>(string path, T data) 
        {
            Directory.CreateDirectory(_saveDirectory);
            var savePath = _pathBuilder.BuildPath(path);
            using (FileStream stream = File.Create(savePath))
            {
                _formatter.Serialize(stream, data);
            }
        }

        public T Load<T>(string path)
        {
            string filePath = _pathBuilder.BuildPath(path);
            T returnObj;
            try 
            {
                using (FileStream file = File.Open(filePath, FileMode.Open))
                {
                    object loadedData = _formatter.Deserialize(file);
                    returnObj = (T)loadedData;
                }
            }
            catch 
            {
                return default(T);
            }
            return returnObj;
        }
    }
}