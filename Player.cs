using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J1P2_PRO_Prototype1_Levi_Feunekes
{
    // This is every stat that the player uses.
    class Player
    {
        // All strings
        public string name;
        // All ints
        public int healthPoints = 20;
        public int damage = 0;
        public int defense = 0;
        public int dmgReduction = 0;
        public int snacks = 2;
        public int keys = 0;
        public int bumped = 0;
        public int potooCollectibles = 0;
        public int gumballsTaken = 3;
        public int enemiesDefeated = 2;
        // All booleans
        public bool seenCollectible2 = false;
        public bool seenCollectible3 = false;
        public bool seenTable = false;
        public bool seenDoor = false;
        public bool seenCouch = false;
        public bool enemiesDefeated1 = false;
        public bool enemiesDefeated2 = false;
        public bool playerHasAxe = false;
        public bool hasPlayerCrafted = false;
        public bool axeHead = false;
        public bool axeHandle = false;
        public bool woodGlue = false;
        public bool isJarSmashed = false;
        public bool hasSeenBoss = false;
    }
}

