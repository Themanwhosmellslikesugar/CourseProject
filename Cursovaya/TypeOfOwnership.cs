using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
    class TypeOfOwnership
    {
        private string typeOfOwnership;
        public TypeOfOwnership()
        {
            Console.WriteLine("Введите название вида собственности: ");
            typeOfOwnership = Console.ReadLine();
            if(String.IsNullOrEmpty(typeOfOwnership))
            {
                typeOfOwnership = "Неизвестен";
                Console.WriteLine("Задано значение по умолчанию.");
            }

        }
        public string getTypeOfOwnership()
        {
            return typeOfOwnership;
        }
    }
}
