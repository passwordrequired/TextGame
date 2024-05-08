//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Interaction Class for Text Game
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
    internal static class Interaction
    {
        public static Player DiceCombination(Player player)
        {
            WriteLine("*You combined the BOARD and the ICE somehow. How does that work?*");
            WriteLine("*A BOAR rushes away from you into the bushes, and a pair of {0} DICE rest in your hands*", player.Colors[Player.Dice(0,player.Colors.Length)]);
            player.ItemInHand = "DICE";
            return player;
        }
        public static Player RoeCombination(Player player)
        {
            WriteLine("*You now have a BOWL of ROE in your hands.*");
            player.ItemInHand = "ROE";
            return player;
        }
        public static void Failure()
        {
            switch (Player.Dice(1,7))
            {
                case 1:
                    WriteLine("That won't work.");
                    break;
                case 2:
                    WriteLine("Maybe try something else.");
                    break;
                case 3:
                    WriteLine("You can't do that.");
                    break;
                case 4:
                    WriteLine("I can hardly imagine that will do anything.");
                    break;
                case 5:
                    WriteLine("Try thinking about it a bit harder.");
                    break;
                case 6:
                    WriteLine("What planet are you from where that makes sense?");
                    break;
            }
        }
        public static void Failure(string message)
        {
            WriteLine(message);
        }
    }
}
