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
        }

        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            Name = Console.ReadLine().Trim();

            // Ensure not empty

            Console.Write("Enter price (>0): ");
            Price = Console.ReadLine();

            Console.Write("Enter optional description: ");
            Description= Console.ReadLine().Trim();

            Console.WriteLine("Is it discontinued (Y/N): ");
            Discontinued = Console.ReadLine().Trim(); 
        }
        private static void ListProduct()
        {
            throw new NotImplementedException();
        }
        static char GetInput() // modifier should be static  // void has no return type 
        {
            while (true)
            {
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

        // product goes
        static string  Name;
        static decimal Price;
        static string  Description;
        static bool    Discontinued; 
        
    }

      
}
