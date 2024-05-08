//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Setup Class for Text Game
//# Author: Josh Gray
//# Purpose: IGME 105 Project -- Text Game
//# Date: 4-19-24
//# Modifications: hw5
//##########################################################################

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HWTextGameJG
{
    internal static class Setup
    {
        public static Player GameStart()
        {
            //attributes
            string gameStart;
            string name;
            string location;
            string input;

            //start
            //  game name
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            WriteLine("Welcome to Word Game, the only game ever to have words.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //ask for y input to start
            Write("Enter Y to start: ");
            gameStart = DataValidation.StandardInput();
            //  if y then continue if not then close out
            if (!DataValidation.Input("y",gameStart)) { Setup.GameEnd(); }

            //continue or new game
            location = GetLocation();
            if (Directory.Exists(location))
            {
                //picks a file and loads it
                Write("Would you like to continue a previous save? (Y or N): ");
                input = DataValidation.StandardInput();
                while (!DataValidation.Input("n", input) && !DataValidation.Input("y", input))
                {
                    WriteLine("Invalid Input. Y or N:");
                    input = DataValidation.StandardInput();
                }
                if (input == "y") //player wants to load
                {
                    Dungeon.RoomSwitch(Continue(location));
                }
            }

            //  rules
            WriteLine("This is an interactive text game. Words used in puzzles will be all caps like THIS. \nWhen you see a colon: you need to type something in the console.");
            WriteLine("During all scenarios where you can make an input, you can also input 'Q' to quit. \nYou can save your progress at certain points of the game.");
            //  use tryparse to get user's name
            Write("Please enter your name: ");
            name = DataValidation.StandardInput();
            while (!DataValidation.Input(name))
            {
                Write("Invalid input. Please enter your name: ");
                name = DataValidation.StandardInput();
            }
            WriteLine("{0} is a great name. I'll take it.", name);

            //assigning values to attributes of the player object
            Player player = new Player(name, NumberListCreation(10, name), FoodListCreation(name), DifficultySetting());
            player.ItemInHand = "nothing";

            return player;
        }
        public static void GameEnd() //base exit, player initiated exit
        {
            Read();
            Environment.Exit(0);
        }
        public static void GameEnd(string reason) //when a player dies
        {
            //attributes
            string input;
            string location = GetLocation();

            WriteLine(reason);
            WriteLine("You Died!");

            if (Directory.Exists(location))
            {
                //load a save?
                Write("Would you like to load a save? (Y/N): ");
                input = DataValidation.StandardInput();
                while (DataValidation.Input("n", input) || DataValidation.Input("y", input))
                {
                    Write("Invalid Input. Y or N: ");
                    input = DataValidation.StandardInput();
                }
                if (DataValidation.Input("y", input))
                {
                    Player player = Load(location);
                    Dungeon.RoomSwitch(player);
                }
            }

            GameEnd();
        }
        public static void GameEnd(string reason, string name) //when the player wins the game
        {
            WriteLine(reason);
            WriteLine("You Win, {0}!", name);
            GameEnd();
        }
        private static int[] NumberListCreation(int length, string name)
        {
            //attributes
            int[] numbers = new int[length];

            //adding a shortcut for testing
            if (name == "j")
            {
                numbers = new int[] { 10,10,10,10,10,10,10,10,10,10 };
                return numbers;
            }

            WriteLine("We need a list of 10 numbers from 10 to 100 from you.");

            for (int i = 0; i < length; i++) //loop to get 10 numbers
            {
                Write("Enter number {0} of 10: ", i + 1);
                Int32.TryParse(DataValidation.StandardInput(), out numbers[i]);
                while (!DataValidation.Input(10, 100, numbers[i])) //check if numbers fit criteria
                {
                    Write("Invalid Input. Enter number {0} of 10: ", i);
                    Int32.TryParse(DataValidation.StandardInput(), out numbers[i]);
                }
            }

            return numbers; //send to main
        }
        private static List<string> FoodListCreation(string name)
        {
            //attributes
            List<string> sodas = new List<string>();
            string addAnother = "y";
            string newSoda;

            //shortcut for quick testing
            if (name == "j")
            {
                sodas.Add("Kaz");
                sodas.Add("Pepsi");
                sodas.Add("Hetap");
                return sodas;
            }

            //explanation
            WriteLine("We need you to enter a list of sodas. You have to give us at least one.");

            while (!DataValidation.Input("n", addAnother)) //loop until list is complete
            {
                Write("Enter soda number {0}: ", sodas.Count + 1);
                newSoda = DataValidation.StandardInput();
                while (!DataValidation.Input(newSoda))
                {
                    Write("Invalid Input. Enter soda number {0}: ", sodas.Count + 1);
                    newSoda = DataValidation.StandardInput();
                }
                sodas.Add(newSoda);
                Write("Do you want to add another? (Y/N): ");
                addAnother = DataValidation.StandardInput();
                while (!DataValidation.Input("y", addAnother)&&!DataValidation.Input("n", addAnother))
                {
                    Write("Do you want to add another? (Y/N): ");
                    addAnother = DataValidation.StandardInput();
                }
            }

            return sodas; //sending sodas to main
        }
        private static int DifficultySetting()
        {
            //attributes
            int difficulty;

            //get difficulty level from user
            Write("Please enter a difficulty level (1-5): ");
            Int32.TryParse(DataValidation.StandardInput(), out difficulty);
            while (!DataValidation.Input(1, 5, difficulty))
            {
                Write("Invalid Input. Please enter a difficulty level (1-5): ");
                Int32.TryParse(DataValidation.StandardInput(), out difficulty);
            }

            return difficulty; //send to main
        }
        private static string GetLocation()
        {
            //attributes
            string[] dir = Environment.CurrentDirectory.Split('\\');
            string location = "";

            //getting txt file location
            for (int i = 0; i < dir.Length - 3; i++)
            {
                location += dir[i] + "\\";
            }
            location += "Saves";

            return location;
        }
        private static Player Continue(string location)
        {
            Player player;
            int file;
            bool fileExists = false;

            Write("Which file would you like to load? (1, 2, or 3): "); //picking a file
            Int32.TryParse(DataValidation.StandardInput(), out file);
            while (!DataValidation.Input(1, 3, file) && !fileExists)
            {
                WriteLine("Invalid Input. 1, 2, or 3:");
                Int32.TryParse(DataValidation.StandardInput(), out file);
                //does file exist
                fileExists = File.Exists(location + String.Format("\\save{0}.txt", file));
                if (!fileExists)
                {
                    WriteLine("There is no data saved to that file.");
                }
            }

            //loads the data
            player = Load(location + String.Format("\\save{0}.txt", file));
            
            //returns loaded player
            return player;
        }
        private static void Save(Player player, string location, int number)
        {
            //attributes
            string fileLocation = location + String.Format("\\save{0}.txt", number);

            //creates directory
            Directory.CreateDirectory(location);

            //destroying previous save and creating new one
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }

            //write and return
            StreamWriter write = File.CreateText(fileLocation);
            write.WriteLine(player.Name);
            write.WriteLine(player.ItemInHand);
            write.WriteLine(player.Destination);
            //write numlist
            for (int i = 0; i < player.NumList.Length; i++)
            {
                write.WriteLine(player.NumList[i]);
            }
            //write foodlist (foodlist length to assist in loading)
            write.WriteLine(player.FoodList.Count());
            for (int i = 0; i < player.FoodList.Count(); i++)
            {
                write.WriteLine(player.FoodList[i]);
            }
            write.WriteLine(player.Difficulty);
            write.WriteLine(player.IsAntDefeated);
            write.WriteLine(player.IsAntConsumed);
            write.WriteLine(player.IsBlackAnt);
            write.WriteLine(player.IsSpiderDefeated);

            //closing file
            write.Close();

            //print message
            WriteLine("Saved data to slot {0}.", number);

        }
        private static Player Load(string location)
        {
            //attributes
            string name;
            string itemInHand;
            string destination;
            int[] numList = new int[10];
            int listLength;
            List<string> foodList = new List<string>();
            int difficulty;
            bool isAntDefeated;
            bool isAntConsumed;
            bool isAntBlack;
            bool isSpiderDefeated;

            //load from location
            StreamReader read = new StreamReader(location);

            //loading all values
            name = read.ReadLine();
            itemInHand = read.ReadLine();
            destination = read.ReadLine();
            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = Int32.Parse(read.ReadLine());
            }
            listLength = Int32.Parse(read.ReadLine());
            for (int i = 0;i < listLength; i++)
            {
                foodList.Add(read.ReadLine());
            }
            difficulty = Int32.Parse(read.ReadLine());
            isAntDefeated = bool.Parse(read.ReadLine());
            isAntConsumed = bool.Parse(read.ReadLine());
            isAntBlack = bool.Parse(read.ReadLine());
            isSpiderDefeated = bool.Parse(read.ReadLine());

            //closing
            read.Close();

            //creating new player object
            return new Player(name, itemInHand, numList, foodList, difficulty, isAntDefeated, isAntConsumed, isAntBlack, isSpiderDefeated);
        }
        public static void SavePoint(Player player)
        {
            //attributes
            string location = GetLocation();
            int file;
            string input;

            //savepoint options
            Write("What would you like to do? (SAVE, QUIT, NEITHER, or BOTH): ");
            input = DataValidation.StandardInput();
            while (!DataValidation.ArrayCheck(new string[] { "save", "quit", "both", "neither"}, input))
            {
                Write("Invalid Input. SAVE, QUIT, NEITHER, or BOTH: ");
                input = DataValidation.StandardInput();
            }

            //perform requested action
            switch (input)
            {
                case "save": //saves the game
                    Write("Which slot would you like to save to? (1-3): ");
                    Int32.TryParse(DataValidation.StandardInput(), out file);
                    while (!DataValidation.Input(1, 3, file))
                    {
                        Write("Invalid Input. 1-3: ");
                        Int32.TryParse(DataValidation.StandardInput(), out file);
                    }
                    Save(player, location, file);
                    break;
                case "quit": //quits (no save)
                    GameEnd();
                    break;
                case "both": //saves, then quits
                    Write("Which slot would you like to save to? (1-3): ");
                    Int32.TryParse(DataValidation.StandardInput(), out file);
                    while (!DataValidation.Input(1, 3, file))
                    {
                        Write("Invalid Input. 1-3: ");
                        Int32.TryParse(DataValidation.StandardInput(), out file);
                    }
                    Save(player, location, file);
                    GameEnd();
                    break;
            }

            return;
        }

    }
}
