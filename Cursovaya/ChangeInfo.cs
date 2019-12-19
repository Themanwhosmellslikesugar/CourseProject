using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
    class ChangeInfo
    {
        static public int changeObject(Enterprise[] enterprise)
        {
            int answer = 0;
            int answerEnterprise = 0;
            int answerProduction = 0;
            int answerSupply = 0;
            Console.WriteLine("Вы хотите изменить информацию о предприятии, поставке или закупке? 1 - предприятие 2 - закупка, 3 - поставка, 0 - выход, все кроме этого продолжить ");
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
                    recalculation(enterprise, answerEnterprise);
                    break;
                case 3:
                    Console.WriteLine("Введите какое предприятие изменить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Введите какую поставку изменить?");
                    answerSupply = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise].supplys[answerSupply] = new Supply();
                    zerofication(enterprise, answerEnterprise);
                    recalculation(enterprise, answerEnterprise);
                    break;
                default:
                    Console.WriteLine("Применение изменений....");
                    break;
            }
            return answer;
        }
        static public int AddObject(Enterprise[] enterprise)
        {

            int answer = 0;
            int answerEnterprise = 0;
            Console.WriteLine("Вы хотите добавить информацию? 1 - предприятие 2 - закупка, 3 - поставка, 0 - выход, все кроме этого продолжить ");
            answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    Console.WriteLine("Добавление предприятия:");
                    Array.Resize(ref enterprise, enterprise.Length + 1);
                    enterprise[enterprise.Length] = new Enterprise();
                    break;
                case 2:
                    Console.WriteLine("Введите в каком предприятии добавить закупку?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Добавление закупки:");
                    enterprise[answerEnterprise].productions.Add(new Production());
                    zerofication(enterprise, answerEnterprise);
                    recalculation(enterprise, answerEnterprise);
                    break;
                case 3:
                    Console.WriteLine("Введите в каком предприятии добавить поставку?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Введите какую поставку удалить?");
                    enterprise[answerEnterprise].supplys.Add(new Supply());
                    zerofication(enterprise, answerEnterprise);
                    recalculation(enterprise, answerEnterprise);
                    break;
                default:
                    Console.WriteLine("Применение изменений....");
                    break;
            }
            return answer;
        }
        static public int DeleteObject(Enterprise[] enterprise)
        {
           
                int answer = 0;
                int answerEnterprise = 0;
                int answerProduction = 0;
                int answerSupply = 0;
                Console.WriteLine("Вы хотите удалить информацию? 1 - предприятие 2 - закупка, 3 - поставка, 0 - выход, все кроме этого продолжить ");
                answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    Console.WriteLine("Введите какое предприятие удалить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;
                    Array.Clear(enterprise, answerEnterprise, 1);
                    break;
                case 2:
                    Console.WriteLine("Введите какое предприятие удалить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Введите какую закупку удалить?");
                    answerProduction = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise].productions.RemoveAt(answerProduction);
                    zerofication(enterprise, answerEnterprise);
                    recalculation(enterprise, answerEnterprise);
                    break;
                case 3:
                    Console.WriteLine("Введите какое предприятие удалить?");
                    answerEnterprise = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Введите какую поставку удалить?");
                    answerSupply = int.Parse(Console.ReadLine()) - 1;
                    enterprise[answerEnterprise].supplys.RemoveAt(answerSupply);
                    zerofication(enterprise, answerEnterprise);
                    recalculation(enterprise, answerEnterprise);
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
        //Перерасчет дохода, прибыли после изменений введеных данных
        static void recalculation(Enterprise[] enterprise, int answerEnterprise)
        {
            enterprise[answerEnterprise].outlayProduction();
            enterprise[answerEnterprise].outlaySupply();
            enterprise[answerEnterprise].profitCallculating();
            enterprise[answerEnterprise].netprofitCallculating();
            enterprise[answerEnterprise].printInfo();
        }
    }
}
