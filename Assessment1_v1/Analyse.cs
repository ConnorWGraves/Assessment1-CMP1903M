using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            int freq = 0; //counter
        

            //1. Number of sentences
            int sentenceFreq; //variable to store how many sentences there are
            char sentence = '.'; //full stop character to check against every charater in the input
            foreach (char c in input) //loop through every character in the string input
            {
                if(c == sentence) //if the character is a '.'
                {
                    freq++; //incriment freq by one
                }
            }
            sentenceFreq = freq; //asign freq to sentence freq
            freq = 0; //reset value of freq to 0 so it can be reused


            //1.5. Total Characters
            int totalFreq;
            foreach (char c in input) //loop through every character in the string input
            {
                if (Char.IsLetter(c)) //if the current character is a letter
                {
                    freq++; //increment the variable freq by one
                }
            }
            totalFreq = freq;
            freq = 0; //reset freq value


            //2. Number of vowels
            int vowelFreq; //variable to store number of vowels
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }; //Array of all vowels
            foreach (char c in input) //loop through every character in the input
            {
                foreach (char v in vowels) //compare each character to all vowels, both upper and lower case
                {
                    if (c == v) //if the current character is a vowel
                    {
                        freq++; //increment the variable freq by one
                        break; //break the loop as the character cannot be more than one vowel
                    }
                }
            }
            vowelFreq = freq;
            freq = 0;


            //3. Number of consonants
            int consonantFreq; //variable to store number of vowels
            char[] consonants = {'b', 'c', 'd', 'f', 'g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','y','z',
                'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Y','Z'};//Array of all consonants
            foreach (char c in input)
            {
                foreach (char v in consonants) //compare each character in the string input to all constonants, upper and lower case
                {
                    if (c == v) //if the character is a constonant
                    {
                        freq++; //increment freq by one
                        break; //character cannot be more than one constonant simultaneously
                    }
                }
            }
            consonantFreq = freq;
            freq = 0; //reset freq value


            //4. Number of upper case letters
            bool check;
            int upperFreq;
            foreach(char c in input)
            {
                check = Char.IsUpper(c); //if the current charatcer is an upper case letter
                if (check)
                {
                    freq++; //increment freq by one
                }
            }

            upperFreq = freq;
            freq = 0; //reseet freq


            //5. Number of lower case letters
            int lowerFreq;
            foreach (char c in input)
            {
                check = Char.IsLower(c); //if the current character is a lower case letter
                if(check)
                {
                    freq++; //increment freq by one
                }
            }

            lowerFreq = freq;
            freq = 0;

            //6. Number of blank spaces
            int blankFreq;
            foreach (char c in input)
            {
                if (Char.IsWhiteSpace(c)) //if the current character is a space
                {
                    freq++; //increment freq by one
                }
            }
            blankFreq = freq;

            List<int> values = new List<int>(); //initialise list to store the analysis
            //add all of the folowing values into the list in the corresponding order
            values.Add(sentenceFreq);
            values.Add(totalFreq);
            values.Add(vowelFreq);
            values.Add(consonantFreq);
            values.Add(upperFreq);
            values.Add(lowerFreq);
            values.Add(blankFreq);


            return values; //return the list to the main code
        }

        public List<int> lettersText(string text) //method for counting how many of each letter is present in the input string
        {
            List<int> letters = new List<int>(); //initialise list to store number of  appearances of each letter
            char[] ch = {'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j',
            'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V',
            'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z'}; //array of all letters
            int freq;

            for (int i = 0; i < ch.Count(); i += 2) //loop that increments by two for each itteration
            {
                freq = 0; //reset freq to 0 for each different letter
                foreach(char c in text) //for each character in the string input
                {
                    if(ch[i] == c) //is the current character the upper case varient e.g. A
                    {
                        freq++; //increment by one
                    }
                    if(ch[(i+1)] == c) //is the cirrent character the lower case varient e.g. a
                    {
                        freq++; //increment by one
                    }
                }
                letters.Add(freq); //add total of letter appearences in string input to the list letters
            }

            return letters; //return value to main program
        }

        public void longWords(string text) //method to analyse a text input then produce a text file of words longer than 7 in it
        {
            string temp = ""; //sotre temporary strings here
            List<string> words = new List<string>(); //store list of long words
            foreach (char c in text) //loop through every character in the text input
            {
                if (Char.IsWhiteSpace(c)) //if the current character is whitespace
                {
                    if (temp.Length > 7) //if the word is longer than 7 characters
                    {
                        words.Add(temp); //add to list words
                    }
                    temp = ""; //reset temp
                }
                else
                {
                    temp += c.ToString(); //append current character to string
                }
            }

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"longWords.txt"); //get current directory
            using (StreamWriter sw = File.CreateText(path)) //create file
            {
                foreach (string word in words)
                {
                    sw.WriteLine(word); //write each word to a line in the text file
                }
            }
        }
    }
}
