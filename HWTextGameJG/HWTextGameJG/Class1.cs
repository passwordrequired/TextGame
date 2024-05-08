//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Player Class for Text Game
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
using System.Threading;
namespace HWTextGameJG
{
    internal class Player
    {
        string name;
        int[] numList;
        List<string> foodList;
        int difficulty;
        string[] colors = { "green", "blue", "red", "yellow", "orange", "purple", "black", "white" };
        public Player( string name, int[] numList, List<string> foodList, int difficulty) //default constructor for new saves
        {
            //player creation values
            this.name = name;
            this.numList = numList;
            this.foodList = foodList;
            this.difficulty = difficulty;

            //default values
            IsAntConsumed = false;
            IsAntDefeated = false;
            IsSpiderDefeated = false;
        }
        //constructor for loaded saves
        public Player(string name, string itemInHand, int[] numList, List<string> foodList, int difficulty, bool isAntDefeated, bool isAntConsumed, bool isAntBlack, bool isSpiderDefeated)
        {
            this.name = name;
            ItemInHand = itemInHand;
            this.numList = numList;
            this.foodList = foodList;
            this.difficulty = difficulty;
            IsAntDefeated = isAntDefeated;
            IsAntConsumed = isAntConsumed;
            IsBlackAnt = isAntBlack;
            IsSpiderDefeated = isSpiderDefeated;
        }

        public string Name { get { return name; } }
        public string ItemInHand { get; set; }
        public string Destination {  get; set; }
        public static int Dice(int min, int max)
        {
            //attributes
            Random rand = new Random();

            Thread.Sleep(10);
            return rand.Next(min, max);
        }
        public int[] NumList { get { return numList; } }
        public List<string> FoodList { get { return foodList; } }
        public int Difficulty { get { return difficulty; } }
        public string[] Colors { get { return colors; } }
        public bool IsAntDefeated { get; set; }
        public bool IsAntConsumed { get; set; }
        public bool IsSpiderDefeated { get; set; }
        public bool IsBlackAnt { get; set; }
    }
}
