using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// !!DISCLAIMER!! ALL ASCII ART USED IN THIS GAME WAS TAKEN FROM asciiart.eu, I DO NOT OWN ANY OF THESE ARTWORKS !! DISCLAIMER !!
namespace J1P2_PRO_Prototype1_Levi_Feunekes

{
    internal class Encounter
    {
        // this static random will generate a random number when it is necessary
        Random rnd = new Random();
        // This is a constructor for the first encounter
        public void FirstEncounter(Player _player)
        {
            slowPrint("You encounter a ghostly substance, is it... ectoplasm.\nYou hear a loud BANG from one of the doors." +
            "\nIn front of you is an evil spirit!\nPress anything to continue", 40);
            Console.ReadKey();
            Console.Clear();
            // This reads the text in the .txt file, then it writes the content of the .txt file 
            string Spirit = File.ReadAllText("Spirit.txt");
            Console.Write(Spirit);
            slowPrint("\n\n\nIt says: ");
            // This changes the color of the text to red
            Console.ForegroundColor = ConsoleColor.DarkRed;
            slowPrint("COMING HERE IS THE WORST MISTAKE OF YOUR PUNY LITTLE LIFE!", 100);
            Console.ReadKey();
            // This changes the color of the text to green
            Console.ForegroundColor = ConsoleColor.Green;
            // This links the Fighting void to the Evil spirit, you can change the values to add/decrease health and strenght
            Fighting(_player, false, "Evil spirit", 7, 20);
        }
        // This is a constructor for every fight in the game(exept for the first enemy and the boss)
        public void NormalFight(Player _player)
        {
            Console.Clear();
            slowPrint("You come face to face to face with an evil being.");
            Console.ReadKey();
            //these values in "Fighting" don't matter because it's already stated in the Fighting void
            Fighting(_player, true, "", 0, 0);

        }
        // This is a constructor for a bossfight
        public void BossFight(Player _player)
        {
            Console.Clear();
            Console.WriteLine("You feel a powerful energy nearby.\n" +
                "You take a look around and there you see it.\nIt's a massive 3 meter demon...");
            Console.ReadKey();
            string giantDemon = File.ReadAllText("giantDemon.txt");
            string[] Art = giantDemon.Split('1');
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(Art[i]);
                Thread.Sleep(1000);
                Console.Clear();
                i++;
            }   
            while (i < 5);
            _player.hasSeenBoss = true;
            Fighting(_player, false, "GIANT DEMON", 8, 30);
        }
        // This chooses a random enemy that you have to fight.
        public void RandomEncounter(Player _player)
        {
            switch (rnd.Next(0, 1))
            {
                case 0:
                    NormalFight(_player);
                    break;
            }
        }
        // This gives a random enemy a name.
        public string RandomName()
        {
            switch (rnd.Next(0, 12))
            {
                case 0:
                    return "Banshee";
                case 1:
                    return "Spirit";
                case 2:
                    return "Deogen";
                case 3:
                    return "Poltergeist";
                case 4:
                    return "Wraith";
                case 5:
                    return "Revenant";
                case 6:
                    return "Jinn";
                case 7:
                    return "Mare";
                case 8:
                    return "Moroi";
                case 9:
                    return "Phantom";
                case 10:
                    return "Mimic";
                // Alex easter egg
                case 11:
                    return "A hobo named Alex that is acting very hostile";
            }
            // this will never show but its neccesary
            return "placeholder";
        }
        // This will generate the enemys stats, show the GUI, Adds attacks
        public void Fighting(Player, bool random, string name, int strength, int healthPoints)
        {
            string rndName = "";
            int rndStrength = 0;
            int rndHealth = 0;
            // These are the normal enemy's name, health, and strength
            if (random)
            {
                rndName = RandomName();
                rndStrength = rnd.Next(1, 8);
                rndHealth = rnd.Next(1, 15);
            }
            // These are the normal enemy's stats
            else
            {
                rndName = name;
                rndStrength = strength;
                rndHealth = healthPoints;
            }
            // While the enemy's health is above 0 this will show
            while (rndHealth > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                // This writes the name of the enemy 
                Console.WriteLine(rndName);
                Console.ForegroundColor = ConsoleColor.Green;
                // This writes the strenght and the health of the enemy
                Console.WriteLine("Strength = " + rndStrength + "/ Health = " + rndHealth);
                // This is the G U I for the fighting sequence
                Console.WriteLine("||_-_-_-_-_-_-_-_-_-_-_-_-_||");
                Console.WriteLine("||                         ||");
                Console.WriteLine("||   Attack       Defend   ||");
                Console.WriteLine("||          Snack          ||");
                Console.WriteLine("||          Help           ||");
                Console.WriteLine("||                         ||");
                Console.WriteLine("||_-_-_-_-_-_-_-_-_-_-_-_-_||");
                // This writes the total Snacks and total Health of the player
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(_player.name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Snacks: " + _player.snacks + "/ Health = " + _player.healthPoints + "\n");
                string userInput1 = Console.ReadLine();

                // If the input = attack this will continue
                if (userInput1.ToLower() == "attack")
                {
                    // Your attack misses
                    if (rnd.Next(100) < 25)
                    {
                        Console.WriteLine("\n");
                        slowPrint("You tried to hit the " + rndName + " but you failed miserably.");
                        int damage = rndStrength - _player.dmgReduction;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        _player.healthPoints -= damage;
                        slowPrint("While you missed the " + rndName + " hit you with a levitating rat.");
                        slowPrint("You lost " + damage + " health\nPress anything to continue...");
                    }
                    // Your attack hits
                    else
                    {
                        Console.WriteLine("\n");
                        int damage = rndStrength - _player.dmgReduction;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        // This will calculate the total damage you do, it's between 3 to 10
                        int attack = rnd.Next(3, 11);
                        slowPrint("You raise your flashlight up to the " + rndName + "'s sunken in eyes, you stunned him!\nYou clench your hands and take a swing at it!");
                        slowPrint("You deal " + attack + " damage\n");
                        slowPrint("The spirit recovered very fast, almost too fast.\nIt made a loose floorboard levitate and it threw it at you.");
                        slowPrint("You lost " + damage + " health\nPress anything to continue...");

                        Thread.Sleep(1000);

                        // This will remove health from the player
                        _player.healthPoints -= damage;
                        // this will remove health from the enemy
                        rndHealth -= attack;
                    }
                }
                // If the input = defend this will continue
                else if (userInput1.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("\n");
                    // This devides the strenght of the enemy by 4 and it will calculate how much damage you took
                    int damage = (rndStrength / 4) - _player.dmgReduction;
                    // If the damage you take = 0 you will be dealt 0 damage
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    // This will generate a random number from 4 to 10 then it will devide it by 2. This is the damage you do.
                    int attack = rnd.Next(3, 11) / 2;
                    slowPrint("You hide behind the object closest to you in hopes that the " + rndName + " misses you.");
                    slowPrint("The " + rndName + " became so enraged it threw a painting at you, " +
                        "the painting missed you but when you tried to get up you slipped on some ectoplasm.");
                    slowPrint("You lost " + damage + " health\n");
                    slowPrint("You decide to not be a coward, and you peek around the object and you flicker your light really fast at the " + rndName + ".");
                    slowPrint("You deal " + attack + " damage\nPress anything to continue...");
                    // This will remove healthpoints from the player
                    _player.healthPoints -= damage;
                    rndHealth -= attack;
                }
                // If the input = snack this will continue
                else if (userInput1.ToLower() == "snack")
                {
                    //heal
                    Console.WriteLine("\n");
                    // If the players total snacks is < 0 this will continue
                    if (_player.snacks == 0)
                    {
                        slowPrint("You desperatly feel around in your pockets hoping for something that can heal you," +
                            " but all that you feel are empty candy wrappers and your car keys...");
                        slowPrint("The " + rndName + " laughs at your attempt at finding something useful.\nHe makes a potted plant fly up into the air and strike you.");
                        // You take damage because you dont have any snacks it's randomly generated
                        int damage = rnd.Next(1, 11);
                        if (damage <= 0)
                        {
                            damage = 0;
                        }
                        slowPrint("You lost " + damage + " health!\nPress anything to continue");
                        // This will remove health from the players stats
                        _player.healthPoints -= damage;
                    }
                    // If the player has > 0 snacks this will continue
                    else
                    {
                        slowPrint("You reach into your pockets and pull out a full sized candy bar!\n" +
                            "Even though it's melted you still devour it like you haven't eaten in 5 days!\n");

                        // This will remove one snack from the player
                        _player.snacks--;
                        // You take damage 
                        int damage = rnd.Next(1, 6);
                        // You get 10 hp 
                        int gainHp = 10;

                        slowPrint("By some miracle you gain " + gainHp + " health!");
                        // This adds health to the player's stats
                        _player.healthPoints += gainHp;
                        slowPrint("While you were busy eating the " + rndName + " threw some ectoplasm at you");
                        // If the damage you took = 0 You take 0 damage
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        slowPrint("You lost " + damage + " health!\tAnd you have " + _player.snacks + " snacks remaining\nPress anything to continue...");
                        // This will remove health from the players stats
                        _player.healthPoints -= damage;
                    }
                }
                // If the input = help this will continue
                else if (userInput1.ToLower() == "help")
                {
                    Console.Clear();
                    // This will read the .txt file and write the content of it
                    string help = File.ReadAllText("attackList.txt");
                    Console.Write(help);
                }
                // If the input doesn't match any of the previous inputs, this will continue
                else
                {
                    Console.Clear();
                    slowPrint("I'm just a robot, I don't understand this information\nPress anything to continue...");

                }
                // if the current player's health is below zero this will continue
                if (_player.healthPoints <= 0)
                {
                    //Death part :((((
                    Console.Clear();
                    // "n" means the name of the enemy
                    slowPrint("As the " + rndName + " stands menacingly over your defeated body it let's out a small chuckle.\n" +
                        "The " + rndName + " hits you violently with a floorboard and you black out.\n\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string gameOverTxt = File.ReadAllText("gameOver.txt");
                    Console.Write(gameOverTxt);
                    slowPrint("\n\n\nYou have been slain, press F to pay respects");
                    Console.ReadKey();
                    // System enviroment exit will exit the program
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            // If the enemy's health is < = 0 This will show
            Console.Clear();
            slowPrint("While the " + rndName + " gets sucked into the ground it yells out:");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Death message for killing the final boss
            if (_player.hasSeenBoss == true)
            {
                slowPrint("You.. How... I was unbeatable, you g- got me.\nMy family will be distraught... my kids.. MY KIDS!", 100);
            }
            else
            // Random death messages for normal enemies
            {
                switch (rnd.Next(1, 6))
                {
                    case 1:
                        slowPrint("NOOOOOOOO, AHHHHHHH, I'M BEING DRAGGED BACK INTO HELL", 100);
                        break;
                    case 2:
                        slowPrint("Yowzers, you really defeated me... never thought it would've ended this way", 100);
                        break;
                    case 3:
                        slowPrint("YOU WILL PAY FOR THISSSSSSSSS", 100);
                        break;
                    case 4:
                        slowPrint("HELPPP NOOOOO WHYYYY PLEAASSEEE WHYYYYYYYY", 100);
                        break;
                    case 5:
                        slowPrint("*roblox oof sound*", 100);
                        break;
                }
            }
            // The random number that has been generated decides the death message
            Console.ForegroundColor = ConsoleColor.Green;
            slowPrint("Press anything to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        // This void makes the text appear letter by letter
        public void slowPrint(string text, int speed = 10)
        {
            // For each letter in what you wrote, the foreach loop will add a 10 tick delay
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
}
