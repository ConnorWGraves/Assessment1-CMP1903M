//Version One of CMP1903M Assessment 1
//Manualy add file path to text file of your choosing
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main() //where program begins
        {

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Input I = new(); //new input object
            string choice = I.userChoice(); //get user input for what method of text entry they wish to use

            string text = ""; //declare text here so it has the correct level of scope
            if (choice == "1")
            {
                text = I.manualTextInput(); //if '1' is the user choice the manual text entry method is selected
            }
            else if (choice == "2")
            {
                text = I.fileTextInput(); //if '2' is selected the read a text file method is selected
            }
           
            
            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method
            Analyse A = new(); //new analyse object
            List<int> results = A.analyseText(text); //Receive a list of integers back
            if (choice == "2")
            {
                A.longWords(text);
            }
            A.longWords(text);


            //Report the results of the analysis
            Report R = new(); //new report object
            R.outputConsoleResults(results); //run report method, prints analysis values to console, no return value


            //TO ADD: Get the frequency of individual letters?
            List<int> letters = A.lettersText(text); //geta list of how many of each letter there is (upper and lower case)
            R.outputConsoleLetters(letters); //prints the list onto the console
        }



    }
}
