using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Cole_Miller
{
    class Program
    {
        static void Main( string[] args)
        {
            bool quit = false;                                                                              
            do
            {
                char choice = MovieSelection();                                                     
                switch (choice)                                                                 // converting the switch into the choices the user wants to pick 
                {
                    case '1':                                                                         
                    AddMovie();
                    break;

                    case '2':
                    ListMovie();
                    break;

                    case '3':
                    DeleteMovie();
                    break;

                    case '4': quit = true; break;
                }
            } while (!quit);
        }

        private static void DeleteMovie()                                               // does the user want to delete the movie or not
        {
            Console.WriteLine("Do you want to delete this movie (Y/N):");
                Delete = MovieDelete();
            
            
        }

        

        private static void ListMovie()                                             // listing the movie and information the user puts in
        {
            
           
                Console.WriteLine(Name);
                Console.WriteLine(Description);
                Console.WriteLine(Time );
                Console.WriteLine(Own);
           
        }

        private static void AddMovie()                                              // asking the user to enter the movie information they want to put in
        {
            Console.WriteLine("Enter Movie Name:");
            Name = Console.ReadLine().Trim();

            Console.WriteLine("Enter description of Movie:");
            Description = Console.ReadLine().Trim();

            Console.WriteLine("Enter how minuates the movie last: ");
             Time = ReadDecimal();

            Console.WriteLine("Do you own this movie:");
            Own = ReadYesorNo(); ; 

        }

        static char MovieSelection()                                                // displaying the choices the user must make in order 
        {                                                                                               // to Add Movie, List movie, Delete Movie, or  Quit program
            while (true)
            {
                Console.WriteLine("What selection would you like to make:");
                Console.WriteLine("".PadLeft(10));
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. List Movies");
                Console.WriteLine("3. Delete Movie");
                Console.WriteLine("4. Quit Program");
                Console.WriteLine("Enter (1-4): ");
                Console.WriteLine("".PadLeft(10));

              
                var input = Console.ReadLine();
                if (input != null && input.Length != 0)                                                 // turning  a user input into a string then into a validation process
                {
                    if (string.Compare(input, "1", true) == 0)
                        return '1';
                    else if (string.Compare(input, "2", true) == 0)
                        return '2';
                    else if (string.Compare(input, "3", true) == 0)
                        return '3';
                    else if (string.Compare(input, "4", true) == 0)
                        return '4';
                }
                // Error
                Console.WriteLine("Please Choose a valid option");
            }
        }
        /// <summary>
        /// Read the Decimal in time Format</summary>
        /// <returns> the  decimal value</returns>
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
        /// <summary>reads a boolean fromConsole </summary>
        /// <returns></returns>
        static bool ReadYesorNo()
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
        private static bool MovieDelete()
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
            } while (true);
            List<string> Name = new List<string>();
            List<string> Description = new List<string>();
            List<decimal> Time = new List<decimal>();
            List<bool> Own = new List<bool>();
        }
        // keeping the information the user gives us
        static string Name;
        static string Description;
        static decimal Time;
        static bool Own;
        static bool Delete;
    }          
         
            
        
        
        
}
    

