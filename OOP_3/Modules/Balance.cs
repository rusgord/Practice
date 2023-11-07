using Shop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI.Modules
{
    public class Balance
    {
        public int BalanceAdd(int cash)
        {
            try
            {
                Console.WriteLine($"Баланс {cash}$");
                Console.WriteLine(@"Бажаєте додадити грошей? 
1 - Так
Iнша цифра - Нi");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    int balance;
                    Console.WriteLine("Додайте бажану сумму");
                    balance = +Convert.ToInt32(Console.ReadLine());
                    if ((balance > 0) && (balance < 5000))
                        Console.WriteLine($"Баланс {cash + balance}$");
                    else
                    {
                        Console.WriteLine("Введiть число бiльше за 0$, та менше нiж 5000$");
                        Console.WriteLine($"Баланс {cash}$");
                    }
                    return balance;
                }
            }
            catch (FormatException)
            { 
                Console.WriteLine("Введiть тiльки цифри!");
            }
            return 0;
        }
        public int BalanceAdd(int cash, int random)
        {
            Console.WriteLine($"Баланс {cash}$");
            Console.WriteLine(@"Бажаєте додадити грошей? 
1 - Так
Iнша цифра - Нi");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                int balance;
                balance = + random;
                Console.WriteLine($"Баланс {cash + balance}$");
                return balance;
            }
            return 0;
        }
    }

}
