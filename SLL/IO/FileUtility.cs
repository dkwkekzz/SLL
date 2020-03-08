using System;
using System.Collections.Generic;
using System.IO;

namespace SLL.IO
{
    public static class FileUtility
    {
        public static IList<string> GetFiles(string path, Predicate<string> filter = null)
        {
            var list = new List<string>();

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                var subList = GetFiles(dir, filter);
                list.AddRange(subList);
            }

            var files = Directory.GetFiles(path);
            var filesLen = files.Length;
            for (int i = 0; i != filesLen; i++)
            {
                var file = files[i];
                if (filter == null || filter(file))
                    list.Add(file);
            }

            return list;
        }
    }
}
