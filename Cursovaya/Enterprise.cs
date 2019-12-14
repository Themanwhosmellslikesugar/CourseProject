using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
     class Enterprise
    {
        private string enterpriseName;
        private DateTime dateOfRegistration = new DateTime();
        private int amountOfWorkers;
        private string mainTypeOfProduct;
        private string advanced;
        public float profit = 0;
        public float netprofit = 0;
        public List<Production> productions;
        public TypeOfOwnership type;
        public float outlay = 0;
        public float income = 0;
        public List<Supply> supplys;
        public Enterprise()
        {
            outlay = 0;
            income = 0;
            profit = 0;
            netprofit = 0;
            inputData();
            type = new TypeOfOwnership();
            Console.WriteLine("Ввод закупки: ");
            createProduction();
            outlayProduction();
            Console.WriteLine("Ввод поставки: ");
            createSupply();
            outlaySupply();

            Console.WriteLine($"Общие затраты за год: {outlay}");
            Console.WriteLine($"Доходы за год: {income}");
            profitCallculating();
            netprofitCallculating();
            Console.WriteLine("================================");
            printInfo();
            printProduction();
            printSupply();
        }
        void inputData()
        {
            Console.WriteLine("Введите наименование сельсохозяйственного предприятия: ");
            do
            {
                enterpriseName = Console.ReadLine();
                if (String.IsNullOrEmpty(enterpriseName))
                {
                    Console.WriteLine("Не введено название предприятия.... Попробуйте заново");
                }
            } while (String.IsNullOrEmpty(enterpriseName));
            Console.WriteLine("Введите год создания: ");
            int year = 0;
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц создания: ");
            int month = 0;
            month = int.Parse(Console.ReadLine());
            int day = 0;
            Console.WriteLine("Введите день создания: ");
            day = int.Parse(Console.ReadLine());
            dateOfRegistration = new DateTime(year, month, day);
            Console.WriteLine("Введите кол - во работников (только целое число): ");
            do
            {
                amountOfWorkers = int.Parse(Console.ReadLine());
                if (amountOfWorkers <= 0)
                {
                    Console.WriteLine("Неверно введено количество работников, try again");
                }
            } while (amountOfWorkers <= 0);
            Console.WriteLine("Введите основной вид продукции: ");
            do
            {
                mainTypeOfProduct = Console.ReadLine();
                if (String.IsNullOrEmpty(mainTypeOfProduct))
                {
                    Console.WriteLine("Не введено название основного вида продукции, попробуйте заново");
                }
            } while (String.IsNullOrEmpty(mainTypeOfProduct));
            Console.WriteLine("Является ли передовым в освоении новой технологии(+ или -)");
            do
            {
                advanced = Console.ReadLine();
            } while (String.IsNullOrEmpty(advanced));

        }
        public void createProduction()
        {
            int answer = 0;
            productions = new List<Production>();
            do
            {
                productions.Add(new Production());
                Console.WriteLine("Продолжить? 0 - нет");
                answer = int.Parse(Console.ReadLine());
            } while (answer != 0);
        }
        //НАХОЖДЕНИЕ ПРИБЫЛИ НА ЗАКУПКУ
        public void outlayProduction()
        {
            int i = 0;
            foreach (var val in productions)
            {
                outlay += productions[i].outlayPurchase();
                i++;
            }
            i = 0;
            Console.WriteLine($"Затраты на закупку: {outlay}");
        }

        public void createSupply()
        {
            int answer = 0;
            supplys = new List<Supply>();
            do
            {
                supplys.Add(new Supply());
                Console.WriteLine("Продолжить? 0 - нет");
                answer = int.Parse(Console.ReadLine());
            } while (answer != 0);
        }
        //НАХОЖДЕНИЕ ЗАТРАТ НА СЕБЕСТОИМОСТЬ ПОСТАВКИ
        public void outlaySupply()
        {
            int i = 0;
            foreach (var val in supplys)
            {
                outlay += supplys[i].costOfSupply;
                income += supplys[i].income();
                i++;
            }
            i = 0;
        }
        public void profitCallculating()
        {
            profit = income - outlay;
        }
        public void netprofitCallculating()
        {
            netprofit = (float)(profit - (profit * 0.2));
        }
        public void printProduction()
        {
            int i = 0;
            foreach(var val in productions)
            {
                productions[i].printInfo();
                i++;
            }
        }
        public void printSupply()
        {
            int i = 0;
            foreach (var val in supplys)
            {
                supplys[i].printInfo();
                i++;
            }
        }
        public void printInfo()
        {
            Console.WriteLine($"Наименование предприятия: {enterpriseName} \n  Дата создания: {dateOfRegistration.ToString("d")} \n  Кол - во работников: {amountOfWorkers} \n  Основной вид продукции: {mainTypeOfProduct}");
            Console.WriteLine($"  Является ли передовым в освоении новой технологии: {advanced}");
            Console.WriteLine($"  Прибыль балансовая (годовая): {profit}");
            Console.WriteLine($"  Прибыль чистая (годовая): {netprofit}");
            Console.WriteLine("===================================================");
        }
        public string getEnterpriseName()
        {
            return enterpriseName;
        }
        public DateTime getDate()
        {
            return dateOfRegistration;
        }
        public int getAmountOfWorkers()
        {
            return amountOfWorkers;
        }
        public string getMainTypeOfProduct()
        {
            return mainTypeOfProduct;
        }
        public string getAdvanced()
        {
            return advanced;
        }
    }
}
