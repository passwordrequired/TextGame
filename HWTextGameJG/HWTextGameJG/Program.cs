//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace HWTextGameJG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //the last creature is a spider that attacks you if you try to enter the final room

            //changes
            //add comments and headers
            //**add 4 creatures to the dungeon
            //  **ant
            //  **black ant (child of ant)
            //  **red ant (child of ant)
            //  **spider (final room)
            //enemy requirements
            //  abstract attack method
            //  attack skill attribute
            //  isAttackSuccessful method
            //  use base keyword for constructor on child classes
            //  const int attribute skill level
            //  put ants in spider in place
            //  **create a ant then flip a coin to decide whether it becomes red or black ant object
            //interface
            //  **create Iedible interface
            //  **bite method
            //  **isConsumed method (default false)
            //  **add to black ant and the creatures generated for the door puzzle
            //  for animal add numChunks which will determine the number of bites it takes to eat

            //the theme for my game is going to be like old fairy tales, like rumpelstiltskin
            //at the beginning of the game your name gets taken (like stolen) and you need to get it back by doing a favor for the being that took it by infiltrating
            //a strange house by completeing spelling based puzzles

            //each room is going to have a semi-random assortment of objects that can be transformed into the puzzle solution via the magic of adding/removing letters
            //you need to make a rope to get to the second floor, then you need to make a door, a bridge, and a sword to get through the top floor, respectively

            //current solutions
            //  robe, owl -> roe, bowl
            //  plot, roe -> lot, rope
            //  donor, pod -> door, pond
            //  thing, bride -> thin, bridge
            //  postage, word -> potage, sword
            //  words that are related to puzzles will be all caps like THIS

            //things that need to be kept track of:
            //  current state of the words in the room
            //  position
            //  which doors are open
            //  player's name

            //start
            Player player;
            player = Setup.GameStart();

            Yard.DoorApproach(player);

            player.Destination = "foyer";
            Dungeon.RoomSwitch(player);

            //rooms
            //entrance
            //level 1
            //  snowglobe room
            //  model town room
            //  bedroom
            //  farming room
            //  aviary room
            //  haunted room
            //level 2
            //  insect room
            //  fishing room
            //  government office room
            //end
            Read();
        }
    }
}
