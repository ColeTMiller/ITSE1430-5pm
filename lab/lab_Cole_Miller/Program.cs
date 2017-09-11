using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Cole_Miller
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            do
            {
                char choice = MovieSelection();
                switch (choice)
                {
                    case '1':
                    AddMovie(string[] args);
                    break;

                    case '2':
                    ListMovie(string[] args);
                    break;

                    case '3':
                    DeleteMovie(string[] args);
                    break;

                    case '4': quit = true; break;
                }
            } while (!quit);
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
                char letter = Char.ToUpper(input[0]);
                if (input == '1')
                    return AddMovie(string[] args);
                else if (input == '2')
                    return ListMovies(string[] args);
                else if (input == '3')
                    return DeleteMovie(string[] args);

                // Error
                Console.WriteLine("Please Choose a valid option");
            }
        }
        static int AddMovie(string[] args)
        {

        }
        
        static int ListMovie(string[] args)
        {

        }
        static int DeleteMovie( string args)
        {

        }
    }
    
}
