using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Services
{
    public class SaveLoadService : ISaver, ILoader
    {
        private ISaver _saver;
        private ILoader _loader;
        public SaveLoadService()
        {
            BinarySaveLoad saveLoader = new BinarySaveLoad(Application.persistentDataPath);
            _saver = saveLoader;
            _loader = saveLoader;
        }

        public T Load<T>(string dataName)
        {
            return _loader.Load<T>(dataName);
        }

        public void Save<T>(string path, T data)
        {
            _saver.Save<T>(path,data);
        }
    }

}
