using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintValuesLibrary
{
    public class CustomInputValue
    {
        public void Run(string[] args )
        {
            int iValue = GetCustomerValue();
            if (iValue != -1)
            {
                DoCount(args, iValue);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Run - Overloaded for Test, accepts a pre-defined value where ordinarily it should accept it from the command line
        /// </summary>
        /// <param name="args"></param>
        /// <param name="value"></param>
        public void Run(string[] args, int value)
        {
            DoCount(args, value);
        }
        
        /// <summary>
        /// GetCustomerValue - Get the value from the command line
        /// </summary>
        /// <returns></returns>
        public int GetCustomerValue()
        {
            int iCustomerValue = -1;
            bool bValid = false;
            string message = "Enter integer value";
            do
            {
                Console.WriteLine(message); //output default message
                string sInputValue = Console.ReadLine();
                try
                {
                    if (sInputValue.All(Char.IsDigit))
                    {
                        iCustomerValue = int.Parse(sInputValue);
                        bValid = true;
                    }
                    else //not a valid entry, try it again
                    {
                        message = "invalid integer entered, enter a new integer value";
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("invalid character entered, exiting..");
                    bValid = true;
                }
                
                
            } while (!bValid);
            
            return iCustomerValue;
        }

        /// <summary>
        /// DoCount - takes the arguments and custom inputed value and does the counting, 
        /// if no custom values inputed then just do the regular print routine
        /// </summary>
        /// <param name="args"></param>
        /// <param name="iCustomerValue"></param>
        private void DoCount(string[] args, int iCustomerValue)
        {
            for (int i = 1; i <= iCustomerValue; i++)
            {
                if (args.Length > 0)
                {
                    PrintCustomValues(args, i);
                }
                else
                {
                    PrintValue(i);
                }

            }
        }

        /// <summary>
        /// PrintValue - original fizz buzz pattern, no arguments provided, just run this one
        /// </summary>
        /// <param name="value"></param>
        private void PrintValue(int value)
        {
            if (value % 3 == 0)
            {
                Console.WriteLine("fizz");
                if (value % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
            }
            else if (value % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(value.ToString());
            }
        }

        /// <summary>
        /// PrintCustomValues - Customer provided an unknown number of parameters, process each and output the appropriate word
        /// </summary>
        /// <param name="args"></param>
        /// <param name="value"></param>
        private void PrintCustomValues(string[] args, int value)
        {
            bool bPrinted = false;

            for (int i = 0; i <= args.Length - 1; i++)
            {
                //parse the string
                //expecting 1 buzz or 2 zing
                string[] statement = args[i].Split(' ');
                bool success = false; //try to get the integer value
                int numberToCheck; 
                success = int.TryParse(statement[0], out numberToCheck);//special value
                if (success) //I have a integer value parsed
                {
                    string wordTorPrint = statement[1];//special word could be anything
                    if (value % numberToCheck == 0)
                    {
                        bPrinted = true;
                        Console.WriteLine(wordTorPrint);
                    }
                }
            }
            if (!bPrinted)//nothing printed above, just print the value
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
