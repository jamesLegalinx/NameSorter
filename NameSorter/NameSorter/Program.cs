using System;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            NameSorter n = new NameSorter();

            if (args[0] != null)
            {
                n.InputFileName = args[0].ToString();
                Console.WriteLine("args :- " + args[0].ToString());
            }
            else
            {
                n.InputFileName = "unsorted-names-list.txt";
                Console.WriteLine("no args maan");
            }

            n.NameSortFile();

            Console.Write("Press a key to finish...");
            Console.ReadKey();            
        }


    }
}
