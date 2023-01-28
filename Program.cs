using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Runtime.CompilerServices;
using System;
using J1P2_PRO_Prototype2_Levi_Feunekes;
using System.Collections.Concurrent;

namespace J1P2_PRO_Prototype1_Levi_Feunekes
{
    // !! DISCLAIMER !! ALL ASCII ART USED IN THIS GAME WAS TAKEN FROM asciiart.eu, I DO NOT OWN ANY OF THESE ARTWORKS !! DISCLAIMER !!
    // void Q(rnd) means quesion point 1 or 2, 3, 4 etc

    internal class Program
    {
        // Creates a new item for the currentPlayer class, this will link this Program with the class. 
        public Player currentPlayer = new Player();
        public Encounter encounter = new Encounter();
        public Inventory workBench = new Inventory();
        public bool mainLoop = true;
        // Generates a random number
        Random rnd = new Random();

        // This is the main method, this will tell the program where to start.
        static void Main(string[] args)
        {
            Program p = new Program();
            p.prologue();
            p.cutScene();
            p.Q1();
        }

        #region start
        /// <summary>
        /// The prologue means, backstory and character design.
        /// </summary>
        void prologue()
        {
            // Console.color means that the text will change color, by the specified color.
            Console.ForegroundColor = ConsoleColor.Green;
            // Slow print is the name of the method that types every character letter by letter
            SlowPrint("Who are you?");
            // currentPlayer is a link to the Player class, the console.readLine here is used for the userInput, this will assign the player a name
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            // if the player does not enter a name it will automatically be Rafael (This is a easter egg.)
            if (currentPlayer.name == "")
            {
                // \n will place a blank line after the text.
                SlowPrint("Greetings Rafael\n");
            }
            else
            {
                SlowPrint("Greetings " + currentPlayer.name + "\n");
            }
            // Thread.sleep adds a delay in between code.
            Thread.Sleep(1000);
            // The ,30 after some text, specifies the time in between eacht letter being printed 
            SlowPrint("You’re just another broke college kid, living off of ramen and peanut butter jelly sandwiches.", 30);
            Thread.Sleep(1000);
            SlowPrint("After your great aunt passes, you inherit her disheveled mansion in the haunted hills.", 30);
            Thread.Sleep(1000);
            SlowPrint("Haunted hills?? How scary can it be, you think to yourself.", 30);
            Thread.Sleep(1000);
            SlowPrint("After some time thinking about what you should do, you decide to sell it.", 30);
            Thread.Sleep(1000);
            SlowPrint("But you need to go to the mansion, to get a sense for how much you get to sell it.", 30);
            Thread.Sleep(1000);
            SlowPrint("This is your shot to finally get out of some debt.\n", 30);
            Thread.Sleep(1000);
            SlowPrint("Press anything to continue", 30);
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// This method is for showing the cutscene.
        /// </summary>
        void cutScene()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SlowPrint("You decide not to fly, but drive to haunted hills in your old SV21 Camry." +
                "\nIt’s a good 12 hours of driving, but you're happy you can finally get a break from the busy city." +
                "\n“You have arrived at your destination” says the gps, the tiredness has really set in, and you decide to start work in the morning." +
                "\nBut first you have to find a way inside the mansion.\nPress anything to continue...");
            Console.ReadKey();
            // This string will read all text in a .txt file
            string cutScene = File.ReadAllText("cutScene.txt");
            // Then the string array will split images if it finds a ","
            string[] Art = cutScene.Split(',');
            // Every time int i is less than 10 the code will repeat once it hits ten it stops.
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                // This will write all the images found in the .txt folder
                Console.WriteLine(Art[i]);
                Thread.Sleep(500);
                Console.Clear();
            }
            Console.WriteLine(Art[10]);
            Thread.Sleep(3000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Art[11]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(currentPlayer.name + ", I'll quickly go over the movement of the game, this will only show one time so read carefully...\nThere are some other types of moves you can do" +
            " but they are pretty straight forward.\nPress anything to continue... ");
            Console.ReadKey();
            Console.Clear();
            string moveLists = File.ReadAllText("moveList.txt");
            Console.Write(moveLists);
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region chapter1
        /// <summary>
        ///  This method spawns the player at the start of the game.
        /// </summary>
        void Q1()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("OBJECTIVE 1. FIND A WAY INTO THE MANSION");
            Console.ForegroundColor = ConsoleColor.Green;
            SlowPrint("You're in an overgrown garden with fences surrounding you.\nBehind you is the gate you just went through to get here.\n\n");

            string userInput = Console.ReadLine();
            // If the user input equals "back" this code will play, userInput.ToLower() means that it negates uppercasing.
            if (userInput.ToLower() == "back")
            {
                Console.Clear();
                // Q2 means that it will send the player to the second question point same goes for all.
                Q2();
            }
            else if (userInput.ToLower() == "forward")
            {
                Console.Clear();
                Q3();
            }
            // If the user inputs the konami code, the user will get god mode
            else if (userInput.ToLower() == "up " + "up " + "down " + "down " + "left " + "right " + "b " + "a")
            {
                Console.Clear();
                SlowPrint("/gamemode c" + currentPlayer.name + "\nPress anything to continue...");
                Console.ReadKey();
                Console.Clear();

                currentPlayer.healthPoints = 999999;
                currentPlayer.snacks = 999999;
                currentPlayer.keys = 999999;
                currentPlayer.potooCollectibles = 999999;
                currentPlayer.playerHasAxe = true;
                Q2();
            }
            // If the user input doesn't match any of the above this code will play
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q1();
            }
        }
        /// <summary>
        /// This method will turn the player around and face the gate
        /// </summary>
        void Q2()
        {
            Console.Clear();
            SlowPrint("Before you stands a tall rusted gate.\nIt looks like it wont hold much longer.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "forward")
            {
                Console.Clear();
                SlowPrint("You went through the gate because you thought it wasn't worth it.\n\n\n");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Red;
                // The first possible ending.
                Console.WriteLine("Ending (1/5) unlocked: Not feeling it.\n\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                // This will exit the program 
                System.Environment.Exit(0);
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                Console.WriteLine("You turned around.");
                Console.ReadKey();
                Console.Clear();
                Q1();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q2();
            }
        }
        /// <summary>
        /// This method will place the player at the center of the garden.
        /// </summary>        
        void Q3()
        {
            Console.Clear();
            SlowPrint("You carefully walk forwards into the garden.\nOn either side of you stand two unkept bushes.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "left")
            {
                Console.Clear();
                Q4();
            }
            else if (userInput.ToLower() == "right")
            {
                Console.Clear();
                Q5();
            }
            else if (userInput.ToLower() == "forward")
            {
                Console.Clear();
                Q6();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                Q1();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q3();
            }
        }
        /// <summary>
        /// This method is for all avaiable options at the left bush in the garden.
        /// </summary>
        void Q4()
        {
            Console.Clear();
            SlowPrint("You turn to the left\nYou see a shiny looking object.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "investigate" && currentPlayer.potooCollectibles == 0)
            {
                Console.Clear();
                SlowPrint("You found a wierd little golden statue of a bird... what could it represent?");
                // Add potoo collectible to inventory.
                currentPlayer.potooCollectibles++;
                Console.WriteLine("You currently have " + currentPlayer.potooCollectibles + " Potoo figurine(s)");
                Console.ReadKey();
                Q3();
            }
            else if (userInput.ToLower() == "investigate")
            {
                Console.Clear();
                SlowPrint("You found a small piece of metal it's useless.");
                Console.ReadKey();
                Q3();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You decide to walk back to the path, and ignore THE OBVIOUS SHINING OBJECT!!!");
                Console.ReadKey();
                Q3();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q4();
            }
        }
        /// <summary>
        /// This method is for all available options at the right bush in the garden.
        /// </summary>
        void Q5()
        {
            Console.Clear();
            SlowPrint("You turn to the right, and in the bush is a little bird nest.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "investigate")
            {
                Console.Clear();
                SlowPrint("it's a birds nest!\n");
                string userInput2 = Console.ReadLine();
                // if the player hasn't seen the door the key is not there 
                if (userInput2.ToLower() == "investigate" && currentPlayer.seenDoor == false)
                {
                    Console.Clear();
                    SlowPrint("It's an empty nest with a couple of loose feathers, it looks like the bird just left.");
                    Console.ReadKey();
                    Q5();
                }
                // if the player has seen the door, the key will apear 
                else if (userInput2.ToLower() == "investigate" && currentPlayer.seenDoor == true && currentPlayer.keys == 0)
                {
                    Console.Clear();
                    SlowPrint("Shhhht be quiet, the bird returned.\nWhile you try to quietly get closer the bird notices you and gets scared.\nWhich results in it getting" +
                        " scared and flying away.\nHey look!! it left a key behind, it must've just found it.");
                    Console.WriteLine("You got a key!\nPress anything to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    string key = File.ReadAllText("keyCollected.txt");
                    Console.WriteLine(key);
                    Thread.Sleep(3000);
                    Console.Clear();
                    currentPlayer.keys++;
                    currentPlayer.seenDoor = false;
                    Q5();
                }
                // if the player has the key the nest will be empty and no key will be given
                else if (userInput2.ToLower() == "investigate" && currentPlayer.seenDoor == true && currentPlayer.keys == 1)
                {
                    SlowPrint("There's nothing left for you to collect, so you turn back to the path.");
                    Console.ReadKey();
                    Q3();
                }
                else if (userInput.ToLower() == "back")
                {
                    Console.Clear();
                    SlowPrint("You decide to walk back to the path leaving the birds nest behind");
                    Console.ReadKey();
                    Q3();
                }
                else
                {
                    SlowPrint("Im just a robot, I dont understand.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Q5();
                }
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You decide to walk back to the path leaving the birds nest behind");
                Console.ReadKey();
                Q3();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q5();
            }
        }
        /// <summary>
        /// This method will place the player at the entrance of the manor
        /// </summary>
        void Q6()
        {
            Console.Clear();
            SlowPrint("You're at the entrance of the manor.\nAn eerie feeling has risen in your gut.\nOn the right side of the door is a window.");
            string userInput = Console.ReadLine();
            // If the player does not have a key the door will not open.
            if (userInput.ToLower() == "forward" && currentPlayer.keys == 0)
            {
                Console.Clear();
                SlowPrint("You knock on the door to see if anything happens, you feel the rotting moist wood kinda moving with your hands.\nYou try moving the door" +
                    " but it wont budge, you probably need a key.");
                SlowPrint("You hear something rustling in the bushes...");
                Console.ReadKey();
                currentPlayer.seenDoor = true;
                Q6();
            }
            // If the player does have a key the door will open.
            else if (userInput.ToLower() == "forward" && currentPlayer.keys >= 1)
            {
                Console.Clear();
                SlowPrint("You try fitting the rusty key into the key slot, you slowly try turning it without breaking the key.\nThe door clicks satisfyingly." +
                    "\nHUZZAH the door opened.");
                string userInput2 = Console.ReadLine();
                if (userInput2.ToLower() == "forward")
                {
                    string cutScene = File.ReadAllText("openDoor.txt");
                    string[] Art = cutScene.Split(',');
                    for (int i = 0; i < 11; i++)
                    {
                        Console.Clear();
                        Console.WriteLine(Art[i]);
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                    // enter the manor and fight the first enemy
                    Q7();
                }
                else if (userInput2.ToLower() == "back")
                {
                    Console.Clear();
                    SlowPrint("Feeling the cold air on your skin and the smell of old moist carpet almost makes you vomit.\nYou decide to take a step back and reevaluate" +
                        " your situation.");
                    Console.ReadKey();
                    Q6();
                }
                else
                {
                    SlowPrint("Im just a robot, I dont understand.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Q6();
                }
            }
            else if (userInput.ToLower() == "right")
            {
                Console.Clear();
                SlowPrint("As you peer into the window you see a old painting with a humble man on it.\nIt reads: Sir Luuksalot van Northingham, ruler of the first Ikea settlement.");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                string sirLuuksAlot = File.ReadAllText("luukAscii.txt");
                Console.Write(sirLuuksAlot);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ReadKey();
                Console.Clear();
                Q6();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You step away from the entrance to continue searching the garden.");
                Console.ReadKey();
                Q3();

            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q6();
            }
        }
        /// <summary>
        /// This method will place the player inside the manor.
        /// </summary>
        void Q7()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("OBJECTIVE 2. FIND A PLACE TO SLEEP");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Console.Clear();
            SlowPrint("You take some steps into the main lobby.\nYou need to find a couch or a mattress so you can get some rest.\nYou really need to go to the bathroom though, there are two hallways" +
                " one on your left, and the other on your right (neither look very inviting).");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "left")
            {
                Console.Clear();
                SlowPrint("You go to the left because your gut says you should.");
                Console.ReadKey();
                Q8();
            }
            else if (userInput.ToLower() == "right")
            {
                Console.Clear();
                Q11();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q7();
            }
        }
        /// <summary>
        ///  This method is for all available options in the left room of the manor.
        /// </summary>
        void Q8()
        {
            Console.Clear();
            SlowPrint("This dimly lit room looks like it used to be a living room, and look! In front of you is a couch, it could be good place to get some shuteye.\n" +
                "On your left is a rotten coffee table, on your right is potted plant.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "forward")
            {
                Q9();
            }
            else if (userInput.ToLower() == "right")
            {
                Console.Clear();
                SlowPrint("You turn to the right and see potted plant, it genuinly does absolutely nothing.\nYou walk back to where you entered this room.\n");
                Console.ReadKey();
                Q8();
            }
            else if (userInput.ToLower() == "left")
            {
                Q10();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You turn around and head to the main lobby.");
                Console.ReadKey();
                Q7();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q8();
            }
        }
        /// <summary>
        /// This method is for the couch and all it's available options in the left room of the manor 
        /// </summary>
        void Q9()
        {
            Console.Clear();
            SlowPrint("It's a dusty old couch, but it will work for one night.\nYou can try to sleep on it now if you want to.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "sleep")
            {
                Console.Clear();
                SlowPrint("You decide to not go to the bathroom and just immediately go to sleep." +
                    "\nYou woke up the next day feeling somewhat refreshed and ready to start work.\n\n\n");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ending (2/5) unlocked: Sleepy Gary\n\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Environment.Exit(0);
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You stepped away from the couch.");
                Console.ReadKey();
                Q8();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q9();
            }
        }
        /// <summary>
        /// This method is for the coffee table and all it's available options in the left room of the manor.
        /// </summary>
        void Q10()
        {
            Console.Clear();
            SlowPrint("On your left is a little dark oak coffee table there is nothing on top of it, but there are a four little drawers.\n(Enter the number of the drawer you want to open.)");
            string userInput = Console.ReadLine();
            // The switch statement checks if the user inputted 1, 2, 3 or 4.
            switch (userInput)
            {
                // Cabinet 1 is empty.
                case "1":
                    Console.Clear();
                    SlowPrint("It's empty.");
                    Console.ReadKey();
                    Q10();
                    break;
                // Cabinet 2 has a healing item.
                case "2":
                    if (currentPlayer.snacks < 3)
                    {
                        Console.Clear();
                        currentPlayer.snacks++;
                        SlowPrint("You opened the second drawer.\nAnd inside was a little bag of chocolade munten.\nYou now have " + currentPlayer.snacks + " snacks!");
                        Console.ReadKey();
                        Q10();
                    }
                    else
                    {
                        Console.Clear();
                        SlowPrint("It's empty.");
                        Console.ReadKey();
                        Q10();
                    }
                    break;
                // Cabinet 3 has a potoo collectivle in it, if the player hasn't collected the collectible this will play
                case "3":
                    if (currentPlayer.potooCollectibles < 2 && currentPlayer.seenCollectible2 == false)
                    {
                        Console.Clear();
                        currentPlayer.seenCollectible2 = true;
                        currentPlayer.potooCollectibles++;
                        SlowPrint("You open the drawer expecting it to be empty, but wait there is a shiny looking figurine it's some kind of bird...\n" +
                            "You now have " + currentPlayer.potooCollectibles + " Potoo figurine(s)");
                        Console.ReadKey();
                        Q10();
                    }
                    // if the player has collected the collectible this will play.
                    else
                    {
                        Console.Clear();
                        SlowPrint("It's empty.");
                        Console.ReadKey();
                        Q10();
                    }
                    break;
                // Cabinet 4 is empty.
                case "4":
                    Console.Clear();
                    SlowPrint("It's empty.");
                    Console.ReadKey();
                    Q10();
                    break;

                case "back":
                    Console.Clear();
                    SlowPrint("You step away from the coffee table.");
                    Console.ReadKey();
                    Q8();
                    break;
                // It defaults to the code below if the user input isn't recognised as any of the above.
                default:
                    SlowPrint("Im just a robot, I dont understand.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Q10();
                    break;
            }
        }
        /// <summary>
        /// This method is for the right hallway, this will send the player to the first enemy.
        /// </summary>
        void Q11()
        {
            Console.Clear();
            SlowPrint("As you walk through the right door, you almost get scared to death...");
            Console.ReadKey();
            Console.Clear();
            // you encounter the first enemy, It's parameters are the currentplayer class.
            encounter.FirstEncounter(currentPlayer);
            Console.Clear();
            SlowPrint("Uh oh, you don't feel so good.\n\n\n");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            SlowPrint("You have passed out due to severe exhaustion.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("END CHAPTER 1");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Q12();
        }
        #endregion
        #region chapter2
        /// <summary>
        ///  This method is will place the player in the basement.
        /// </summary>
        void Q12()
        {
            Console.Clear();
            SlowPrint("You wake up feeling dazed, as if you slept on a concrete floor.\nAs you open your eyes you sense how cold it is and worst part is you can't see anything...");
            Console.ReadKey();
            Console.Clear();
            SlowPrint("As your eyes adjust to the darkness you can make out some shapes around you.\nYou think to yourself: Where am I? What is this?\nYou look around the room and you realise 'I'm in a basement'.");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("OBJECTIVE 3. GET OUT.", 50);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Console.Clear();
            Q13();
        }
        /// <summary>
        /// This method is for the north side of the basement with all of it's components.
        /// </summary>
        void Q13()
        {
            Console.Clear();
            SlowPrint("You look around the room, in front of you is a staircase, to the right of you is some old furniture, on the left is just a concrete wall.\n(Type back to turn around)");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "forward" && currentPlayer.playerHasAxe == false)
            {
                Console.Clear();
                SlowPrint("You tried opening the door, but it doesn't budge.\nYou walk back down the stairs in defeat.");
                Console.ReadKey();
                Q13();
            }
            else if (userInput.ToLower() == "forward" && currentPlayer.playerHasAxe == true)
            {
                Q18();
            }
            else if (userInput.ToLower() == "left")
            {
                Q14();
            }
            else if (userInput.ToLower() == "right")
            {
                Q15();
            }
            else if (userInput.ToLower() == "back" && currentPlayer.enemiesDefeated1 == false)
            {
                Console.Clear();
                Q16();
            }
            else if (userInput.ToLower() == "back" && currentPlayer.enemiesDefeated1 == true)
            {
                Console.Clear();
                SlowPrint("You turn back around.");
                Console.ReadKey();
                Q17();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q13();
            }

        }
        /// <summary>
        /// This method is for the wall on the left in the north side of the basement, it contains an easter egg.
        /// </summary>
        void Q14()
        {
            Console.Clear();
            SlowPrint("It's a concrete wall, it does nothing, right?");
            currentPlayer.bumped++;
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "left" && currentPlayer.bumped == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                SlowPrint("You stumble into the wall, you pass through it.\nIf you're not careful and you noclip out of reality in the wrong areas, you'll end up in the Backrooms," +
                    " where it's nothing but the stink of old moist carpet, the madness of mono-yellow, the endless background noise of fluorescent lights at maximum hum-buzz, " +
                    "and approximately six hundred million square miles of randomly segmented empty rooms to be trapped in\r\nMercy be on you if you hear something wandering around nearby," +
                    " because it sure as hell has heard you.");
                Console.ReadKey();
                Console.Clear();
                string backrooms = File.ReadAllText("backrooms_ascii.txt");
                Console.Write(backrooms);
                SlowPrint("\nIn front of you is your lost old plush bear you can faintly remember it's name 'Gido bear'\n\n\n");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                SlowPrint("Ending (3/5) unlocked: Trapped forever\n\n\n");
                Environment.Exit(0);
            }
            // random lines for you bumping into the wall
            else if (userInput.ToLower() == "left")
            {
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        Console.Clear();
                        SlowPrint("You run into the wall but, it's a wall, IT DOES NOTHING.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        SlowPrint("You knocked yourself out again...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        Q13();
                        break;
                    case 2:
                        Console.Clear();
                        SlowPrint("You run into the wall, I'm serious, it does genuinly nothing.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        SlowPrint("You knocked yourself out again...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        Q13();
                        break;
                    case 3:
                        Console.Clear();
                        SlowPrint("You run into the wall, What do you not understand?! It's a wall it does nothing.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        SlowPrint("You knocked yourself out again...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        Q13();
                        break;
                    case 4:
                        Console.Clear();
                        SlowPrint("You run into the wall, I don't get it, what is so interesting about this wall?");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        SlowPrint("You knocked yourself out again...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        Q13();
                        break;
                }
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You turn back around.");
                Console.ReadKey();
                Q13();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q13();
            }
        }
        /// <summary>
        /// This method is for the furniture on the right and all of it's components.
        /// </summary>
        void Q15()
        {
            Console.Clear();
            SlowPrint("In front of you is some old furniture, an old couch, some old shelves and an rusty toolbox.\n(Write the names of the item to investigate)");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "couch" && currentPlayer.seenCouch == false)
            {
                Console.Clear();
                currentPlayer.seenCouch = true;
                SlowPrint("It's and old couch, you feel in between the pillows you find some old werthers candy.");
                currentPlayer.snacks++;
                currentPlayer.snacks++;
                SlowPrint("You now have " + currentPlayer.snacks + " snacks!\nYou turn around and go back.");
                Console.ReadKey();
                Q15();
            }
            else if (userInput.ToLower() == "couch" && currentPlayer.seenCouch == true)
            {
                Console.Clear();
                SlowPrint("It's and old couch, you feel in between the pillow you find absolutely nothing.\nYou turn around and go back.");
                Console.ReadKey();
                Q15();
            }
            else if (userInput.ToLower() == "shelves")
            {
                Console.Clear();
                SlowPrint("You decide to look at the shelves, they were probably used to showcase picture frames and flowers.\nYou turn around and go back");
                Console.ReadKey();
                Q15();
            }
            else if (userInput.ToLower() == "toolbox")
            {
                Console.Clear();
                SlowPrint("It's an old rusty toolbox, sadly it's empty apart from some candy and a half empty bottle of wood glue.\nCongrats, you got 1 bag of skittles and some wood glue!");
                workBench.necessaryItems.Add("Wood Glue");
                currentPlayer.woodGlue = true;
                currentPlayer.snacks++;
                Console.ReadKey();
                Q13();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You walk back in order to look around the room some more.");
                Console.ReadKey();
                Q13();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q15();
            }

        }
        /// <summary>
        /// This method is for turning around to face the south side of the basement, and fighting the enemies.
        /// </summary>
        void Q16()
        {
            Console.Clear();
            SlowPrint("As you turn around you see some shadowy figures observing you.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "investigate")
            {
                Console.Clear();
                SlowPrint("You decide to investigate the figures");
                Console.ReadKey();
                // This will make the player fight against a normal enemy
                encounter.NormalFight(currentPlayer);
                SlowPrint("2 enemies remaining.");
                Console.ReadKey();
                encounter.NormalFight(currentPlayer);
                SlowPrint("1 enemy remaining.");
                Console.ReadKey();
                encounter.NormalFight(currentPlayer);
                SlowPrint("0 enemies remaining.");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                SlowPrint("BASEMENT SOUTH SIDE UNLOCKED");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You loudly say 'nope' and turn back around.");
                Console.ReadKey();
                Q13();
            }
            else
            {
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q16();
            }

        }
        /// <summary>
        ///  This void is for the south side of the basement with all of it's components.
        /// </summary>
        void Q17()
        {
            currentPlayer.enemiesDefeated1 = true;
            Console.Clear();
            SlowPrint("In front of you is a workbench, on it's left side are some old boxes, on the right is an old furnace with some firewood next to it.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "forward" && currentPlayer.axeHead == false)
            {
                currentPlayer.axeHead = true;
                Console.Clear();
                SlowPrint("On the workbench you found 1 Axe Head!\nYou can probably craft an axe to break down the door thats blocking you from getting outside of the basement.");
                Console.ReadKey();
                workBench.necessaryItems.Add("Axe head");
                workBench.workBench();
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "forward" && currentPlayer.axeHead == true)
            {
                Console.Clear();
                SlowPrint("It's just an empty workbench, but it can be used to craft something");
                Console.ReadKey();
                workBench.workBench();
                Console.ReadKey();
                if (currentPlayer.axeHead == true && currentPlayer.axeHandle == true && currentPlayer.woodGlue == true && currentPlayer.hasPlayerCrafted == false)
                {
                    currentPlayer.hasPlayerCrafted = true;
                    string craftingAxe = File.ReadAllText("creatingAxe.txt");
                    string[] Art = craftingAxe.Split('1');
                    currentPlayer.playerHasAxe = true;
                    int i = 0;
                    // This do statement will output the code once, skipping the conditions
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(Art[i]);
                        Thread.Sleep(1500);
                        Console.Clear();
                        i++;
                    }
                    // While i is less than 7 the do while loop will replay.
                    while (i < 7);
                    SlowPrint("Now you just have to wait 30 minutes for the glue to dry");
                    Console.ReadKey();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Console.beep makes the console output a short beep sound.
                    Console.Beep();
                    Console.WriteLine("30:00");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:59");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:58");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:57");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:56");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:55");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine("29:54");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    SlowPrint("Just kidding, this is a game so you don't have to wait... FAAASSTTTT FORWAAAARDDD");
                    Console.ReadKey();
                    SlowPrint("\nAfter 30 minutes of waiting and laying on the floor the glue has finally dried.\n" +
                        "Congratulations you got an Axe!");
                    Console.ReadKey();
                    Q17();
                }
                Q17();
            }
            else if (userInput.ToLower() == "left" && currentPlayer.seenCollectible3 == false)
            {
                Console.Clear();
                currentPlayer.potooCollectibles++;
                currentPlayer.seenCollectible3 = true;
                SlowPrint("As you move closer to the boxes you see that they were used for storing valuable items such as family heirlooms.\nSomething shiny is poking from beneath the trash.");
                Console.ReadKey();
                Console.Clear();
                SlowPrint("Congratulations you currently have " + currentPlayer.potooCollectibles + " Potoo figurine(s)");
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "left" && currentPlayer.seenCollectible3 == true)
            {
                Console.Clear();
                SlowPrint("As you move closer to the boxes you see that they were used for storing valuable items such as family heirlooms.\n" +
                    "Now they are just filled up with trash and dust.");
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "right" && currentPlayer.axeHandle == false)
            {
                Console.Clear();
                currentPlayer.axeHandle = true;
                workBench.necessaryItems.Add("Axe handle");
                SlowPrint("You went in for a closer look at the pile of wood\nYou found 1 Axe Handle!");
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "right" && currentPlayer.axeHandle == true)
            {
                Console.Clear();
                SlowPrint("You went in for a closer look at the pile of wood, it's just some wood... What's so interesting about it.");
                Console.ReadKey();
                Q17();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You turn back around.");
                Console.ReadKey();
                Q13();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q17();
            }

        }
        /// <summary>
        ///  This method is for exiting the basement if the player has the axe.
        /// </summary>
        void Q18()
        {
            Console.Clear();
            SlowPrint("You swing your axe with all your might against the door, you force yourself not to say: HERE'S JOHNNY\n" +
                "After a bit of chopping at the door you manage to make a hole large enough to fit yourself through.");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("OBJECTIVE 4. ESCAPE THE MANOR.", 50);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Console.Clear();
            SlowPrint("Infront of you are two spirits guarding the door to the basement.\nYou swung your axe at them... It does nothing, since ghosts don't have a physical form silly.");
            Console.ReadKey();
            Console.Clear();
            SlowPrint("They attack you in response to you trying to attack them (purely in self defence though).");
            Console.ReadKey();
            encounter.NormalFight(currentPlayer);
            SlowPrint("1 enemy remaining.");
            Console.ReadKey();
            encounter.NormalFight(currentPlayer);
            SlowPrint("0 enemies remaining.");
            Console.ReadKey();
            SlowPrint("Phew you got them!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint("End chapter 2.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Q19();
        }
        #endregion
        #region chapter3
        /// <summary>
        ///  This method will place the player outside of the basement door, you can go left or right.
        /// </summary>
        void Q19()
        {
            Console.Clear();
            SlowPrint("You take a good look around looks like there aren't too many options.\nThere are two hallways, left and right.\nWhat do you do?");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "left")
            {
                Console.Clear();
                SlowPrint("You run into the left hallway.");
                Console.ReadKey();
                Q21();
            }
            else if (userInput.ToLower() == "right")
            {
                Console.Clear();
                SlowPrint("You make a break for the right hallway, after a bit of running you see some light... is that the exit?\nNo.. oh no...");
                Console.ReadKey();
                Q20();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q19();
            }
        }
        /// <summary>
        /// This method is for the right hallway with all of it's components.
        /// </summary>
        void Q20()
        {
            Console.Clear();
            SlowPrint("In front of you is just a lit candle.. and a table with something on it, standing at the end of a hallway.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "investigate" && currentPlayer.seenTable == false)
            {
                currentPlayer.seenTable = true;
                currentPlayer.potooCollectibles++;
                Console.Clear();
                SlowPrint("You see that on the little table is a golden figurine of a bird. It looks goofy, but also valuable so you take it." +
                    "\nCongratulations you now have " + currentPlayer.potooCollectibles + " potoo figurine(s)!");
                Console.ReadKey();
                Q20();
            }
            if (userInput.ToLower() == "investigate" && currentPlayer.seenTable == true)
            {
                Console.Clear();
                SlowPrint("The table is made out of acacia wood, not sure why that is important...");
                Console.ReadKey();
                Q20();
            }
            else if (userInput.ToLower() == "back" && currentPlayer.enemiesDefeated2 == false)
            {
                Console.Clear();
                SlowPrint("You turn around thinking you're safe but...");
                Console.ReadKey();
                encounter.NormalFight(currentPlayer);
                currentPlayer.enemiesDefeated2 = true;
                Console.Clear();
                if (currentPlayer.healthPoints > 15)
                {
                    SlowPrint("That was easy you just had to attack early, unlike Gerben you are good with time.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (currentPlayer.healthPoints < 7)
                {
                    SlowPrint("Phew that was close, luckily you made it out");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.ReadKey();
                    SlowPrint("You got it. Nice job!");
                    Console.ReadKey();
                    Console.Clear();
                }
                currentPlayer.snacks++;
                SlowPrint("Hey, it looks like it dropped something.. you got some ghost candy? Wierd...\nCongrats you now have " + currentPlayer.snacks + " snacks!");
                Console.ReadKey();
                SlowPrint("You run back to the first hallway.");
                Console.ReadKey();
                Q19();

            }
            else if (userInput.ToLower() == "back" && currentPlayer.enemiesDefeated2 == true)
            {
                Console.Clear();
                SlowPrint("You run back to the first hallway.");
                Console.ReadKey();
                Q19();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q20();
            }

            void Q21()
            {
                Console.Clear();
            }
        }
        /// <summary>
        /// This method is for the left hallway with all of it's components.
        /// </summary>
        void Q21()
        {
            Console.Clear();
            SlowPrint("You round a corner and you see that there is a small jar of gumballs on your left, and the rest of the hallway is infront of you.");
            String userInput = Console.ReadLine();
            if (userInput.ToLower() == "forward")
            {
                Q23();
            }
            else if (userInput.ToLower() == "left")
            {
                Q22();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You run back to the first hallway.");
                Console.ReadKey();
                Q19();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q21();
            }
        }
        /// <summary>
        /// This method is for the gumball machine with all of it's components.
        /// </summary>
        void Q22()
        {
            Console.Clear();
            SlowPrint("You take a closer look at the jar of gumballs but you can't see how many are left in it.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "investigate" && currentPlayer.gumballsTaken > 0)
            {
                currentPlayer.gumballsTaken--;
                Console.Clear();
                SlowPrint("You take 1 gumball out of the jar.");
                currentPlayer.snacks++;
                Console.ReadKey();
                Console.Clear();
                SlowPrint("Congratulations, you now have " + currentPlayer.snacks + " snacks!");
                Console.ReadKey();
                Q22();
            }
            else if (userInput.ToLower() == "investigate" && currentPlayer.gumballsTaken <= 0 && currentPlayer.isJarSmashed == false)
            {
                Console.Clear();
                SlowPrint("You stick your grubby hand into the jar of gumballs, it's empty.\nYour push your hand even further in to check if it is completely empty\n" +
                    "*plop* your hand slipped too far into the jar and now it is stuck, great job...");
                Console.ReadKey();
                Console.Clear();
                currentPlayer.isJarSmashed = true;
                SlowPrint("In order to get your hand unstuck you smash the jar on the ground.\nYou take 1 damage");
                Console.ReadKey();
                currentPlayer.healthPoints--;
                SlowPrint("Your hp is now " + currentPlayer.healthPoints + "!");
                Q22();
            }
            else if (userInput.ToLower() == "investigate" && currentPlayer.isJarSmashed == true)
            {
                Console.Clear();
                SlowPrint("There are just some broken shards of jar on the floor, do you feel proud of yourself?");
                Console.ReadKey();
                Q22();
            }
            else if (userInput.ToLower() == "back")
            {
                Console.Clear();
                SlowPrint("You take some steps back.");
                Console.ReadKey();
                Q21();
            }
            else
            {
                Console.Clear();
                SlowPrint("Im just a robot, I dont understand.");
                Thread.Sleep(1000);
                Console.Clear();
                Q22();
            }
        }
        /// <summary>
        /// This method is for the triple fighting sequence with all of it's components.
        /// </summary>
        void Q23()
        {
            Console.Clear();
            SlowPrint("You find your way into the main lobby, but there is a creepy figure blocking the way, he kinda looks like a friend of yours, Sietse.");
            int i = 0;
            do
            {
                // If the player has defeated the first enemy this code will play.
                if (currentPlayer.enemiesDefeated == 1)
                {
                    SlowPrint("Great, you're almost out, you rush to open the door, it's locked.\nLuckily there is a window next to it." +
                        "\nAs any rational person would do you just jump straight through it.\nWith all the ruckus and sound you made another figure has spotted you and is rapily approaching your location.");
                }
                // If the player has defeated the second enemy this code will play.
                else if (currentPlayer.enemiesDefeated == 0)
                {
                    SlowPrint("You make a break for the gate, but unfortunalty you are stopped by one hell of a spirit!");
                }
                currentPlayer.enemiesDefeated--;
                // This generates a random number
                int num = rnd.Next(0, 4);
                SlowPrint("(You can choose to run from it, if so there is a chance you get past it.)");
                string userInput = Console.ReadLine();
                Console.Clear();
                if (userInput.ToLower() == "forward")
                {
                    SlowPrint("With no more shits left to give, you walk to the figure and dare it to fight you.");
                    Console.ReadKey();
                    Console.Clear();
                    encounter.NormalFight(currentPlayer);
                    i++;
                }
                else if (userInput.ToLower() == "forward")
                {
                    Console.ReadKey();
                    Console.Clear();
                    encounter.NormalFight(currentPlayer);
                    i++;
                }
                else if (userInput.ToLower() == "forward")
                {
                    Console.ReadKey();
                    Console.Clear();
                    encounter.NormalFight(currentPlayer);
                    i++;
                }
                // If the player inputs run and the random number equals 0 this code will play
                else if (userInput.ToLower() == "run" && num == 0)
                {
                    SlowPrint("With your ninja skills you manage to dodge the figure, flipping it off as you run past it!");
                    Console.ReadKey();
                    Console.Clear();
                    i++;
                }
                // If the player inputs run and the random number doesn't equal to 0 this code will play
                else if (userInput.ToLower() == "run" && num > 0)
                {
                    SlowPrint("Oof, you tripped on your shoelace trying to get past it, it notices you and smirks, pelting you with a levitating rock");
                    Console.ReadKey();
                    Console.Clear();
                    encounter.NormalFight(currentPlayer);
                    Console.Clear();
                    i++;
                }
                else
                {
                    SlowPrint("Im just a robot, I dont understand.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Q23();
                }
            }
            while (i < 3);
            {
                Q26();
            }
        }
        #endregion
        #region boss
        /// <summary>
        /// This method is for the bossfight.
        /// </summary>
        void Q26()
        {
            Console.Clear();
            Console.WriteLine("You sprint as fast as you can to the gate, but what do you see?");
            Console.ReadKey();
            // This will make the player have to fight against the final boss.
            encounter.BossFight(currentPlayer);
            Console.Clear();
            currentPlayer.potooCollectibles++;
            SlowPrint("Hey look, it dropped something.. it's some sort of golden doll of figurine, you take it without hesitation." +
                "\nCongratulations you now have " + currentPlayer.potooCollectibles + " potoo figurine(s).");
            Console.ReadKey();
            Console.Clear();
            if (currentPlayer.potooCollectibles == 5)
            {
                SlowPrint("You climb over the gate not even trying to check if the gate is locked or not!\nYou get into your car and speed away not caring where you're going." +
                    "\nAll 5 of your figurines were actually really valuable artifacts, you sold them to a museum for 4.7 million dollars.");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                SlowPrint("Ending 5/5 unlocked: Turns out I'm rich!\n\n\n");
                System.Environment.Exit(0);
            }
            SlowPrint("You climb over the gate not even trying to check if the gate is locked or not!\nYou get into your car and speed away not caring where you're going.\nThankfully you made it out alive.\n" +
                "You drop out of college in order to become a fulltime ghost hunter!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            SlowPrint("Ending 4/5 unlocked: Finally Free\n\n\n");
        }
        #endregion
        /// <summary>
        /// This void is for the letter by letter character generation.
        /// </summary>
        public void SlowPrint(string text, int speed = 1)
        {
            // for every c in text (character in text) this code will play
            foreach (char c in text)
            {
                // c = every letter
                Console.Write(c);
                // This will place a delay in between every character, specified by "speed" 
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
}