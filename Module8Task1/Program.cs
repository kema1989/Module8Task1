using System;
using System.IO;

namespace Module8Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\YOGA\Desktop\Кема2курс\Физика3семестр");
            try
            {
                if (directory.Exists)
                {
                    DateTime thirty = DateTime.Now - TimeSpan.FromMinutes(300);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.LastAccessTime < thirty)
                        {
                            file.Delete();
                        }
                    }
                    foreach (DirectoryInfo papka in directory.GetDirectories())
                    {
                        if (papka.LastAccessTime < thirty)
                        {
                            papka.Delete(true);
                        }
                    }
                }
                else
                {
                    throw new Exception("Такой папки не существует");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
