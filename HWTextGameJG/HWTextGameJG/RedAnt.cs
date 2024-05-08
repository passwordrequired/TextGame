//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Red Ant Class for Text Game
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
    internal class RedAnt : Ant
    {
        private const int skillLevel = 2;
        public RedAnt() : base(skillLevel) { }
        public override bool Attack()
        {
            //attributes
            bool outcome = false;

            //attack method readout
            WriteLine("Normally, ant venom just hurts, but at this size, it could be incredibly dangerous.");
            WriteLine("*The ant lunges towards you.*");

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
                WriteLine("*You try to dodge the initial attack, but you slip up and land right in the ant's gnashing mandibles.*");
                WriteLine("Aw man, what a shame. Oh well.");
            }

            //end
            return outcome;
        }
    }
}
