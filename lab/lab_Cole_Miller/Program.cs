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
                switch (choice)
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

        private static void DeleteMovie()
        {
            ;
        }

        private static void ListMovie()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine(Time);
            Console.WriteLine(OWN);
        }

        private static void AddMovie()
        {
            Console.WriteLine("Enter Movie Name: ");
            Name = Console.ReadLine().Trim();
            Console.WriteLine("Enter description of Movie: ");
            Description = Console.ReadLine().Trim();
            Console.WriteLine("Enter how long the movie is: ");
            Time = Console.ReadLine().Trim();
            Console.WriteLine("Do you own this movie: ");
            OWN = Console.ReadLine().Trim(); 

        }

        static char MovieSelection()
        {
            while (true)
            {
                Console.WriteLine("What selection would you like to make:");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. List Movies");
                Console.WriteLine("3. Delete Movie");
                Console.WriteLine("4. Quit Program");

                string input = Console.ReadLine();
                
                if (input != null && input.Length != 0)
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
        // Keeping the information the user gives us 
       static string Name;
       static string Description;
       static decimal Time;
       static bool OWN;
        
        
        
    }
    
}
