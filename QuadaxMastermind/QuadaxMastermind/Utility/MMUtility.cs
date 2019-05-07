/*
This file is dedicated to helpers for the mastermind game.
Project: QuadaxMastermind
Author: Joe Nichols
Date: 5/4/2019
*/
using System;
using System.Collections;
using System.Text;
using System.Linq;

namespace QuadaxMastermind.Utility
{
    public class MMUtility
    {
        public MMUtility( int[] userEntry)
        {
            this.userEntry = userEntry;
        }

        public static int[] answerArray = new int[4];
        public ArrayList exactResults = new ArrayList();
        public ArrayList containedResults = new ArrayList();
        public int[] userEntry = new int[4];


        public static void GenerateAnswerArray(){

            for (int i = 0; i < 4; i++)
            {
                Random random = new Random();    
                answerArray[i] = random.Next(1, 6);  
            }
        }

        public static Boolean IsValidEntry(String input, out int[] numbers)
        {
            // we need to make sure it is 4 numbers and return that string as an int
            bool valid = (input.Length == 4) && int.TryParse(input, out int num);
            if (valid)
            {
                numbers = StringToInt(input);
            }
            else
            {
                numbers = null;
            }
            return valid;
        }
        
        public Boolean EvaluateCharVsAnswer()
        {
            FindCharactersInAnswer();
            if(answerArray.SequenceEqual(userEntry))
            {
                return true;
            }
            return false;
        }

        private void FindCharactersInAnswer()
        {
            foreach (int num in userEntry)
            {
                int index = Array.IndexOf(userEntry,num);
                if (answerArray.Contains(num) && (answerArray[index] == num))
                {
                    exactResults.Add("+");
                }
                else if (answerArray.Contains(num))
                {
                    containedResults.Add("-");
                }
            }
        }

        private static int[] StringToInt(string input)
        {
            int[] newArray = new int[4];

            for (int i = 0; i < 4; i++)
            {
                newArray[i] = input[i] - '0';
            }
            return newArray;
        }

        public string ResultOfGuess()
        {
            StringBuilder strBuild = new StringBuilder();
            for(var i = 0; i < exactResults.Count; i++)
            {
                strBuild.Append(exactResults[i]);
            }
            for (var j = 0; j < containedResults.Count; j++)
            {
                strBuild.Append(containedResults[j]);
            }
            return strBuild.ToString();
        }
    }
}