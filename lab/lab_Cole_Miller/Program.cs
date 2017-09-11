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
            Movieselection MyCode = new Movieselection();

            MyCode.MovieOption(); 
        }
    }
    class Movieselection
    {
        public int MovieOption()
        {
            Console.WriteLine("What selection do you want to make: ");
            Console.WriteLine("1. Add a Movie");
            Console.WriteLine("2. List Movie");
            Console.WriteLine("3. Delete Movie");
            Console.WriteLine("4. Quit");
            Console.ReadLine();
            return Convert.ToInt32(result); 
        }
    }
}
