//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Spider Class for Text Game
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
    internal class Spider
    {
        //attributes
        private int skillLevel;

        //constructor
        public Spider(int skillLevel)
        {
            //attributes
            this.skillLevel = skillLevel;

            //spider description
            WriteLine("You notice a giant SPIDER blocking the way.");
            WriteLine("Normally spider venom isn't enough to kill a grown adult. This is a giant spider. It probably doesn't need the venom anyway.");
            WriteLine("*The spider waits for you to approach its web.*");
        }
        private bool isAttackSuccessful()
        {
            return skillLevel <= Player.Dice(1, 7);
        }
        public bool Attack()
        {
            //attributes
            bool outcome = false;

            //see if attack is successful
            outcome = isAttackSuccessful();

            //print outcome
            if (outcome)
            {
                WriteLine("*You manage to enact a precision strike on the spider, knocking it off its web, and then finishing it off with a followup attack.*");
                WriteLine("Nice job. I guess you can go into the last room now.");
            }
            else
            {
                WriteLine("*You try to attack, but you land right in the spider's web.*");
                WriteLine("Don't expect me to help. I'm leaving. I'd give it... uh... probably about a week. It's very patient.");
            }

            //end
            return outcome;
        }
    }
}
