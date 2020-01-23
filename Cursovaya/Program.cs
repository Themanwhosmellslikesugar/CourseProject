using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.IO;
namespace Cursovaya
{
    class Program
    {
        static void Main(string[] args)
        {

            int count;
            int answer;
            int globalAnswer = 0;
            bool returnWhile = true;
            Files file = new Files();
            //test block
            string test_filename;
            string value;
            Console.WriteLine("Введите название файла:");
            test_filename = Console.ReadLine();
            SaveManager saveFile = new SaveManager(test_filename);
            Console.WriteLine("Что записать?");
            value = Console.ReadLine();
            saveFile.WriteLine(value);
            Test_WritableObj test = new Test_WritableObj();
            test.subject = "test";
            test.number = 21;
            test.Write(saveFile);
            //end.
            Console.WriteLine("Программа расчета прибыли предприятия сельскохозяйственного предприятия...");
            Console.WriteLine("---------------------------------------------------------------------------");
            while (returnWhile)
            {
                Console.WriteLine("Выберете что сделать дальше \n 1 - Прочитать значение из файла \n 2 - Записать новые значения \n 0 - ВЫХОД");
                globalAnswer = int.Parse(Console.ReadLine());
                switch (globalAnswer)
                {
                    case 1:
                        //Чтение из файлов
                        file.createDirectory();
                        readFile(file);
                        break;
                    case 2:
                        Console.WriteLine("Введите кол - во сельскохозяйственных предприятий: ");
                        do
                        {
                            count = int.Parse(Console.ReadLine());
                            if (count <= 0)
                            {
                                Console.WriteLine("Введено неверное число, попробуйте заново");
                            }
                        } while (count <= 0);

                        Enterprise[] enterprise = new Enterprise[count];
                        for (int i = 0; i < count; i++)
                        {
                            enterprise[i] = new Enterprise();
                            Console.WriteLine("----------------------------------------");

                        }
                        Console.WriteLine("Что вы хотите сделать? \n 1 - Изменить введеную ифнормациию \n 2 - Добавить информацию \n 3 - Удалить ифнормацию \n 0 - ПРОДОЛЖИТЬ ");
                        answer = int.Parse(Console.ReadLine());
                        do
                        {
                            switch (answer)
                            {
                                //Изменение информации
                                case 1:
                                    do
                                    {
                                        answer = ChangeInfo.changeObject(enterprise);
                                    } while (answer != 0);
                                    break;
                                //Добавление ифнормации
                                case 2:
                                    do
                                    {
                                        answer = ChangeInfo.AddObject(enterprise);
                                    } while (answer != 0);
                                    break;
                                //Удаление информации
                                case 3:
                                    do
                                    {
                                        answer = ChangeInfo.DeleteObject(enterprise);
                                    } while (answer != 0);
                                    break;
                            }
                        } while (answer != 0);
                        //Запись в файл
                        writeInFile(count, enterprise, file);
                        break;
                
                    default:
                        returnWhile = false;
                        break;
                }
            }
        }
        static public void writeInFile(int count, Enterprise[] enterprise, Files file)
        {
            file.createDirectory();
            file.cleanDirectory();
            for (int i = 0; i < count; i++)
            {
                DirectoryInfo dir;
                dir = Directory.CreateDirectory($@"{file.dir}\DIR\enterprise{i}");
                file.fileWriterEnterprise($"enterprise{i}\\enterprise{i}", enterprise[i]);
                file.fileWriterType($"enterprise{i}\\type{i}", enterprise[i].type);
                for (int j = 0; j < enterprise[i].productions.Count; j++)
                {
                    file.fileWriterProduction($"enterprise{i}\\enterprise{i}production{j}", enterprise[i].productions[j]);
                }
                for (int j = 0; j < enterprise[i].supplys.Count; j++)
                {
                    file.fileWriterSupply($"enterprise{i}\\enterprise{i}supply{j}", enterprise[i].supplys[j]);
                }
            }
            Console.WriteLine("Запись завершена!");
        }
        static public void readFile(Files file)
        {
            
            int i = 0;
            foreach (DirectoryInfo d in file.directory.GetDirectories())
            {
                Console.WriteLine($"Предприятие № {i}");
                file.fileReaderEnterprise($"enterprise{i}\\enterprise{i}");
                file.fileReaderType($"enterprise{i}\\type{i}");
                Console.WriteLine("ЗАКУПКИ:");
                string[] searchProduction = Directory.GetFiles($@"{file.dir}\DIR\enterprise{i}\", $"enterprise{i}production*");
                string[] searchSupply = Directory.GetFiles($@"{file.dir}\DIR\enterprise{i}\", $"enterprise{i}supply*");
                int j = 0;
                foreach (string f in searchProduction)
                {
                    Console.WriteLine($"Закупка № {j}");
                    file.fileReaderProduction($"enterprise{i}\\enterprise{i}production{j}");
                    Console.WriteLine("******************************");
                    j++;
                }
                Console.WriteLine("ПОСТАВКИ:");
                j = 0;
                foreach (string f in searchSupply)
                {
                    Console.WriteLine($"Поставка № {j}");
                    file.fileReaderSupply($"enterprise{i}\\enterprise{i}supply{j}");
                    Console.WriteLine("******************************");
                    j++;
                }
                i++;
            }
            Console.WriteLine("Чтение завершено");
        }
    }
}
