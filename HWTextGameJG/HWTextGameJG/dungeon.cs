//Header
//git: https://kgcoe-git.rit.edu/jdg8523/igme105-pe-jg
//##########################################################################
//# Program Name: Dungeon Class for Text Game
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
    internal static class Dungeon
    {
        public static Player RoomSwitch(Player player)
        {
            //save point
            Setup.SavePoint(player);

            while (true)
            {
                switch (player.Destination)
                {
                    case "foyer":
                        Foyer(player);
                        break;
                    case "snowglobe":
                        Snowglobe(player);
                        break;
                    case "model town":
                        ModelTown(player);
                        break;
                    case "bedroom":
                        Bedroom(player);
                        break;
                    case "farm":
                        Farm(player);
                        break;
                    case "aviary":
                        Aviary(player);
                        break;
                    case "haunted house":
                        HauntedHouse(player);
                        break;
                    case "anthill":
                        player.ItemInHand = "nothing";
                        Anthill(player);
                        break;
                    case "river":
                        player.ItemInHand = "nothing";
                        River(player);
                        break;
                    case "office":
                        player.ItemInHand = "nothing";
                        Office(player);
                        break;
                }
            }
        }
        private static Player Snowglobe(Player player)
        {
            //attributes
            string input;

            WriteLine("-- F1 Snowglobe --");
            WriteLine("*As you open the door, you are met with a faceful of snow, a wind blowing from the room. The snow doesn't seems to enter the hall, and it's not cold either.*");
            WriteLine("*A mechanical snow OWL sits in the corner of the room, hooting at regular intervals. Or at least, you think it's mechanical. The floor is covered in snow.*");
            WriteLine("*A doll-size house sits in the middle of the room, with figures of people playing and working in the snow. The model TREES that litter the room are not to scale.*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    case "owl":
                        if (player.ItemInHand == "robe")
                        {
                            player = Interaction.RoeCombination(player);
                        }
                        else if (player.ItemInHand == "nothing")
                        {
                            WriteLine("You pick up the OWL.");
                            player.ItemInHand = "owl";
                        }
                        else
                        {
                            Interaction.Failure();
                        }
                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Foyer(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Foyer--");
            WriteLine("*You're in a dusty creaky hall. There are 8 doors, including the one you just came through. The signs on each door read:*");
            WriteLine("*SNOWGLOBE, MODEL TOWN, BEDROOM, FARM, AVIARY, HAUNTED HOUSE. There's a HOLE in the ceiling with a hook on the other side.*");
            WriteLine("*There is a poem on the ceiling written next to the hole:*");
            WriteLine("*'Because of his lack of ROPE, the hunter is cold from the blizzard. Warm him, and he'll gift you the exquisite caviar you can use with your criminal comrades to anger his neighbors.'*");
            WriteLine("*There is no light coming from under any of the doors, but there are some unidentifiable noises.*");
            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "snowglobe":
                        player.Destination = "snowglobe";
                        return player;
                    case "model town":
                        player.Destination = "model town";
                        return player;
                    case "bedroom":
                        player.Destination = "bedroom";
                        return player;
                    case "farm":
                        player.Destination = "farm";
                        return player;
                    case "aviary":
                        player.Destination = "aviary";
                        return player;
                    case "haunted house":
                        player.Destination = "haunted house";
                        return player;
                    case "hole":
                        if (player.ItemInHand == "roe") //hint for the player that they're on the right track
                        {
                            Interaction.Failure("You have a bowl of tiny slimy orbs. That won't get you up there, but caviar is a type of ROE...");
                        }
                        else if (player.ItemInHand == "rope") //advance to the next area
                        {
                            WriteLine("You manage to loop the rope over the hook, and climb though the hole in the ceiling.");
                            player.Destination = "anthill";
                            return player;
                        }
                        else
                        {
                            Interaction.Failure();
                        }
                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player ModelTown(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Model Town--");
            WriteLine("*As you walk through the door, the faint sounds of model TRAINS running along their tracks becomes apparent.*");
            WriteLine("*You can see a large model city spanning the floor, with cars and citizens moving along tracks cleverly hidden in the inches-wide streets.*");
            WriteLine("*A large BILLBOARD sits on top of one of the buildings, with a crossed-out image of a lizard-like creature on it. Maybe if it was your size it would be a threat?*");
            WriteLine("*It must be telling you not to touch, but you have no intention of obeying if you see something interesting.*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Bedroom(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Bedroom--");
            WriteLine("*When you open the door, you don't initially see anything that would mark this as a bedroom. In fact, you don't see anything in it at all.*");
            WriteLine("*However, when you look to the ceiling, you see all the usual furniture: BED, nightstand, dresser, and even an upside down coat hanger with a nightcap and ROBE hanging precariously from it.*");
            WriteLine("How could anyone sleep like this?");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    case "robe":

                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Farm(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Farm--");
            WriteLine("*As you walk into the room, you see one wall with a very convincing barn wall facade, but the illusion is quickly broken as you see the flaking 'pasture' wallpaper.*");
            WriteLine("*The floor is covered in what feels like natural, real GRASS, seemingly kept healthy by the harsh lights in the ceiling.*");
            WriteLine("*In the middle of the room is a cheap and dirty looking plastic lawn CHAIR and a small cooler with a few (empty) bottles sticking out of the ice.*");

            //player entered sodas
            Write("There are {0} bottles, and you can read the labels: ", player.FoodList.Count);
            for (int i = 0; i < 2; i++) //prints 2 sodas
            {
                Write("{0}, ", player.FoodList[Player.Dice(1, player.FoodList.Count)]);
            }
            WriteLine("and {0}.", player.FoodList[Player.Dice(1, player.FoodList.Count)]);

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Aviary(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Aviary--");
            WriteLine("*The sounds of slowly deteriorating speakers playing BIRD noises greet you as you enter the room. What seems like at least thirty mechanical birds sit on bars hanging rigidly from the ceiling.*");
            WriteLine("*Each bird has its own speaker, with TAGS on each pedestal glowingly describing the accuracy of their badly compressed audio and unsettlingly stiff movements.*");
            WriteLine("*One bird, a parrot spouting obscenities, carries a deformed action figure in its mouth. When you inspect it, you think it looks like a PIRATE. Maybe that was supposed to be its master?*");
            WriteLine("*The walls are painted to look like a tropical jungle, but the paint is in the state that the exterior of the house would suggest.*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player HauntedHouse(Player player)
        {
            //attributes
            string input;

            WriteLine("--F1 Haunted House--");
            WriteLine("*As you open the door, it collides with a piece of furniture that continued to swing lazily through the air as you maneuvered through the barely-wide-enough gap in the door.*");
            WriteLine("*There's plenty more similar furniture suspended, DRAWERS open, unmoving in the air. You can't tell how they did that. If it was a magnet, that would probably be really dangerous, right?*");
            WriteLine("*A theremin floats in the air, seemingly playing itself to play ghost noises, although it takes away from the ambiance to have the source of the NOISE visible.*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "foyer":
                        player.Destination = "foyer";
                        return player;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Anthill(Player player)
        {
            //attributes
            string input;
            Ant ant;

            //save point
            Setup.SavePoint(player);

            WriteLine("--F2 Anthill--");
            WriteLine("*The sight of the giant ants shock you as you make your way into the room. They hustle, unbothered by your presence, through giant holes in the walls.*");
            WriteLine("*It doesn't seem like you could fit in one, so don't bother trying.*");
            WriteLine("*There is a chalk outline of a door on the far wall, with an inscription on it:*");
            WriteLine("*'The deceased DOOR, might perhaps have been saved with an infusion. I hear the clinic's heroes might need to evacuate their spaceship.'*");

            //ant encounter
            if (!(player.IsAntConsumed || player.IsAntDefeated)) 
            { 
                WriteLine("*A new ANT comes out of one of the holes in the wall and actually stops to look at you. The giant creature's size is uncanny.*");
                player.IsBlackAnt = Player.Dice(1, 3) == 2; //sets flag for loads
            }
            if (!player.IsBlackAnt)
            {
                ant = new RedAnt();
                if (!(player.IsAntConsumed || player.IsAntDefeated)) { WriteLine("*The ANT is red, indicating its burning venom. Maybe leave it alone.*"); }
            }
            else
            {
                ant = new BlackAnt(player.IsAntConsumed);
                if (!(player.IsAntConsumed || player.IsAntDefeated)) { WriteLine("*The ANT has a black exoskeleton like the others, but it's a different shape. Maybe it's a soldier or something?*"); }
            }

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "drawing":
                        player.Destination = "river";
                        return player;
                    case "ant":
                        player = AntInteraction(player, ant);
                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player River(Player player)
        {
            //attributes
            string input;

            WriteLine("--F2 River--");
            WriteLine("*The large room has a stunning water feature prominently displayed at its center. An artificial river spans the width of the room, preventing access to the other side.*");
            WriteLine("*On the other side of the room, you can see a bathroom door. Don't worry, it's all-gender. You can see a brass plaque with some text on it next to the bathroom sign:*");
            WriteLine("*'To BRIDGE this gap, you need one who will accept any, no, or some, who will be left skinny after marrying a fine woman.'*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "bathroom":
                        player.Destination = "office";
                        return player;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player Office(Player player)
        {
            //attributes
            string input;

            //spider encounter
            if (!player.IsSpiderDefeated)
            {
                Spider spider = new Spider(player.Difficulty);
                if (!spider.Attack())
                {
                    Setup.GameEnd("*You were left there for what seemed like forever. At least it was comfortable being wrapped in webs.*");
                }
            }

            //save point
            Setup.SavePoint(player);

            WriteLine("--F2 Office--");
            WriteLine("*The room is relentlessly drab, designed after a poorly lit, low-level government bureaucrat's office. Several filing cabinets are lined up with a single paper FILE on top.*");
            WriteLine("*In between the cabinets and the desk is a BOX with lots of different papers spilling out of it. A few sheets of POSTAGE stamps are slid between the box and the filing cabinet.*");
            WriteLine("*On the desk, a computer is plugged into a web. A literal spider WEB. Maybe that's the exit? The computer has a text document open WORD document, with the following written in it:*");
            WriteLine("*'A great foe slain by SWORD, yet its lair still stands, and the weapon lost. Maybe if it were mailed a poem written in letters small and soft, it would return.'*");

            while (true)
            {
                input = DataValidation.StandardInput(player);
                switch (input)
                {
                    case "web":
                        Setup.GameEnd("You got you name back!", player.Name);
                        break;
                    case "word":
                        break;
                    case "postage":
                        break;
                    default:
                        Interaction.Failure();
                        break;
                }
            }
        }
        private static Player AntInteraction(Player player, Ant ant)
        {
            //attributes
            string input;

            //pick an action to use on the ant
            WriteLine("What do you want to do with it? (GRAB, FIGHT, or EAT): ");
            input = ReadLine().Trim().ToLower();

            switch (input)
            {
                case "grab": //if you try to grab the ant
                    if (player.IsAntConsumed) //nothing happens if you ate it
                    {
                        BlackAnt blackAnt = (BlackAnt)ant;
                        blackAnt.Bite();
                        Interaction.Failure("There's nothing to pick up.");
                    }
                    else if (player.IsAntDefeated) //you can pick it up if you beat it
                    {
                        if (player.ItemInHand == "nothing")
                        {
                            player.ItemInHand = "ant";
                        }
                        else
                        {
                            Interaction.Failure();
                        }
                    }
                    else //if you haven't beat it, it attacks you
                    {
                        
                        WriteLine("It's giant why would you think that would work?");
                        WriteLine("Now it's coming for you. Have fun!");
                        if (!ant.Attack())
                        {
                            Setup.GameEnd("*You got turned into pet food.*");
                        }
                        else
                        {
                            player.IsAntDefeated = true;
                        }
                    }
                    break;
                case "fight": //if you try to fight the ant
                    if (player.IsAntConsumed) //nothing happens if you ate it
                    {
                        Interaction.Failure("There's nothing left to fight.");
                    }
                    else if (player.IsAntDefeated) //nothing happens if you beat it
                    {
                        Interaction.Failure();
                    }
                    else //if you haven't beat it, it attacks you
                    {
                        if (!ant.Attack())
                        {
                            Setup.GameEnd("*You got turned into pet food.*");
                        }
                        else
                        {
                            player.IsAntDefeated = true;
                        }
                    }
                    break;
                case "eat": //if you try to eat it it works if its a black ant 
                    try
                    {
                        BlackAnt blackAnt = (BlackAnt)ant;
                        blackAnt.Bite();
                        player.IsAntConsumed = true; //flag for loading saves
                    }
                    catch //but if its a red ant you have to fight it
                    {
                        if (player.IsAntDefeated) //unless you already beat it
                        {
                            Interaction.Failure();
                        }
                        else
                        {
                            WriteLine("*It doesn't seem amused.*");
                            if (!ant.Attack())
                            {
                                Setup.GameEnd("*You got turned into pet food.*");
                            }
                            else
                            {
                                player.IsAntDefeated = true;
                            }
                        }
                    }
                    break;
                default:
                    Interaction.Failure();
                    break;
            }

            //return to anthill
            return player;
        }
    }
}
