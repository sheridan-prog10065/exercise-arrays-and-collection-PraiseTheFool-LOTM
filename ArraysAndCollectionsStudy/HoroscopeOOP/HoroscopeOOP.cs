using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollectionsStudy
{
    /// <summary>
    /// Implementation of the horoscope using object-oriented design for organizing data and achieving a multi-dimensional organization.
    /// In this implementation the horoscope uses a dictionary to associate zodiac sign names with corresponding zodiac sign objects 
    /// THe organization is simpler than using a dictionary that associates names with lists of predictions because the list of 
    /// predictions has been encapsulated and represented using a separate class, the Zodiac Sign. The zodiac sign doesn't just store
    /// the list of predictions but can also implement business logic associated with that list.
    /// </summary>
    class HoroscopeOOP : Horoscope
    {
        //dictionary of string (sign name) to ZodiacSign objects that store the predictions of a horoscope and
        //is searchable by sign name (e.g. What is the list of predictions for "aries"?
        private Dictionary<string, ZodiacSign> _zodiacSignDict;

        /// <summary>
        /// Experiment with the creation and initialization of a dictionary of objects
        /// </summary>
        public HoroscopeOOP()
        {
            //create the horoscope dictionary
            _zodiacSignDict = new Dictionary<string, ZodiacSign>();

            //initialize the horoscope data dictionary
            foreach (string signName in _zodiacSignArray)
            {
                //create the zodiac sign. Compare and contrast with the HoroscopeDict implementation which uses
                //collections only wihtout other classes. Which code is simpler?
                ZodiacSign sign = new ZodiacSign(signName);
                
                //add the list of predictions to the dictionary. Use "all lower case" zodiac names
                _zodiacSignDict[signName.ToLower()] = sign;
            }
        }

        /// <summary>
        /// Investigate different ways to iterate through a dictionary of objects. Compare and contrast with the
        /// HoroscopeDict implementation which uses collections exclusively.
        /// </summary>
        public override void EnumerateElements()
        {
            //ask the base class to enumerate the signs
            base.EnumerateElements();

            //enumerate the keys in the dictionary
            Console.WriteLine("Zodiac sign dictionary keys:");
            foreach (string sign in _zodiacSignDict.Keys)
            {
                Console.WriteLine(sign);
            }

            //enumerate the values in the dictionary
            Console.WriteLine("Zodiac sign dictionary values:");
            foreach (ZodiacSign sign in _zodiacSignDict.Values)
            {
                //The predictions are in the sign
                sign.EnumerateElements();
            }

            //emumerate the dictionary entries which are KeyValuePair objects
            Console.WriteLine("Zodiac dictionary entires:");
            foreach (KeyValuePair<string, ZodiacSign> horoscopEntry in _zodiacSignDict)
            {
                //print the name of the sign
                string signName = horoscopEntry.Key;
                Console.WriteLine("\n========= {0} =============\n", signName);

                //print the predictions
                ZodiacSign sign = horoscopEntry.Value;
                sign.EnumerateElements();
                //TODO: how can we enumerate through the contents of the sign object using a loop without
                //providing access to the internal list?
                foreach (string pred in sign)
                {
                    Console.WriteLine(pred);
                }
            }

        }
        /// <summary>
        /// Indexer with two parameters that allows access to a given 
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public string this[string sign, int pred]
        {
            get { return _zodiacSignDict[sign.ToLower()][pred]; }
            set { _zodiacSignDict[sign.ToLower()][pred] = value; }
        }
    }
}
