using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Study program that allows debugging and experiementing with single, multi-dimensional and jagged arrays
    /// as well as collections such as dynamic arrays (List objects) and dictionaries
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program prog = new Program();
                prog.CompareArraysWithLists();
                prog.CreateBaseHoroscope();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TODO: Error handling has not beein built-in. You will have to start again.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Analyze the differences between static arrays and dynamic arrays (list objects) in terms of properties
        /// and how elements are created, accessed and used
        /// </summary>        
        private void CompareArraysWithLists()
        {
            List<string> predList = new List<string>(10);
            try
            {
                Console.WriteLine("The number of predictions in the list is {0}",
                    predList.Count);

                Console.WriteLine("The capacity of the prediction list is {0}",
                    predList.Capacity);

                Console.WriteLine("Fifth prediction is {0}", predList[4]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                string[] predArray = new string[10];
                Console.WriteLine("The length of the array is {0}",
                    predArray.Length);

                string fifthElement = predArray[4];
                Console.WriteLine("Fifth prediction in the array is {0}", (fifthElement == null) ? "null" : fifthElement);
                //attempt to use the element "extracted" from the array
                bool isWin = fifthElement.StartsWith("Win");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Experiment with single-dimensional arrays using the base Horoscope class which encapsulates the array
        /// of signs and test data used to generate predictions, all implemented as single dimensional static arrays
        /// </summary>
        private void CreateBaseHoroscope()
        {
            Console.WriteLine("\n=============== Basic Horoscope Begins ===============");
            Console.WriteLine("Press any key to give the basic horoscope a try");
            Console.ReadKey();
            
            //Investigate the creation of single dimensional arrays and how they get filled with data
            Horoscope baseHoroscope = new Horoscope();

            //Investigate how single dimensional arrays are enumerated / iterated through.
            baseHoroscope.EnumerateElements();

            //Investigate how to access elements from a composite object (an object with a collection of elements 
            //inside using an indexer
            string firstSign = baseHoroscope[0];
            Console.WriteLine("The first sign of the zodiac is {0}", firstSign);

            Console.WriteLine("What is the sign you are looking for (enter an integer 1 to 12)?");
            int signNumber = int.Parse(Console.ReadLine());

            //use the indexer to get an element 
            string userSign = baseHoroscope[signNumber - 1];
            Console.WriteLine(userSign);

            //change an element using the indexer method
            baseHoroscope[0] = firstSign.ToUpper();
            Console.WriteLine("The first sign of the zodiac is now {0}", baseHoroscope[0]);

            Console.WriteLine("=============== Basic Horoscope Ends ===============\n");
        }

    }
}
