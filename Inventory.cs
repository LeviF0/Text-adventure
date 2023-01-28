using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J1P2_PRO_Prototype2_Levi_Feunekes
{
    internal class Inventory
    {
        // This is used for crafting the axe used to get out of the basement.
        public List<string> necessaryItems = new List<string>();
        public void workBench()
        {
            // For every new item in the list, it will print everything in the list
            Console.Clear();
            Console.WriteLine("You now have:\n");
            foreach (string items in necessaryItems)
            {
                Console.WriteLine(items);
            }
            Console.WriteLine("\nYou can craft an axe if you have all three necessary parts.");
        }
    }
}
