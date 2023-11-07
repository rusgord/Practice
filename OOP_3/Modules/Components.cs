using Shop.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.UI.Modules
{
    internal class Components
    {
        List<int> cpu = new List<int>() { 100, 150, 300, 400 };
        List<int> gpu = new List<int>() { 60, 80, 120, 160, 240, 300, 400, 500, 550, 700, 800, 1000, 1200 };
        List<int> gpu_i = new List<int>() { 90, 140, 290, 330 };
        int id;
        public int OutputCpu(ref int model, int cash)
        {
            try 
            {
                Console.WriteLine("Виберiть виробника процессорiв: \n1 - Intel \n2 - AMD");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Виберiть процессор:");
                switch (choice)
                {
                    case 1: id = 1; for (int i = 1; i < 5; i++) { Console.WriteLine($"{i} - {(INTEL_CPU)i} {cpu[i - 1]}$"); } break;
                    case 2: id = 2; for (int i = 1; i < 5; i++) { Console.WriteLine($"{i} - {(AMD_CPU)i} {cpu[i - 1]}$"); } break;
                    default : id = 0; Console.WriteLine("Виберiть виробника!"); return id;
                }
                model = Convert.ToInt32(Console.ReadLine());
                if (cpu[model - 1] > cash) { id = 0; throw new Exception("У вас не вистачає грошей на процессор"); }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введiть тiльки цифри!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id;
        }
        public int OutputGpu(ref int model, int cash) 
        {
            try
            {
                Console.WriteLine("Виберiть виробника вiдеокарт: \n1 - NVIDIA \n2 - AMD \n3 - Intel");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Виберiть вiдеокарту:");
                switch (choice)
                {
                    case 1: id = 1; for (int i = 1; i < 14; i++) { Console.WriteLine($"{i} - {(NVIDIA_GPU)i} {gpu[i - 1]}$"); } break;
                    case 2: id = 2; for (int i = 1; i < 14; i++) { Console.WriteLine($"{i} - {(AMD_GPU)i} {gpu[i - 1]}$"); } break;
                    case 3: id = 3; for (int i = 1; i < 5; i++) { Console.WriteLine($"{i} - {(INTEL_GPU)i} {gpu_i[i - 1]}$"); } break;
                    default: id = 0; Console.WriteLine("Виберiть виробника!"); return id;
                }
                model = Convert.ToInt32(Console.ReadLine());
                if (id == 3)
                    if (gpu_i[model - 1] > cash) { id = 0; throw new Exception("У вас не вистачає грошей на вiдеокарту"); }
                else
                    if (gpu[model - 1] > cash) { id = 0; throw new Exception("У вас не вистачає грошей на вiдеокарту"); }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введiть тiльки цифри!");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
            return id;
        }
        public void Models()
        {
            Console.WriteLine("Модельний ряд процессорiв\n   Intel\t   AMD");
            for (int i = 1; i < 5; i++) { Console.WriteLine($"{(INTEL_CPU)i} {cpu[i - 1]}$ |\t{(AMD_CPU)i} {cpu[i - 1]}$"); }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Модельний ряд вiдеокарт\n   NVIDIA");
            for (int i = 1; i < 14; i++) 
            {
                Console.WriteLine($"{(NVIDIA_GPU)i} {gpu[i - 1]}$"); 
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Модельний ряд вiдеокарт\n   AMD");
            for (int i = 1; i < 14; i++)
            {
                Console.WriteLine($"{(AMD_GPU)i} {gpu[i - 1]}$");
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Модельний ряд вiдеокарт\n   INTEL");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{(INTEL_GPU)i} {gpu_i[i - 1]}$");
            }
            Console.WriteLine("-----------------------");
        }
    }
}
