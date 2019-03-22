
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressDistance
{
    public static class Extensions
    {
        public static String NameWithoutExtension(this FileSystemInfo fsi)
        {
            FileAttributes attributes = File.GetAttributes(fsi.FullName);
            if (attributes.HasFlag(FileAttributes.Directory))
                return new DirectoryInfo(fsi.FullName).Name;
            else
                return new FileInfo(fsi.FullName).NameWithoutExtension();
        }
        public static String NameWithoutExtension(this FileInfo f)
        {
            Int32 extensionPosition = f.Name.LastIndexOf(f.Extension, StringComparison.Ordinal);
            if (extensionPosition > 0)
                return f.Name.Substring(0, extensionPosition);
            return f.Name;
        }

    }
}
