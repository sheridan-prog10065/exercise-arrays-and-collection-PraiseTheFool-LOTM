using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Implementation of the horoscope that stores predictions as a multi-dimesional array with 2 dimensions
    /// that organizes the predictions the horoscope can make by zodiac sign. The zodiac signs are inherited
    /// from the base class
    /// </summary>
    class HoroscopeTwoDim : Horoscope
    {
        //two-dimensional array of string objects to store examples of positive predictions by zodiac sign
        private string[,] _multiDimPredArray;

        /// <summary>
        /// Investigate how multi-dimensional arrays are created and initialized and what their properties are
        /// </summary>
        public HoroscopeTwoDim()
        {
            //initialize an array without specifying elements 
            //(100 predictions for each of the 12 zodiac signs
            _multiDimPredArray = new string[12, 10];
        
            Console.WriteLine("_multiDimPredArray.Length = {0}", _multiDimPredArray.Length);
            Console.WriteLine("_multiDimPredArray.GetLength(0) = {0}", _multiDimPredArray.GetLength(0));
            Console.WriteLine("_multiDimPredArray.GetLength(1) = {0}", _multiDimPredArray.GetLength(1));
            Console.WriteLine("_multiDimPredArray.Rank = {0}", _multiDimPredArray.Rank);

            //fill-in the predictions
            for (int iSign = 0; iSign < _multiDimPredArray.GetLength(0); iSign++)
            {
                for (int iPred = 0; iPred < _multiDimPredArray.GetLength(1); iPred++)
                {
                    _multiDimPredArray[iSign, iPred] = GeneratePrediction();
                }
            }
        }

        /// <summary>
        /// Investigate different methods to enumerate / iterate through a multi-dimensional array
        /// </summary>
        public override void EnumerateElements()
        {
            //ask the base class to enumerate the signs
            base.EnumerateElements();

            //enumerate alll the elements of the multidimensional array
            Console.WriteLine("All the predictions in the two-dimensional array");
            foreach (string prediction in _multiDimPredArray)
            {
                Console.WriteLine(prediction);
            }

            //enumerate elements by zodiac sign
            Console.WriteLine("Predictions in the two-dimensional array by zodiac sign");
            for (int iSign = 0; iSign < _multiDimPredArray.GetLength(0); iSign++)
            {
                Console.WriteLine("\n======= {0} =========\n", _zodiacSignArray[iSign]);

                //print the predictions for the CURRENT sign
                for (int iPred = 0; iPred < _multiDimPredArray.GetLength(1); iPred++)
                {
                    Console.WriteLine(_multiDimPredArray[iSign, iPred]);
                }
            }
        }

        /// <summary>
        /// Indexer with two parameters that allows access to the prediction witha given index from a given zodiac sign
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public string this[int sign, int pred]
        {
            get { return _multiDimPredArray[sign, pred]; }
            set { _multiDimPredArray[sign, pred] = value; }
        }
    }
}
