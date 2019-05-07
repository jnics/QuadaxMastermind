/*
This file containsthe core functionality of the mastermind game.
Project: QuadaxMastermind
Author: Joe Nichols
Date: 5/4/2019
*/
using System;
using System.Collections;
using System.Linq;
using QuadaxMastermind.Utility;

namespace QuadaxMastermind
{

    public class MastermindGame
    {

        static void Main()
        {
            int attempts = 0;
            MMUtility.GenerateAnswerArray();
            Console.WriteLine("Welcome to our fun Mastermind game. Press any key to continue: ");
            Console.ReadKey();
            Console.WriteLine("Please enter a 4 digit number where each digit is between 1 and 6: ");

            while(attempts < 10)
            { 
                if (MMUtility.IsValidEntry(Console.ReadLine(), out int[] userEntry))
                {
                    MMUtility util = new MMUtility(userEntry);
                    var win = util.EvaluateCharVsAnswer();
                    Console.WriteLine("Result of you guess : " + util.ResultOfGuess());
                    if (win)
                    {
                        Console.WriteLine("Congratulations got have cracked the code.");
                        break;
                    }
                    else if (attempts == 9)
                    {
                        Console.WriteLine("Sorry. Maybe next time you will fair better.");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a new number: ");
                    }
                    attempts++;
                }
                else
                {
                    Console.WriteLine("Please enter a valid set of numbers: ");
                }
            }
        }
    }
}