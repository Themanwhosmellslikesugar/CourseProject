using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cursovaya
{
    class Files
    {
        public string dir;
        public DirectoryInfo directory;
        public void createDirectory()
        {
            dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            directory = Directory.CreateDirectory("DIR");
        } 
        public void cleanDirectory()
        {
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                cleanFiles(d);
                d.Delete();
            }
        }
        public void cleanFiles(DirectoryInfo dir)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }
        }
        public void fileWriterType(string filePath, TypeOfOwnership type)
        {
            StreamWriter sw = new StreamWriter("DIR\\"+filePath+".txt", false, System.Text.Encoding.UTF8);
            sw.WriteLine($"Вид продукции: {type.getTypeOfOwnership()}");
            sw.Close();
        }
        public void fileWriterEnterprise(string filePath, Enterprise enterprise)
        {
            StreamWriter sw = new StreamWriter("DIR\\"+filePath + ".txt", false, System.Text.Encoding.UTF8);
            sw.WriteLine($"Наименование предприятия: {enterprise.getEnterpriseName()}");
            sw.WriteLine($"Дата регистрации: {enterprise.getDate()}");
            sw.WriteLine($"Кол - во работников: {enterprise.getAmountOfWorkers()}");
            sw.WriteLine($"Основной вид продукции: {enterprise.getMainTypeOfProduct()}");
            sw.WriteLine($"Является ли передовым в освоении новой технологии: {enterprise.getAdvanced()}");
            sw.WriteLine($"Прибыль балансовая: {enterprise.profit}");
            sw.WriteLine($"Прибыль чистая: {enterprise.netprofit}");
            sw.Close();
        }
        public void fileWriterProduction(string filePath, Production production)
        {
            StreamWriter sw = new StreamWriter("DIR\\" + filePath + ".txt", false, System.Text.Encoding.UTF8);
            sw.WriteLine($"Наименование продукции: {production.nameOfProduction}");
            sw.WriteLine($"Единица измерения: {production.measure}");
            sw.WriteLine($"Закупочная цена: {production.purchasePrice}");
            sw.WriteLine($"Объем закупки: {production.purchaseVolume}");
            sw.Close();
        }
        public void fileWriterSupply(string filePath, Supply supply)
        {
            StreamWriter sw = new StreamWriter("DIR\\" + filePath + ".txt", false, System.Text.Encoding.UTF8);
            sw.WriteLine($"Дата поставки: {supply.getDateOfSupply()}");
            sw.WriteLine($"Объем поставки: {supply.scopeOfSupply}");
            sw.WriteLine($"Себестоимость поставки: {supply.costOfSupply}");
            sw.WriteLine($"Цена реализации: {supply.sellingPrice}");
            sw.Close();
        }
        //READ
        public void fileReaderType(string filePath)
        {
            StreamReader sr = new StreamReader("DIR\\" + filePath + ".txt");
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }
        public void fileReaderEnterprise(string filePath)
        {
            StreamReader sr = new StreamReader("DIR\\" + filePath + ".txt");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
        public void fileReaderProduction(string filePath)
        {
            StreamReader sr = new StreamReader("DIR\\" + filePath + ".txt");
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }
        public void fileReaderSupply(string filePath)
        {
            StreamReader sr = new StreamReader("DIR\\" + filePath + ".txt");
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }
    }
}
