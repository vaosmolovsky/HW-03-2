using System;


namespace HW2
{
    public class SpaceOnDisk
    {
        public static void Main()
        {
            Console.WriteLine("Введите путь к папке:");
            string filePath = Console.ReadLine();
            double answer = Space(0, filePath);
            Console.WriteLine(answer);
        }
        public static double Space(double size, string filePath)
        {
            double size1 = size;
            var di = new DirectoryInfo(filePath);
            try
            {
                if (di.Exists)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        size1 += file.Length;
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        string path = dir.FullName;
                        size1 += Space(size, path);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size1;
        }
    }
}