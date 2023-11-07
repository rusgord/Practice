using Shop.Logic.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.UI.Modules
{
    internal class Save
    {
        public static void ToCsv(List<HardwareShop> info, string path)
        {
            List<string> lines = new List<string>();
            foreach (var item in info)
            {
                lines.Add(item.ToString());
            }
            try
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine($"Було збережено у файл: {Path.GetFullPath(path)}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void ToJson(List<HardwareShop> info, string path)
        {
            try
            {
                string jsonstring = "";
                foreach (var item in info)
                {
                    jsonstring += JsonSerializer.Serialize<HardwareShop>(item);
                    jsonstring += "\n";
                }
                File.WriteAllText(path, jsonstring);
                Console.WriteLine($"Було збережено у файл: {Path.GetFullPath(path)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
