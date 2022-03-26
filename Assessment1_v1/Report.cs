using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

        public void outputConsoleResults(List<int> results)
        {
            //print each different analysis to the console, with a preceding piece of text explaining the meaning of the value
            Console.WriteLine("\nReport of the preceding text input:\n");
            Console.WriteLine("\tNumber of Sentences: {0}", results[0]);
            Console.WriteLine("\tNumber of Letters: {0}", results[1]);
            Console.WriteLine("\tNumber of Vowels: {0}", results[2]);
            Console.WriteLine("\tNumber of Constonants: {0}", results[3]);
            Console.WriteLine("\tNumber of Upper case letters: {0}", results[4]);
            Console.WriteLine("\tNumber of Lower case letters: {0}", results[5]);
            Console.WriteLine("\tNumber of Blank Spaces: {0}\n", results[6]);
        }

        public void outputConsoleLetters(List<int> results)
        {
            string[] ch = {"Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg", "Hh", "Ii", "Jj", "Kk", "Ll", "Mm", "Nn", "Oo", "Pp", 
                "Qq", "Rr", "Ss", "Tt", "Uu", "Vv", "Ww", "Xx", "Yy", "Zz"}; //array of alphabet (upper/lower case)

            Console.WriteLine("Letter:\tCount:\n"); //print header of following information to console
            for (int i = 0; i < results.Count; i++) //loop through both the results list and the alphabet array
            {
                //Write the letter and its corresponding value to the console in a legible format
                Console.WriteLine("    {0}:\t {1}", ch[i], results[i]);
            }
        }
    }
}
