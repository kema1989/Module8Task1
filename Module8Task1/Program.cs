using System;
using System.IO;

namespace Module8Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\YOGA\Desktop\WaitingForDeath");
            try
            {
                if (directory.Exists)
                {
                    Delete(directory);
                }
                else
                {
                    Console.WriteLine("Такой папки нет...");
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("Нет прав доступа...");
                }
            }
        }

        static void Delete(DirectoryInfo dirSpace)
        {
            foreach (FileInfo file in dirSpace.GetFiles())
            {
                var thirty = DateTime.Now - file.LastAccessTime;
                if (thirty > TimeSpan.FromMinutes(30))
                {
                    file.Delete();
                }
            }
            foreach (DirectoryInfo papka in dirSpace.GetDirectories())
            {
                Delete(papka);
                papka.Delete();
            }
        }
    }
}
