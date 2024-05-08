//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Black Ant Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HWTextGameJG
{
    internal class BlackAnt : Ant , IEdible
    {
        //attributes
        private const int skillLevel = 1;
        private bool isConsumed = false;
        public BlackAnt(bool isConsumed) : base(skillLevel)
        {
            //attributes
            this.isConsumed = isConsumed;
        }
        //edibility stuff
        public bool IsConsumed()
        {
            return isConsumed;
        }
        public void Bite()
        {
            //attributes
            int[] position = new int[2];
            string input;

            //dialogue for consumption
            if (isConsumed)
            {
                WriteLine("There aren't even bones left... ");
            }
            else
            {
                WriteLine("*You eat the ant whole.*");
                WriteLine("WHAT? That was awesome... How did you do that?");
                Write("Wait, why did you do that?: ");
                //sets cursor position
                position[0] = CursorLeft; 
                position[1] = CursorTop;
                //this is a funny joke
                input = ReadLine();
                CursorLeft = position[0];
                CursorTop = position[1];
                foreach (char c in input)
                {
                    Write(" ");
                }
                WriteLine(" \nNever mind I don't want to know.");

                //sets whether the ant is consumed
                isConsumed = true;
            }
        }
        public override bool Attack()
        {
            //attributes
            bool outcome = false;

            //attack method readout
            WriteLine("At its normal size an ant would never be able to hurt you (well, this kind of ant), but I guess you could probably figure that out.");
            WriteLine("*The ant flexes its mandibles and strides through the room towards you.*");

            //see if attack is successful
            outcome = isAttackSuccessful();

            //print outcome
            if (outcome)
            {
                WriteLine("*You dodge and strike a mighty blow in return.*");
                WriteLine("It probably won't be able to walk that one off.");
            }
            else
            {
                WriteLine("*You try to dodge the initial attack, but you slip up and land right in the ant's mouth.*");
                WriteLine("Aw man, what a shame. Oh well.");
            }

            //end
            return outcome;
        }
    }
}
