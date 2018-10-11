using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NameSorter
{
    public class NameSorter
    {
        public string InputFileName;
        
        public bool NameSortFile()
        {
            try
            {
                // Read file into object
                List<Person> names = LoadFile(InputFileName);
                names = SortNamesAsc(names);

                Console.WriteLine("");
                Console.WriteLine("New List");

                // output new sorted list order
                foreach (Person p in names)
                {
                    Console.WriteLine(p.FirstNames + p.SurName);
                }

                SaveListToFile(names, "./sorted-names-list.txt");

                return true;
            }
            catch(Exception ex)

            {
                return false;
            }
        }


        /// <summary>
        /// read file into List of string
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<Person> LoadFile(string InputFileName)
        {
            string line;

            List<string> unsortedNames = new List<string>();
            List<Person> people = new List<Person>();

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("fileName:- " + InputFileName);            

            System.IO.StreamReader file = new System.IO.StreamReader(InputFileName);

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                List<string> nameSplit = line.Trim().Split(' ').ToList();

                int nameCount = nameSplit.Count;
                string surname = nameSplit[nameCount - 1];
                string firstNames = line.Replace(surname, "");

                Person p = new Person(firstNames, surname);
                people.Add(p);                
            }
            file.Close();    
            return people; 
        }


        /// <summary>
        /// sort list names into alphabetic order on surname
        /// </summary>
        /// <param name="unsortedNames"></param>
        /// <returns></returns>
        private List<Person> SortNamesAsc(List<Person> unsortedNames)
        {            
            List<Person> sortedPeople = unsortedNames.OrderBy(s => s.SurName).ThenBy(s => s.FirstNames).ToList();  
            return sortedPeople;
        }


        private bool SaveListToFile(List<Person> people, string OutputFileName)
        {
            try
            {
                System.IO.TextWriter tw = new StreamWriter(OutputFileName);

                foreach (Person p in people)
                {
                    tw.WriteLine(p.FirstNames + p.SurName);
                }
                tw.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        

        class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstNames = firstName;
                SurName = lastName;
            }

            public string FirstNames { get; set; }
            public string SurName { get; set; }
        }
    }
}
