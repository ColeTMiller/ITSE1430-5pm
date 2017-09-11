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
            // add, list, alist
            GetInput();

        }
        static char GetInput() // modifier should be static  // void has no return type 
        {
            while (true)
            { 
            Console.WriteLine("A)dd Product");
            Console.WriteLine("L)ist Products");
            Console.WriteLine("Q)uit");


            string input = Console.ReadLine();
            if (input == "A")
                return 'A';
            else if (input == "L")
                return 'L';
            else if (input == "Q")
                return 'Q';

                //Error
                Console.WriteLine("Please choose a valid option");
            }
        }
    }
      
}
