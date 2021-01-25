using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string extractPath = @"../../../ExtractIn";

            using (FileStream fs = new FileStream(@"../../../ZipIn/file.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (ZipArchive za = new ZipArchive(fs, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry1 = za.CreateEntryFromFile("../../../copyMe.png", "picture.png");

                    za.ExtractToDirectory("../../../ExtractIn", true);
                }
            }
        }
    }
}
