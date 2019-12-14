using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
    class Production
    {
        public string nameOfProduction;
        public string measure;
        public float purchasePrice;
        public int purchaseVolume;
        public Production()
        {
            purchasePrice = 0;
            purchaseVolume = 0;
            Console.WriteLine("Введите название продукции: ");
            do
            {
                nameOfProduction = Console.ReadLine();    //НАЗВАНИЕ ПРОДУКЦИИ И ЕГО ПРОВЕРКА
                if (String.IsNullOrEmpty(nameOfProduction))
                {
                    Console.WriteLine("Не введено название продукции, попробуйте снова");
                }
            } while (String.IsNullOrEmpty(nameOfProduction));
            Console.WriteLine("Введите единицу измерения: ");
            do
            {
                measure = Console.ReadLine();
                if (String.IsNullOrEmpty(measure))                              //ЕДИНИЦА ИЗМЕРЕНИЯ И ЕГО ПРОВЕРКА
                {
                    Console.WriteLine("Не введена единица измерения, попробуйте снова");
                }
            } while (String.IsNullOrEmpty(measure));
            Console.WriteLine("Введите закупочную цену: ");
            do
            {                                               //ЗАКУПОЧНАЯ ЦЕНА И ЕГО ПРОВЕРКА
                purchasePrice = float.Parse(Console.ReadLine());
                if(purchasePrice <= 0)
                {
                    Console.WriteLine("Неправильно введена цена, попробуйте заново");
                }
            } while (purchasePrice <= 0);
            Console.WriteLine("Введите объем закупки: ");
            do
            {
                purchaseVolume = int.Parse(Console.ReadLine());
                if (purchaseVolume <= 0)
                {
                    Console.WriteLine("Неверно задан объем поставки, введите заново");  //НОВОЕ ПОЛЕ
                }                                                                       //ОБЪЕМ ЗАКУПКИ ДЛЯ НАХОЖДЕНИЯ ЗАТРАТ НА РЕСУСРЫ
            } while (purchaseVolume <= 0);

        }
        public float outlayPurchase()
        {
            return purchasePrice * purchaseVolume;
        }
        public void printInfo()
        {
            Console.WriteLine($"Название продукции: {nameOfProduction} \n  Единица измерения: {measure}\n  Закупочная цена: {purchasePrice}\n  Объем закупки: {purchaseVolume}");
            Console.WriteLine("============================================");
        }
    }
}
