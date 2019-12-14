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
            Console.WriteLine("Программа расчета прибыли предприятия сельскохозяйственного предприятия...");
            Console.WriteLine("---------------------------------------------------------------------------");
            while (returnWhile)
            {
                Console.WriteLine("Выбирете что сделать дальше \n 1 - Прочитать значение из файла \n 2 - Записать новые значения");
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
                        //Изменение информации
                        do
                        {
                            answer = changeObject(enterprise);
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
        static public int changeObject(Enterprise[] enterprise)
        {
            int answer = 0;
            int answerEnterprise = 0;
            int answerProduction = 0;
            int answerSupply = 0;
            Console.WriteLine("Вы хотите изменить информацию о предприятии, поставке или закупке? 1 - предприятие 2 - закупка, 3 - поставка, все кроме этого продолжить ");
            answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    Console.WriteLine("Введите какое предприятие изменить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise] = new Enterprise();

                    break;
                case 2:
                    Console.WriteLine("Введите какое предприятие изменить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Введите какую закупку изменить?");
                    answerProduction = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise].productions[answerProduction] = new Production();
                    zerofication(enterprise, answerEnterprise);
                    enterprise[answerEnterprise].outlayProduction();
                    enterprise[answerEnterprise].outlaySupply();
                    enterprise[answerEnterprise].profitCallculating();
                    enterprise[answerEnterprise].netprofitCallculating();
                    enterprise[answerEnterprise].printInfo();
                    enterprise[answerEnterprise].productions[answerProduction].printInfo();
                    break;
                case 3:
                    Console.WriteLine("Введите какое предприятие изменить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Введите какую поставку изменить?");
                    answerSupply = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise].supplys[answerSupply] = new Supply();
                    zerofication(enterprise, answerEnterprise);
                    enterprise[answerEnterprise].outlayProduction();
                    enterprise[answerEnterprise].outlaySupply();
                    enterprise[answerEnterprise].profitCallculating();
                    enterprise[answerEnterprise].netprofitCallculating();
                    enterprise[answerEnterprise].printInfo();
                    enterprise[answerEnterprise].supplys[answerSupply].printInfo();
                    break;
                default:
                    Console.WriteLine("Применение изменений....");
                    break;
            }
            return answer;
        }
        //Необходимо обнулять предыдущие значения, чтобы при изменении данных предыдущие значения не доходили
        static public void zerofication(Enterprise[] enterprise, int answerEnterprise)
        {
            enterprise[answerEnterprise].outlay = 0;
            enterprise[answerEnterprise].income = 0;
            enterprise[answerEnterprise].profit = 0;
            enterprise[answerEnterprise].netprofit = 0;
        }
    }
}
