using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetTester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> myList = popRands(15);
            Random rand = new Random();

            double target = Math.Round((rand.NextDouble() * (10 - (-10)) + -10),2);

            var subsets = getDoubles(myList);
            int k = 0;
            foreach (var item in subsets)
            {
                if(item.Value == target)
                {
                    Console.WriteLine("\n\n\n\nFOUND MATCH" + k + "||" + item.Key + ": " + item.Value);
                }
                else
                {
                    //Console.WriteLine(k + "||" + item.Key + ": " + item.Value);
                }
                k++;
            }
        }

        public static List<double> popRands(int size)
        {
            List<double> ret = new List<double>();
            int k;
            Random rand = new Random();
            for(k = 0; k < size; k++)
            {
                
                double num = Math.Round((rand.NextDouble() * (10 - (-10)) + -10),2);
                ret.Add(num);
            }

            return ret;
        }

        public static Dictionary<string,double> getDoubles(List<double> myList)
        {
            Dictionary<string, double> outputPowerSet = new Dictionary<string, double>();


            int setLength = myList.Count;
            int powerSetLength = 1 << setLength;
            for (int bitMask = 0; bitMask < powerSetLength; bitMask++)
            {
                string key = "";
                double list = 0;
                var subSet = from x in myList
                             where ((1 << myList.IndexOf(x)) & bitMask) != 0
                             select x;
                
                foreach(var item in subSet)
                {
                    key += item + "|";
                    list += item;
                }
                outputPowerSet.Add(key,list);
            }

            return outputPowerSet;
        }
    }

}
