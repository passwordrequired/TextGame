//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Ant Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HWTextGameJG
{
    internal abstract class Ant
    {
        private int skillLevel;
        public Ant(int skillLevel)
        {
            this.skillLevel = skillLevel;
        }
        public abstract bool Attack();
        protected bool isAttackSuccessful()
        {
            return skillLevel <= Player.Dice(1, 7);
        }
    }
}
