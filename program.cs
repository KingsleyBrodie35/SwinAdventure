using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class program
    {
        private CommandProccessor _cmds;
        private Player _p;
        private Item _gem;
        private Item _pc;
        private Item _torch;
        private Bag _bag;

        // Main Method
        static public void Main(String[] args)
        {
            CommandProccessor _cmds = new CommandProccessor();
            //Create player object
            string name = "";
            do
            {
                Console.Write("What is your name traveler?: ");
                name = Console.ReadLine();
            } while (name == "");
            string desc = "";
            do
            {
                Console.Write("Welcome {0}, What is your story?: ", name);
                desc = Console.ReadLine();
            } while (name == "");
            Player _p = new Player(name, desc);
            //Add itms to player inv
            Inventory playerInv = _p.Inventory;
            Item _gem = new Item(new string[] { "gem" }, "gem", "a shiny gem", true);
            Item _pc = new Item(new string[] { "computer", "pc", "laptop" }, "computer", "an old laptop, it seems to be out of charge", true);
            playerInv.Put(_gem);
            playerInv.Put(_pc);
            //Add bag to player inv
            Bag _bag = new Bag(new string[] {"bag"}, "bag", "a small red backpack");
            playerInv.Put(_bag);
            //Add item to bag
            Inventory bagInv = _bag.Inventory;
            Item _torch = new Item(new string[] {"torch", "flashlight"}, "torch", "a flashlight, this will come in handy", true);
            bagInv.Put(_torch);
            //Add paths to player Location
            Paths playerPaths = _p.Location.Paths;
            List<Path> pPaths = playerPaths.PathList;
            playerPaths.Put(new Path(new string[] { "north", "n", "up" }, "hallway", "you walk down the hallway"));
            playerPaths.Put(new Path(new string[] { "east", "e", "left" }, "door", "you go through a door to the left"));
            pPaths[0].Destination = new Location(new string[] { "kitchen"}, "kitchen", "seems like a commercial kitchen with professional chefs");
            pPaths[1].Destination = new Location(new string[] { "dining room" }, "dining room", "a long dining table with old timey chairs and bookcases lining the walls");
            //Introduction
            Location playerLoc = _p.Location;
            Console.WriteLine("Welcome to Swin Adventure!\nYou have arrived in the {0}", playerLoc.Name);
            Console.WriteLine("Type \"help\" for info");
            //Loop reading commands
            bool quit = false;
            do
            {
                Console.Write("Command -> ");
                string input = Console.ReadLine();
                if (input != "" && input != "help" && input != "Help" && input != "quit")
                {
                    string[] cmd = input.Split(" ");
                    Console.WriteLine(_cmds.Process(_p, cmd));
                }
                if (input == "help" || input == "Help")
                {
                    Console.WriteLine("look: look at current location");
                    Console.WriteLine("look at me: look at own inventory");
                    Console.WriteLine("look at inventory: look at own inventory");
                    Console.WriteLine("look at \"item\" in inventory: look at the desired item in inventory");
                    Console.WriteLine("look at bag: look at bag in inventory");
                    Console.WriteLine("look at \"item\" in bag: look at an item in bag");
                    Console.WriteLine("move direction: move north, east, south, west");
                    Console.WriteLine("quit: quit's program");
                }
                if (input == "quit")
                {
                    Console.Write("Thanks for playing");
                    quit = true;
                }
            } while (quit == false);
        }
    }
}
