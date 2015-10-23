using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintValuesLibrary;
using System.IO;
namespace PrintValuesTest
{
    [TestClass]
    public class PrintValuesLibraryTest
    {
        [TestMethod]
        public void TestRun()
        { //Test the public run method assuming a picked out value for input
            //1. this is invalid, only valid entry is 6 bar
            CustomInputValue customValue = new CustomInputValue();
            string[] values = { "foo 4", "6 bar", "sharp sharp" };
            customValue.Run(values, 25);
            //2. should pass
            CustomInputValue customValue2 = new CustomInputValue();
            string[] values2 = { "3 4", "6 bar" };
            customValue2.Run(values2, 25);
            //3. Create a blank array to pass to run method, should still generate output
            CustomInputValue customValue3 = new CustomInputValue();
            string[] values3 = new string[0];
            customValue3.Run(values3, 25);
            //4. Create a blank array to pass to run method, should still generate output
            CustomInputValue customValue4 = new CustomInputValue();
            string[] values4 = { "4 foo", "6 bar", "10 sharp" };
            customValue3.Run(values4, 25);
        }

        [TestMethod]
        public void TestGetCustomerValue()
        {
            //Test 1. Non standard input
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("zzz"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    CustomInputValue customValue = new CustomInputValue();
                    int value = customValue.GetCustomerValue();
                }
            }
            //Test 2. Standard input
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("100"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    CustomInputValue customValue = new CustomInputValue();
                    int value = customValue.GetCustomerValue();
                }
            }

        }
    }
}
