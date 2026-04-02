using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Implementation of the horoscope that stores predictions as using a mix of collections and 
    /// organizes the predictions of the horoscope as a dictionary that associates the zodiac sign name
    /// with a list of predictions. The zodiac signs are inherited from the base class
    class HoroscopeDict : Horoscope
    {
        //dictionary of string (sign name) to list of strings (predictions) to store the predictions of a horoscope and
        //is searchable by sign name (e.g. What is the list of predictions for "aries"?
        private Dictionary<string, List<string>> _predDict;

        /// <summary>
        /// Investigate how dictionary collections are created and initialized
        /// </summary>
        public HoroscopeDict()
        {
            //create the horoscope dictionary
            _predDict = new Dictionary<string, List<string>>();

            //initialize the horoscope data dictionary
            foreach (string signName in _zodiacSignArray)
            {
                //create the prediction list. This is annalogous to how jagged arrays have to be initialized and
                //leads to the same attribute of the data structure allowing a jagged organization
                List<string> predList = new List<string>();

                //add the predictions
                for (int iPred = 0; iPred < 10; iPred++)
                {
                    predList.Add(GeneratePrediction());
                }

                //add the list of predictions to the dictionary. Use "all lower case" zodiac names as keys in the dictionary
                //Compare and contarst with the array syntax in the jagged array
                _predDict[signName.ToLower()] = predList;
            }
        }

        /// <summary>
        /// Investigate various methods of enumerating / iterating through the data stored in a dictionary collection
        /// </summary>
        public override void EnumerateElements()
        {
            //ask the base class to enumerate the signs
            base.EnumerateElements();

            //enumerate the keys in the dictionary
            Console.WriteLine("Zodiac sign dictionary keys:");
            foreach (string sign in _predDict.Keys)
            {
                Console.WriteLine(sign);
            }

            //enumerate the values in the dictionary
            Console.WriteLine("Zodiac sign dictionary values:");
            foreach (List<string> predList in _predDict.Values)
            {
                Console.WriteLine(predList);

                foreach (string pred in predList)
                {
                    Console.WriteLine(pred);
                }
            }

            //emumerate the dictionary entries which are KeyValuePair objects
            Console.WriteLine("Zodiac dictionary entires:");
            foreach (KeyValuePair<string, List<string>> horoscopEntry in _predDict)
            {
                //print the name of the sign
                string signName = horoscopEntry.Key;
                Console.WriteLine("\n========= {0} =============\n", signName);

                //print the predictions
                List<string> predListForSign = horoscopEntry.Value;
                foreach (string pred in predListForSign)
                {
                    Console.WriteLine(pred);
                }
            }

        }

        /// <summary>
        /// Indexer with two parameters that allows access to a given. In this case the indexer
        /// does just use integers as parameters and can match the type of key used in the dictionary
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public string this[string sign, int pred]
        {
            get { return _predDict[sign.ToLower()][pred]; }
            set { _predDict[sign.ToLower()][pred] = value; }
        }
    }
}
