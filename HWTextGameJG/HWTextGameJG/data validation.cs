//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Data Validation Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HWTextGameJG
{
    internal static class DataValidation
    {
        public static string StandardInput(Player player)
        {
            Write("What do you want to do?: ");
            string input = Console.ReadLine().Trim().ToLower();
            while (input == "item")
            {
                WriteLine("You are holding {0}.", player.ItemInHand);
                Write("What do you want to do?: ");
                input = Console.ReadLine().Trim().ToLower();
            }
            if (input == "q")
            {
                Setup.GameEnd();
            }
            return input;
        }
        public static string StandardInput()
        {
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "q")
            {
                Setup.GameEnd();
            }
            return input;
        }
        public static bool Input(string input)
        {
            //attributes
            bool isCorrect;

            if (input == "q")
            {
                Setup.GameEnd();
            }

            if (!String.IsNullOrEmpty(input))
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            return isCorrect;
        }
        public static bool Input(string parameter, string input)
        {
            //attributes
            bool isCorrect;

            if (input == "q")
            {
                Setup.GameEnd();
            }

            if (parameter == input)
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            return isCorrect;
        }
        public static bool Input(int min, int max, int input)
        {
            //attributes
            bool isCorrect;

            if ((input >= min) && (input <= max))
            {
                isCorrect = true;
            }
            else { isCorrect = false; }
            return isCorrect;
        }
        public static bool ArrayCheck(string[] array, string value)
        {
            for (int i = 0; i < array.Length; i++) //checking array for duplicates
            {
                if (DataValidation.Input(array[i].ToLower(), value))
                {
                    return true; //something matched
                }
            }

            return false; //nothing matched
        }
    }
}
