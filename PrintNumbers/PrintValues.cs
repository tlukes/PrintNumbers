using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintValuesLibrary;

namespace PrintNumbers
{
    class PrintValues
    {
        static void Main(string[] args)
        {
            CustomInputValue myCustomClass = new CustomInputValue();
           //Testing running the assembly with a sampling of possible entries
            string[] customValues = { "4 fizz", "6 bar", "8 lamp", "9 bang" };
            myCustomClass.Run(customValues);
        }

        
     }
}

