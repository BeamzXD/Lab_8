using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь поиска:");
        string path = Console.ReadLine();

        Console.WriteLine("Введите имя файла для поиска:");
        string filename = Console.ReadLine();

        string filePath = FindFile(path, filename);
        if (filePath != null)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            Console.WriteLine("Содержимое файла");
            Console.WriteLine(reader.ReadToEnd());

            // Сжатие файла
            string compressedFilePath = filePath + ".gz";
            using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open))
            using (FileStream compressedFileStream = new FileStream(compressedFilePath, FileMode.Create))
            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
            {
                originalFileStream.CopyTo(compressionStream);
            }

            Console.WriteLine($"Файл успешно сжат: {compressedFilePath}");
        }
        else{
            Console.WriteLine("Файл не найден");
        }
        
    }

    static string FindFile(string path, string filename)
    {
        try
        {
            foreach (string file in Directory.GetFiles(path, filename, SearchOption.AllDirectories)){
                return file;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        return null;
    }
}
