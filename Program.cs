using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BatchExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"D:\dropbox\cdn3.struffelproductions.com");
            var allZips = Directory.GetFiles(".", "*.zip", SearchOption.AllDirectories);
            foreach (var zip in allZips)
            {
                try
                {
                    var dir = Path.GetDirectoryName(zip);
                    var outDir = Path.Join(dir, Path.GetFileNameWithoutExtension(zip));
                    Directory.CreateDirectory(outDir);
                    ZipFile.ExtractToDirectory(zip, outDir, overwriteFiles: true);
                    File.Delete(zip);
                }
                catch (Exception)
                {
                    Console.Error.WriteLine(zip + " failed");
                }

            }
            Console.WriteLine(allZips.Length);
        }
    }
}
