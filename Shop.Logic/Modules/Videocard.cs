using Shop.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Modules
{
    public class Videocard
    {
        public static bool Equal(string videocard, ref int videocardModel, ref int id)
        {
            for (int i = 1; i < 14; i++)
            {
                string inputVideocard = Convert.ToString((NVIDIA_GPU)i);
                if (inputVideocard == videocard) { videocardModel = i; id = 1; return true; }
            }
            for (int i = 1; i < 14; i++)
            {
                string inputVideocard = Convert.ToString((AMD_GPU)i);
                if (inputVideocard == videocard) { videocardModel = i; id = 2; return true; }
            }
            for (int i = 1; i < 5; i++)
            {
                string inputVideocard = Convert.ToString((INTEL_GPU)i);
                if (inputVideocard == videocard) { videocardModel = i; id = 3; return true; }
            }
            return false;
        }
    }
}
