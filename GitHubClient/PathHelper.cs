using System;
using System.IO;

namespace MHanafy.GithubClient
{
    public static class PathHelper
    {
        private static string _baseDir;

        private static string BaseDir
        {
            get
            {
                if (_baseDir != null) return _baseDir;
                _baseDir = AppDomain.CurrentDomain.BaseDirectory.EndsWith("\\")
                    ? AppDomain.CurrentDomain.BaseDirectory
                    : AppDomain.CurrentDomain.BaseDirectory + "\\";
                return _baseDir;
            }
        }
        public static string GetFullPath(string path)
        {
            if (Path.IsPathRooted(path)) return path;
            return BaseDir + path;
        }
    }
}
