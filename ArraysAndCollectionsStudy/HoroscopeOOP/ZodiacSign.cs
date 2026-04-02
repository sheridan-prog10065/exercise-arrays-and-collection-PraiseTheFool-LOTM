using System;
using System.Collections;
using System.Collections.Generic;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Part of the object-oriented design for the Horoscope, this class represents a given zodiac sign with its predictions.
    /// The zodiac is designed as a collection of zodiac sign objects.
    /// </summary>
    class ZodiacSign : IEnumerable<string>
    {
        /// <summary>
        /// The name of the sign
        /// </summary>
        private string _signName;

        /// <summary>
        /// The list of predictions for this zodiac sign
        /// </summary>
        private List<string> _predList;

        /// <summary>
        /// Investigate how a simple list (dynamic array) of strings is createted and initialized 
        /// </summary>
        /// <param name="signName"></param>
        public ZodiacSign(string signName)
        {
            _signName = signName;

            //create the prediction list and fill it with random predictions
            _predList = new List<string>();

            //add the predictions
            for (int iPred = 0; iPred < 10; iPred++)
            {
                _predList.Add(Horoscope.GeneratePrediction());
            }
        }

        /// <summary>
        /// Experiement with simple enumeration of a dynamic array (List in .NET)
        /// </summary>
        public void EnumerateElements()
        {
            foreach (string pred in _predList)
            {
                Console.WriteLine(pred);
            }
        }

        /// <summary>
        /// Interface implementation that allows the use of "foreach" to enumerate the predictions in a zodiac sign
        /// </summary>
        /// <returns>Interface to the enumerator of the  prediction list</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)_predList).GetEnumerator();
        }

        /// <summary>
        /// Interface implementation that allows the use of "foreach" to enumerate the predictions in a zodiac sign
        /// This provides implementation for the legacy interface definition prior to definition of generics-based collection
        /// </summary>
        /// <returns>Interface to the enumerator of the  prediction list</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)_predList).GetEnumerator();
        }

        /// <summary>
        /// Indexer that allows access for get and set to elements inside the zodiac sign, the predictions
        /// </summary>
        /// <param name="iSign"></param>
        /// <returns></returns>
        public string this[int iSign]
        {
            get { return _predList[iSign]; }
            set { _predList[iSign] = value; }
        }

    }
}