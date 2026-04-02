using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Implementation of the horoscope that stores predictions as a jagged array with 2 dimensions
    /// that organizes the predictions the horoscope can make by zodiac sign. The zodiac signs are inherited
    /// from the base class
    /// </summary>
    class HoroscopeJagged : Horoscope
    {
        //jagged array with two dimensions (arrays of arrays) of predictionsto store examples of negative predictions
        private string[][] _jagPredArray;

        /// <summary>
        /// Investigate how jagged arrays are created and initialized and what their properties are in contrast with multi-dimensional arrays
        /// </summary>
        public HoroscopeJagged()
        {
            //create a jagged array of negative  predictions, 100  predictions
            //for each of the 12 zodiac signs
            _jagPredArray = new string[12][];

            //print the jagged array properties and compare with a multidimensional array
            Console.WriteLine("_jagPredArray.Length = {0}", _jagPredArray.Length);
            Console.WriteLine("_jagPredArray.GetLength(0) = {0}", _jagPredArray.GetLength(0));
            try
            {
                //Jagged arrays are treated as a single dimension array of array elements
                Console.WriteLine("_jagPredArray.GetLength(0) = {0}", _jagPredArray.GetLength(1)); 
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The jagged array is a one-dimensional array of arrays objects.");
            }
            Console.WriteLine("_jagPredArray.Rank = {0}", _jagPredArray.Rank);

            //add the arrays of predictions inside the  jagged array
            for (int iSign = 0; iSign < _jagPredArray.Length; iSign++)
            {
                //the requirement to create the inner "boxes" allows each inner array to have a different length / capacity
                _jagPredArray[iSign] = new string[10];

                //fill in the predictions for the current sign
                for (int iPred = 0; iPred < _jagPredArray[iSign].Length; iPred++)
                {
                    _jagPredArray[iSign][iPred] = GeneratePrediction();
                }
            }
        }

        /// <summary>
        /// Investigate different methods to enumerate / iterate through a jagged array
        /// </summary>
        public override void EnumerateElements()
        {
            //ask the base class to enumerate the signs
            base.EnumerateElements();

            //enumerate all the elements of the jagged array. In contrast with the multi-dimensional array
            //the jagged array allows itereation with for-each by dimension
            Console.WriteLine("Predictions in the jagged array");
            foreach (string[] signPredictions in _jagPredArray)
            {
                Console.WriteLine("============================================");
                Console.WriteLine(signPredictions);

                foreach(string prediction in signPredictions)
                {
                    Console.WriteLine(prediction);
                }
                
            }

            //enumerate elements by zodiac sign
            Console.WriteLine("Predictions in the jagged array by zodiac sign");
            for (int iSign = 0; iSign < _jagPredArray.GetLength(0); iSign++)
            {
                Console.WriteLine("\n======= {0} =========\n", _zodiacSignArray[iSign]);

                //print the predictions for the CURRENT sign
                string[] predArrayForSign = _jagPredArray[iSign];
                for (int iPred = 0; iPred < predArrayForSign.GetLength(0); iPred++)
                {
                    Console.WriteLine(_jagPredArray[iSign][iPred]);
                }
            }
        }

        /// <summary>
        /// Indexer with two parameters that allows access to the prediction witha given index from a given zodiac sign.
        /// Note how the indexer hides the implementation detail of what kind of internal array is used, multi-dimensional
        /// or jagged
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public string this[int sign, int pred]
        {
            get { return _jagPredArray[sign][pred]; }
            set { _jagPredArray[sign][pred] = value; }
        }

    }
}
