using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Nile
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            do
            {
                // add, list, alist
                char choice = GetInput();
                switch (choice)
                {
               
                    case 'A':
                    AddProduct();
                    break;

                    case 'L':
                    ListProduct();
                    break;

                    case 'Q': quit = true; break; 
                    
                };
            } while (!quit);

            // value type
           // int value1 = 10;
            //Program program = new Program();

            // example 
            //var areEqual1 = value1 == 10;
            //var areEqual2 = program == program;
            //var areEqual3 = program == new Program(); 
            

        }

        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            Name = Console.ReadLine().Trim();

            // Ensure not empty

            Console.Write("Enter price (>0):$ ");
             Price = ReadDecimal();

            Console.Write("Enter optional description: ");
            Description= Console.ReadLine().Trim();

            Console.WriteLine("Is it discontinued (Y/N): ");
            Discontinued = ReadYesNo(); 
        }
        private static void ListProduct()
        {
            // Name $price (Discontinued)
            // Description
            // Example 1
            // string msg = String.Format("{0}\t\t\t{1}\t\t[{2}]",Name, Price
            //,Discontinued ?"Discontinued" : "");

            // Example 2
            // Console.WriteLine({0}\t\t\t{1}\t\t[{2}]",Name, Price
            //,Discontinued ? "[Discontinued]" : "");

            // Example 3
            string msg = $"{Name}\t\t\t {Price}\t\t{(Discontinued ? "[Discontinued]" : "")}";
            Console.WriteLine(msg);
            Console.WriteLine();
            Console.WriteLine(Description); 
        }
        static char GetInput() // modifier should be static  // void has no return type 
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10));
                  Console.WriteLine("A)dd Product");
                  Console.WriteLine("L)ist Products");
                  Console.WriteLine("Q)uit");


                string input = Console.ReadLine();                      
                   // option 1 = string literal
                  // if (input !=" ")

                 // option 2 - string field
                 // if (input !=string.Empty)

                //option 3 - length does not solve null
                if (input!= null && input.Length !=0)
                {
                    // string comparion
                    if (string.Compare(input, "A", true) == 0)
                        return 'A';
                    //char comparison
                    else if (string.Compare(input, "L", true) == 0)
                        return 'L';
                    else if (string.Compare(input, "Q", true) == 0)
                        return 'Q';
                }
                //Error
                Console.WriteLine("Please choose a valid option");
            }
        }

        /// <summary> Read a decimal from Console.</summary>
        /// <returns>the decimal value.</returns>
        static decimal ReadDecimal()
        {
            do
            {
                var input = Console.ReadLine();

                if (Decimal.TryParse(input, out var result))
                    return result;

                Console.Write("Enter a valid decimal");
            } while (true); 
        }

        /// <summary>
        /// reads a boolean from Console.</summary>
        /// <returns></returns>
        static bool ReadYesNo()
        {
            do
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y':
                        return true;
                        case 'N':
                        return false;
                    }

                }
                
                 Console.Write("Enter either Y or N");
            } while (true);
        }
        static string ReadString(string errorMessage, bool allowEmpty)
        {
            //if (errorMessage == null)
            //errorMessage = "Enter a vaild string";
            // else 
            // errorMessage = errorMessage.Trim();

            // Null coalesce 
            //errorMessage = errorMessage ?? "Enter a valid string"; 
          
            // null conditional 
            errorMessage = errorMessage?.Trim();

            do
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) && allowEmpty)
                    return "";
                else if (!String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Enter as string");
            } while (true);
        }
        // product goes
        static string  Name;
        static decimal Price;
        static string  Description;
        static bool    Discontinued; 
        
    }

      
}
