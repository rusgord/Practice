using Shop.Logic.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.UI.Modules
{
    public class Open
    {
        public static List<HardwareShop> FromCsv(string path)
        {
            List<HardwareShop> info = new List<HardwareShop>();
            try
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();
                Console.WriteLine("Вмiст Csv файлу:");
                foreach (var item in lines)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in lines)
                {
                    HardwareShop? shop;
                    bool result = HardwareShop.TryParse(item, out shop);
                    if (result) { info.Add(shop); }
                }
            }
            catch (IOException ex) { Console.WriteLine($"Помилка: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return info;
        }
        public static List<HardwareShop> FromJson(string path)
        {
            List<HardwareShop> info = new List<HardwareShop>();
            try
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();
                Console.WriteLine("Вмiст Json файлу:");
                foreach (var item in lines)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in lines)
                {
                    HardwareShop? items = JsonSerializer.Deserialize<HardwareShop>(item);
                    if (items != null)
                        info.Add(items);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return info;
        }
    }
}
