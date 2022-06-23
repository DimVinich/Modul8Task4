using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string nFileGroup;

            // запросить файл с валидацией
            string file = @"D:\Temp\Students.dat";
            Console.WriteLine("Введите имя файла со списком студентов :");
            //string file = Console.ReadLine();

            if (!File.Exists(file))
            {
                Console.WriteLine(" Указанный Вами файл не существует. Программа прекращает свою работу.");
                Console.ReadKey();
                return;
            }

            // Пересоздаём папку на раб.столе
            string desctopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Students/";
            if (Directory.Exists(desctopDir))
            {
                Directory.Delete(desctopDir, true);
            }
            Directory.CreateDirectory(desctopDir);

            //  десcерилизовать его файл
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(file, FileMode.Open))
            {
                    Student[] arrStudent = (Student[])formatter.Deserialize(fs);

                // Перебор списка в цикле
                foreach (Student student in arrStudent)
                {

                    //  - проверить что такой файл есть  - нетю - генерить новый файл с имененм группы - есть - открыть его
                    nFileGroup = desctopDir + student.Group + ".txt";

                    var fileGroup = new FileInfo(nFileGroup);
                    if (fileGroup.Exists)
                    {
                        using (StreamWriter sw = fileGroup.AppendText())
                        {
                            sw.WriteLine($"Имя: {student.Name} --- Дата рождения: {student.DateOfBirth}");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = fileGroup.CreateText())
                        {
                            sw.WriteLine($"Имя: {student.Name} --- Дата рождения: {student.DateOfBirth}");
                        }
                    }

                }
            }


            Console.ReadKey();
        }
    }
}
