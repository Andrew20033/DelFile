using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string appRoot = AppDomain.CurrentDomain.BaseDirectory;
            if (!appRoot.EndsWith("\\")) appRoot += "\\";
            SortedSet<string> namesToIgnore = new SortedSet<string>(StringComparer.OrdinalIgnoreCase) {
    "1.txt",
    "Launcher.exe",
    "MasterList"
};
            DirectoryInfo appRootDir = new DirectoryInfo(appRoot);
            foreach (FileSystemInfo info in appRootDir.EnumerateFileSystemInfos(appRoot, "*.*", SearchOption.AllDirectories))
            {
                string name = info.FullName.Substring(appRoot.Length);
                if (!namesToIgnore.Contains(name))
                {
                    info.Delete();
                }
            }
        }
    }
}
