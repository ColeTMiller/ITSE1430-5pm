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
            ;
        }

        private static void AddMovie()
        {
            ;
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
                if (input !=null && input.Length !=0)
                {
                    if (string.Compare(input, '1', true) == 0)
                        return AddMovie();
                    if (input == '1')
                        return AddMovie();
                    else if (input == '2')
                        return ListMovies();
                    else if (input == '3')
                        return DeleteMovie();

                // Error
                Console.WriteLine("Please Choose a valid option");
            }
        }
        
        
        
        
    }
    
}
