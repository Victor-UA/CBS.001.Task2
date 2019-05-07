using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task2
{
    class Program
    {
        //Задание 2
        //Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
        //количество дней в соответствующем месяце.Реализуйте возможность выбора месяцев, как по
        //порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
        //только один месяц.
        static void Main(string[] args)
        {
            Random random = new Random();
            MonthsCollection months = new MonthsCollection(); 
            for (uint i = 0; i < 120; i++)
            {
                uint number = (uint)random.Next(1, 12);
                months.Add(new Month(number.ToString(), number, (uint)random.Next(1, 31)));
            }
            var test1 = months.GetMonthsByDaysQuantity(months[0].DaysQuantity);
            var test2 = months.GetMonthsByNumber(months[0].Number);
            for (uint i = 119; i > 10; i--)
            {
                months.Remove(months[i]);
            }
            Console.ReadKey();
        }
    }
}
