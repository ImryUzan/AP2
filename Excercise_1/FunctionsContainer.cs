using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class FunctionsContainer
    {
        public delegate double myDelegate(double theFunction);

        //dictionary of name and the functions that fit's to the delegate
        private Dictionary<string, myDelegate> myFuncDictionary;
        public FunctionsContainer()
        {
            myFuncDictionary = new Dictionary<string, myDelegate>();
        }
        public myDelegate this[string name]
        {
            get
            {
                //if the func is not in the dictionary
                if (!myFuncDictionary.ContainsKey(name))
                {
                    myFuncDictionary.Add(name, value => value);
                }
                return myFuncDictionary[name];

            }
            set
            {
                //if the func is in the dictionary, set
                if (myFuncDictionary.ContainsKey(name))
                {
                    myFuncDictionary[name] = value;
                }
                //otherwise, add
                else
                {
                    myFuncDictionary.Add(name, value);
                }

            }
        }

        //gets all the missions names in list
        public List<string> getAllMissions()
        {
            List<string> myContainer = new List<string>();
            foreach (KeyValuePair<string, myDelegate> i in myFuncDictionary)
            {
                myContainer.Add(i.Key);
            }
            return myContainer;
        }
    }
}