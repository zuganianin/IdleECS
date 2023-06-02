using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Scripts.Services {
    public class PathBuilder
    {
        private readonly string _saveDirectory;

        public PathBuilder (string directory)
        {
            _saveDirectory = directory;
        }

        public string BuildPath(string key)
        {
            var builder = new StringBuilder();
            builder.Append(_saveDirectory);
            builder.Append("/");
            builder.Append(key);
            builder.Append(".dat");
            return builder.ToString();
        }
    }
}
