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
                prog.CreateTwoDimensionalHoroscope();
                prog.CreateJaggedHoroscope();
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

        /// <summary>
        /// Exeperiment with multi-dimensional arrays. The HoroscopeTwoDim class used a multi-dimensional array with
        /// two dimensions to store horoscope predictions organized by zodic sign
        /// </summary>
        private void CreateTwoDimensionalHoroscope()
        {
            Console.WriteLine("\n=============== Two Dimensional Horoscope Begins ===============");
            Console.WriteLine("Press any key to give the two dimensional horoscope a try");
            Console.ReadKey();

            //use a multi-dimensional horoscope which has a multi-dimensional list of predictions and is derived from horoscope
            //Investigate the creation of multi-dimensional arrays and how they get filled with data
            HoroscopeTwoDim hTwoDim = new HoroscopeTwoDim();

            //Investigate how multi-dimensional arrays are enumerated / iterated through.
            hTwoDim.EnumerateElements();

            //Investigate how to access elements from a composite object (an object with a collection of elements) 
            //inside using an indexer when the collection of elements inside the object multi-dimensional
            string firstPred = hTwoDim[0, 0];
            Console.WriteLine("The first prediction in the zodiac is {0}.", firstPred);

            Console.WriteLine("What is the sign you are looking for (enter an integer 1 to 12)?");
            int signNumber = int.Parse(Console.ReadLine());

            //use the indexer to get an element 
            string userSign = hTwoDim[signNumber - 1]; //this indexer is inherited from the base class
            Console.WriteLine(userSign);

            Console.WriteLine("Choose a random number between 0 and 9 for your prediction:");
            int randPredIndex = int.Parse(Console.ReadLine());

            //use the indexer to get an element 
            string userPrediction = hTwoDim[signNumber - 1, randPredIndex];
            Console.WriteLine($"The prediction {randPredIndex} in {userSign} is {userPrediction}");

            //change an element using the indexer method
            hTwoDim[0, 0] = "Get a great summer job";
            Console.WriteLine("The first prediction in the zodiac is {0}.", hTwoDim[0, 0]);

            Console.WriteLine("=============== Two Dimensional Horoscope Ends ===============\n");
        }

        /// <summary>
        /// Exeperiment with jagged arrays. Compare and contrast with multi-dimensional arrays. The HoroscopeTwoDim class used a 
        /// multi-dimensional array with two dimensions to store horoscope predictions organized by zodic sign
        /// </summary>
        private void CreateJaggedHoroscope()
        {
            Console.WriteLine("\n=============== Jagged Horoscope Begins ===============");
            Console.WriteLine("Press any key to give the jagged horoscope a try");
            Console.ReadKey();

            //use a multi-dimensional horoscope which has a multi-dimensional list of predictions and is derived from horoscope
            //Investigate the creation of jagged arrays and how they get filled with data
            HoroscopeJagged hJagged = new HoroscopeJagged();

            //Investigate how jagged arrays are enumerated / iterated through.
            hJagged.EnumerateElements();

            //Investigate how to access elements from a composite object (an object with a collection of elements) 
            //inside using an indexer when the collection of elements inside the object multi-dimensional
            string firstPred = hJagged[0, 0];
            Console.WriteLine("The first prediction in the zodiac is {0}.", firstPred);

            Console.WriteLine("What is the sign you are looking for (enter an integer 1 to 12)?");
            int signNumber = int.Parse(Console.ReadLine());

            //use the indexer to get an element 
            string userSign = hJagged[signNumber - 1]; //this indexer is inherited from the base class
            Console.WriteLine(userSign);

            Console.WriteLine("Choose a random number between 0 and 9 for your prediction:");
            int randPredIndex = int.Parse(Console.ReadLine());

            //use the indexer to get an element 
            string userPrediction = hJagged[signNumber - 1, randPredIndex];
            Console.WriteLine($"The prediction {randPredIndex} in {userSign} is {userPrediction}");

            //change an element using the indexer method
            hJagged[0, 0] = "Get a great summer job";
            Console.WriteLine("The first prediction in the zodiac is {0}.", hJagged[0, 0]);

            Console.WriteLine("=============== Jagged Horoscope Ends ===============\n");
        }

    }
}
