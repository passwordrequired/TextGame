//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Animal Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################

using System;
using System.Threading;
using static System.Console;
namespace HWTextGameJG
{
    internal class Animal : IEdible
    {
        private string color;
        private string size;
        private int legs;
        private int eyes;
        private string name;
        private bool hasKey;
        private int numChunks;
        public Animal(int[] legs, string name, bool hasKey)
        {
            // assigning user inputted list
            legAmounts = legs;

            //assigning attributes
            this.name = name;
            color = AttributeAssignment(colors);
            size = AttributeAssignment(sizes);
            this.legs = AttributeAssignment(legAmounts);
            eyes = AttributeAssignment(eyeAmounts);
            //FavoriteFood = AttributeAssignment(foods);
            this.hasKey = hasKey;
            numChunks = Player.Dice(2, 6);
         }
        private string[] colors = { "brown", "black", "blue", "red", "yellow", "green", "white", "orange", "purple", "indigo" };
        private string[] sizes = { "kaiju-sized", "giant", "huge", "very large", "large", "medium", "small", "very small", "tiny", "microscopic" };
        private int[] eyeAmounts = { 0, 1, 2, 3, 4, 6, 8, 10, 12, 100 };
        private int[] legAmounts=  new int[10];
        public string Name { get { return name; } }
        public string Color { get { return color; } }
        public string Size { get { return size; } }
        public int Legs { get { return legs; } }
        public int Eyes { get { return eyes; } }
        public bool HasKey { get { return hasKey; } }
        private static string AttributeAssignment(string[] list) //for string attributes
        {
            //attributes
            string value;

            value = list[Player.Dice(1, list.Length)];

            return value;
        }
        private static int AttributeAssignment(int[] list) //for int attributes
        {
            //attributes
            int value;

            value = list[Player.Dice(1, list.Length)];

            return value;
        }
        public void Bite()
        {
            //attributes
            bool isContinuing = true;
            string input;

            //is it eaten already? if there's still more, ask the user if they want to continue.
            while (isContinuing)
            {
                //resetting loop variable
                isContinuing = false;
                //running dialogue
                if (IsConsumed())
                {
                    WriteLine("*Nothing left but bones.*");
                    WriteLine("I genuinely want to know what is wrong with you.");
                }
                else
                {
                    WriteLine("*You take a nice big bite.*");
                    switch (numChunks)
                    {
                        case 0:
                            WriteLine("*Allllllllll gone.*");
                            break;
                        case 1:
                            WriteLine("Why are you doing this?");
                            break;
                        case 2:
                            WriteLine("...");
                            break;
                        case 3:
                            WriteLine("This is disgusting.");
                            break;
                        case 4:
                            WriteLine("Wha... What?");
                            break;
                    }
                }
                if (numChunks == 0)
                {
                    WriteLine("Guess I'll have to fix this later.");
                    isContinuing = false;
                }
                else
                {
                    //seeing if player wants to keep eating
                    Write("Do you want to continue? (Y/N): ");
                    input = DataValidation.StandardInput();
                    while ((input != "y") && (input != "n"))
                    {
                        Write("Invalid Input (Y/N): ");
                        input = DataValidation.StandardInput();
                    }
                    if (input == "y")
                    {
                        isContinuing = true;
                    }
                }
            }
        }
        public bool IsConsumed()
        {
            //attributes
            bool outcome = false;

            //are there any chunks left
            if (numChunks <= 0)
            {
                outcome = true;
            }
            else
            {
                numChunks--;
            }
            return outcome;
        }
    }
}
