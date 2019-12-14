using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
    class Supply
    {
        private DateTime dateOfSupply;
        public int scopeOfSupply;
        public float costOfSupply;
        public float sellingPrice;
        public Supply()
        {
            scopeOfSupply = 0;
            costOfSupply = 0;
            sellingPrice = 0;
            int month = 0;
            int day = 0;
            Console.WriteLine("Введите месяц поставки: ");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите день поставки: ");
            day = int.Parse(Console.ReadLine());
            dateOfSupply = new DateTime(2019, month, day);
            Console.WriteLine("Введите объем поставки: ");
            do
            {
                scopeOfSupply = int.Parse(Console.ReadLine());
                if(scopeOfSupply <= 0)
                {
                    Console.WriteLine("Неверно введен объем поставки, попробуйте заново");
                }
            } while (scopeOfSupply <= 0);
            Console.WriteLine("Введите себестоимость поставки: ");
            do
            {
                costOfSupply = int.Parse(Console.ReadLine());
                if (costOfSupply <= 0)
                {
                    Console.WriteLine("Неверна введена себестоимость поставки, try again");
                }
            } while (costOfSupply <= 0);
            Console.WriteLine("Введите цену реализации: ");
            do
            {
                sellingPrice = float.Parse(Console.ReadLine());
                if (sellingPrice <= 0)
                {
                    Console.WriteLine("Неверно введена цена реализации, попробуйте снова");
                }
            } while (sellingPrice <= 0);
        }
        public float income()
        {
            return scopeOfSupply * sellingPrice;
        }
        public void printInfo()
        {
            Console.WriteLine($"Дата поставки: {dateOfSupply.ToString("d")} \n  Объем поставки: {scopeOfSupply} \n  Себестоимость поставки: {costOfSupply} \n  Цена реализации: {sellingPrice}");
            Console.WriteLine("===============================================");
        }
        public DateTime getDateOfSupply()
        {
            return dateOfSupply;
        }
    }
}
