using Shop.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Modules
{
    public class Processor
    {
        public static bool Equal(string processor, ref int processorModel, ref int id)
        {
            for(int i=1; i<5; i++)
            {
                string inputProcessor = Convert.ToString((INTEL_CPU)i);
                if (inputProcessor == processor) { processorModel = i; id = 1; return true; }
            }
            for (int i = 1; i < 5; i++)
            {
                string inputProcessor = Convert.ToString((AMD_CPU)i);
                if (inputProcessor == processor) { processorModel = i; id = 2; return true; }
            }
            return false;
        }
    }
}
