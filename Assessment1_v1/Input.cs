using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {

        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            Console.WriteLine("Each line typed must be a full sentence, and end in  a full stop");
            Console.WriteLine("Upon writing your final sentence, end the line with a '*' to begin analysis");
            Console.WriteLine("Please enter your text: "); //write to console to inform user on what to do
            List<string> sentences = new List<string>(); //List to store the users inputed sentences
            string temp; //variable to temporarily store each sentence
            bool check = true;
            while(check == true) //runs until at least one sentence has been inputted
            {
                temp = Console.ReadLine(); //read user input
                if (temp.EndsWith("*")) //if the input ends in *
                {
                    temp = temp.Remove(temp.Length - 1); //remove * as it is not needed
                    if (sentences.Count() < 1) //if there isnt any sentences already
                    {
                        if (!temp.EndsWith(".")) //if the current sentece does not end in a .
                        {
                            Console.WriteLine("You must enter at least one sentence"); //error message for user
                        }
                        else //if current sentence ends in full stop
                        {
                            sentences.Add(temp);
                            check = false;
                        }
                    }
                    else if (temp.EndsWith(".")) //if currnt sentence ends in a full stop
                    {
                        sentences.Add(temp);
                        check = false;
                    }
                    else //if current sentece does not end in a full stop
                    {
                        Console.WriteLine("Sentences must end in a full stop"); //error message for user
                    }
                }
                else if (temp.EndsWith(".")) //if current sentence ends in a full stop
                {
                    sentences.Add(temp);
                }
                else //current sentence does not end in a full stop
                {
                    Console.WriteLine("Sentences must end in a full stop");
                }
            }
            string text = "";
            foreach(string sentence in sentences) //concatonate all senteces into one string
            {
                text += sentence + " ";
            }

            Console.WriteLine(text);

            return text;

        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Sentences.txt"); //get file path
            string text = File.ReadAllText(path); //read text file
            Console.WriteLine(text); //prnt text file to console
            return text; //return text to main program
        }

        public string userChoice() //method to get an input from the user to decide on what method to read text will be used
        {
            string choice; //declare choice here so it only has to be declared once
            while(true) //will loop indefinately until there is a valid entry
            {
                //declare to the user what valid entries are
                Console.WriteLine("Please enter '1' to enter text manualy and '2' to read the predefined text file:");
                choice = Console.ReadLine(); //reaad user input
                if (choice == "1")
                {
                    return choice; //return user input if valid entry '1' is selected
                }
                else if (choice == "2")
                {
                    return choice; //return user input if valid entry '2' is selected
                }
            }
        }

    }
}
