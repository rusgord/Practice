using Shop.Logic.Modules;
using Shop.UI.Modules;
using System.Text.Json;
using System;
using System.Security.Principal;

namespace Shop.UI
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            List<HardwareShop> list = new List<HardwareShop>();
            HardwareShop shop = new HardwareShop();
            Balance balance = new Balance();
            Components components = new Components();
            Random rand = new Random();
            int a, choice, idg;
            while (true)
            {
                try
                {
                    Console.WriteLine(@"Виберiть:
1 - Додати грошей
2 - Вивести на екран придбанi комплектуючi
3 - Пошук (Замiна) комплектуючих
4 - Видалити зi збiрки комплектуючi
5 - Демонстрацiя повноцiнної роботи
6 - Демонстрацiя роботи static методiв
7 - зберегти колекцiю об'єктiв у файлi
8 - зчитати колекцiю об'єктiв з файлу
9 - очистити колекцiю об'єктiв
0 - Вихiд");
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a == 0) break;
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("----------------------------------------");
                            HardwareShop.Cash = balance.BalanceAdd(HardwareShop.Cash);
                            Console.WriteLine("----------------------------------------");
                            break;
                        case 2:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine(shop.String());
                            Console.WriteLine("----------------------------------------");
                            break;
                        case 3:
                            if (HardwareShop.Id != 0)
                            {
                                Console.WriteLine(@"Виберiть що замiнити:
1 - Процессори
2 - Вiдеокарти
0 - Вийти в головне меню");
                                a = Convert.ToInt32(Console.ReadLine());
                                if (a == 0) break;
                                if (a == 1)
                                {
                                    HardwareShop.Id = components.OutputCpu(ref a, HardwareShop.Cash);
                                    shop.Purchased_cpu(a);
                                    shop = new HardwareShop();
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine(shop.String());
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                }
                                if (a == 2)
                                {
                                    HardwareShop.Id = components.OutputGpu(ref a, HardwareShop.Cash);
                                    shop.Purchased_gpu(a);
                                    shop = new HardwareShop();
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine(shop.String());
                                    Console.WriteLine("----------------------------------------");
                                }
                                break;
                            }
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Список пустий");
                            Console.WriteLine("----------------------------------------");
                            break;
                        case 4:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine(shop.Remove);
                            Console.WriteLine("----------------------------------------");
                            break;
                        case 5:
                            Console.WriteLine(shop.Remove);
                            Console.WriteLine("Вiтаємо у комп'ютерному магазинi VseTyt!");
                            choice = rand.Next(1, 4);
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("----------------------------------------");
                                    HardwareShop.Cash = balance.BalanceAdd(HardwareShop.Cash);
                                    Console.WriteLine("----------------------------------------");
                                    HardwareShop.Id = components.OutputCpu(ref a, HardwareShop.Cash);
                                    shop.Purchased_cpu(a);
                                    shop = new HardwareShop();
                                    HardwareShop.Id = components.OutputGpu(ref a, HardwareShop.Cash);
                                    shop.Purchased_gpu(a);
                                    shop = new HardwareShop();
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine(shop.String());
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                case 2:
                                    Console.WriteLine("----------------------------------------");
                                    HardwareShop.Cash = balance.BalanceAdd(HardwareShop.Cash);
                                    Console.WriteLine("----------------------------------------");
                                    shop = new HardwareShop(rand.Next(1, 3), rand.Next(1, 5));
                                    HardwareShop.Id = components.OutputGpu(ref a, HardwareShop.Cash);
                                    shop.Purchased_gpu(a);
                                    shop = new HardwareShop();
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine(shop.String());
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                case 3:
                                    Console.WriteLine("----------------------------------------");
                                    HardwareShop.Cash = balance.BalanceAdd(HardwareShop.Cash, rand.Next(3000, 5000));
                                    Console.WriteLine("----------------------------------------");
                                    idg = rand.Next(1, 4);
                                    if (idg == 3)
                                        a = rand.Next(1, 5);
                                    else
                                        a = rand.Next(1, 14);
                                    shop = new HardwareShop(rand.Next(1, 3), idg, rand.Next(1, 5), a);
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine(shop.String());
                                    Console.WriteLine("----------------------------------------");
                                    break;
                            }
                            break;
                        case 6:
                            Console.WriteLine("Вiтаємо у комп'ютерному магазинi VseTyt!");
                            Console.WriteLine("----------------------------------------");
                            components.Models();
                            Console.WriteLine($"Ваш баланс {HardwareShop.Cash}$");
                            Console.WriteLine("Введiть данi за принципом: Баланс,Процессор,Вiдеокарта");
                            HardwareShop.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine(shop.String());
                            Console.WriteLine("----------------------------------------");
                            break;
                        case 7:
                            Console.WriteLine("Виберiть:\n1 - Зберегти у (*.Csv)\n2 - Зберегти у (*.Json)");
                            a = Convert.ToInt32(Console.ReadLine());
                            string? path;
                            switch (a) 
                            {
                                case 1:
                                    list.Add(shop);
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.csv):");
                                    path = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".csv";
                                        Save.ToCsv(list, path);
                                    }
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                case 2:
                                    list.Add(shop);
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.json):");
                                    path = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".json";
                                        Save.ToJson(list, path);
                                    }
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                default: Console.WriteLine("Помилка! Немає такого значення!"); break;
                            }   
                            break;
                        case 8:
                            Console.WriteLine("Виберiть:\n1 - Вiдкрити (*.Csv)\n2 - Вiдкрити (*.Json)");
                            a = Convert.ToInt32(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.csv):");
                                    path = Console.ReadLine();
                                    Console.WriteLine("----------------------------------------");
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".csv";
                                        list = Open.FromCsv(path);
                                        Console.WriteLine("----------------------------------------");
                                        Console.WriteLine("Об'єкти класу:");
                                        Console.WriteLine(shop.String());
                                        Console.WriteLine("----------------------------------------");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.json):");
                                    path = Console.ReadLine();
                                    Console.WriteLine("----------------------------------------");
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".json";
                                        list = Open.FromJson(path);
                                        Console.WriteLine("----------------------------------------");
                                        Console.WriteLine("Об'єкти класу:");
                                        Console.WriteLine(shop.String());
                                        Console.WriteLine("----------------------------------------");
                                    }
                                    break;
                                default: Console.WriteLine("Помилка! Немає такого значення!"); break;
                            }
                            break; 
                        case 9:
                            list.Clear();
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Очищено");
                            Console.WriteLine("----------------------------------------");
                            break;
                        default: Console.WriteLine("Введiть цифри тiльки вiд 0 до 9"); break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}