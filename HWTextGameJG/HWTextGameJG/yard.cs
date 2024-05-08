//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Yard Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19 -24
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
    internal static class Yard
    {
        public static Player DoorApproach(Player player)
        {
            //attributes
            int steps;
            int position = 0;

            //player starts one (1) step away from the entrance
            //  ask the player how far they want to walk
            WriteLine("You are ten (10) steps away from a tall dark mansion in the woods. How did you get here? I have no idea. I would never.");
            while (position < 10)
            {
                Write("How many steps do you want to take? (1-10): ");
                Int32.TryParse(DataValidation.StandardInput(), out steps);
                while (!DataValidation.Input(1,10,steps))
                {
                    Write("Invalid input. How many steps do you want to take? (1-10): ");
                    Int32.TryParse(DataValidation.StandardInput(), out steps);
                }
                position += steps;
                if (position > 10)
                {
                    WriteLine("*You slam into the door.*");
                    WriteLine("*Maybe if you could move the house a few steps away...*");
                    WriteLine("That's {0} steps too many, buddy. I may have overestimated your intelligence.", position - 10);
                }
                else if (position == 10)
                {
                    WriteLine("*You walk up the door*");
                }
                else
                {
                    WriteLine("That's it, just {0} more steps.", 10 - position);
                }
            }
            return DoorPuzzle(player);
        }
        private static Player DoorPuzzle(Player player)
        {
            //attributes
            string input;
            int roll1;
            int roll2;

            WriteLine("*You read the text on the door: 'Roll my DICE'*");
            WriteLine("*In a bowl sunk into the door, you can see a chunk of ICE and a short BOARD*");
            WriteLine("\nOkay {0}, so what you want to do here is pick up one of those things and combine it with the other.", player.Name);
            WriteLine(" You can do so by typing the word corresponding to the item in the console one after the other.");
            while (player.ItemInHand != "DICE")
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "ice": //case if player is holding ice
                        if (player.ItemInHand == "ICE")
                        {
                            Interaction.Failure();
                        }
                        else if (player.ItemInHand == "BOARD")
                        {
                            Interaction.DiceCombination(player);
                        }
                        else if (player.ItemInHand == "nothing")
                        {
                            WriteLine("*You pick up the ICE.*");
                            player.ItemInHand = "ICE";
                        }
                        break;
                    case "board":
                        if (player.ItemInHand == "ICE")
                        {
                            Interaction.DiceCombination(player);
                        }
                        else if (player.ItemInHand == "BOARD")
                        {
                            Interaction.Failure();
                        }
                        else if (player.ItemInHand == "nothing")
                        {
                            WriteLine("*You pick up the BOARD.*");
                            player.ItemInHand = "BOARD";
                        }
                        break;
                    case "drop":
                        if (player.ItemInHand == "nothing")
                        {
                            Interaction.Failure();
                        }
                        else
                        {
                            WriteLine("*You dropped the {0}.*", player.ItemInHand);
                            player.ItemInHand = "nothing";
                        }
                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
            WriteLine("*You roll the DICE in the bowl.*");
            roll1 = Player.Dice(1, 7);
            roll2 = Player.Dice(1, 7);
            if ((roll1 + roll2) < player.Difficulty)
            {
                WriteLine("Oof, {0} and {1}, that's rough.", roll1, roll2);
                WriteLine("Sorry, but you're dead. Sorry I don't make the rules.");
                Setup.GameEnd("*Everything goes black.*");
            }
            else if ((roll1 + roll2) >= player.Difficulty)
            {
                WriteLine("Nice, that's {0} and {1}, you did it.", roll1, roll2);
                WriteLine("*You hear a click in the door but it doesn't open. A keyhole reveals itself.*");
            }
            player.ItemInHand = "nothing";

            return DoorChallenge(player, roll1, roll2);
        }
        private static Player DoorChallenge(Player player, int roll1, int roll2)
        {
            //attributes
            string[] names = { "Primus", "Secundus", "Tertius", "Quartus", "Quintus", "Sextus", "Septimus" };
            Dictionary<string, Animal> doorGuards = new Dictionary<string, Animal>();
            string input1;
            string input2;
            string actionChoice;
            bool hasKey = false;

            //creating the animals
            for (int i = 0; i < 7; i++ )
            {
                doorGuards.Add(names[i].ToLower(), new Animal(player.NumList, names[i], (i + 1 == roll1) || (i + 1 == roll2)));
            }

            //explaining the puzzle
            //solution: the animals corresponding to the rolls for the door has the two halves of the key
            WriteLine("Wait, the key was in the lock... Maybe it was...");
            WriteLine("*Seven animals walk up to you.*");
            Write("Their names are ");
            for (int i = 0; i < names.Length - 1; i++)
            {
                Write("{0}, ", names[i]);
            }
            WriteLine("{0}.", names[names.Length - 1]);
            WriteLine("They probably have the key. They came up with some puzzle for you to solve. \nKnowing them, it's definitely random, but there's always a way to figure out the solution.");
            WriteLine("Oh, and it's never Septimus. Just figure out which of the other six have the two parts of the key. \nHmmm, six of them...");

            //interaction layer
            while (!hasKey) //goes as long as the player doesn't have the key
            {
                //pick two names
                WriteLine("Pick the names of the animal(s) you want to interact with.");
                input1 = DataValidation.StandardInput();
                while (!DataValidation.ArrayCheck(names, input1)) 
                {
                    WriteLine("Invalid Input. Enter a name: ");
                    input1 = DataValidation.StandardInput();
                }
                input2 = DataValidation.StandardInput();
                while (!DataValidation.ArrayCheck(names, input2))
                {
                    WriteLine("Invalid Input. Enter a name: ");
                    input2 = DataValidation.StandardInput();
                }

                //pick interaction
                WriteLine("What do you want to do? (OBSERVE, CHECK, or EAT): ");
                actionChoice = DataValidation.StandardInput();
                while (!DataValidation.ArrayCheck(new string[] { "observe", "check", "eat" }, actionChoice))
                {
                    WriteLine("Invalid Input. OBSERVE, CHECK, or EAT: ");
                    actionChoice = DataValidation.StandardInput();
                }

                //do interaction
                switch (actionChoice)
                {
                    case "observe": //observes attributes of selected animals
                        WriteLine("{0} is a {1} {2} animal with {3} legs and {4} eyes.", doorGuards[input1].Name, doorGuards[input1].Size, doorGuards[input1].Color, doorGuards[input1].Legs, doorGuards[input1].Eyes);
                        if (input1 != input2)
                        {
                            WriteLine("{0} is a {1} {2} animal with {3} legs and {4} eyes.", doorGuards[input2].Name, doorGuards[input2].Size, doorGuards[input2].Color, doorGuards[input2].Legs, doorGuards[input2].Eyes);
                        }
                        break;
                    case "check": //checks puzzle solution
                        if (doorGuards[input1].HasKey && doorGuards[input1].HasKey) //correct
                        {
                            Write("*As you go to check {0} ", doorGuards[input1].Name);
                            if (input1 != input2) { Write("and {0} ", doorGuards[input2].Name); }
                            WriteLine("you find two halves of a key.*");
                            WriteLine("Oh hey, you're done, awesome.");
                            WriteLine("*You go to unlock the door.*");
                            hasKey = true;
                        }
                        else //incorrect
                        {
                            WriteLine("*Nothing happens, it seems you were wrong.*");
                        }
                        break;
                    case "eat":
                        WriteLine("Which one? ({0} or {1}): ", input1, input2);
                        actionChoice = DataValidation.StandardInput();
                        while (!DataValidation.ArrayCheck(new string[] { input1, input2 }, actionChoice))
                        {
                            WriteLine("Invalid Input. {0} or {1}: ", input1, input2);
                            actionChoice = DataValidation.StandardInput();
                        }
                        WriteLine("You start eating {0}. ", doorGuards[actionChoice].Name);
                        doorGuards[actionChoice].Bite();
                        break;
                }
            }

            return player;
        }
    }
}
