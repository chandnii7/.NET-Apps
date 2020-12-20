using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus
{
    class Room
    {
        public string name;
        public bool hasPit;
        public bool hasBats;
        public bool hasWumpus;
        public Room[] neighbors;

        public Room()
        {
            neighbors = new Room[3];
            Reset();
        }

        /// <summary>
        /// Sets flags back to false
        /// </summary>
        public void Reset()
        {
            hasBats = false;
            hasPit = false;
            hasWumpus = false;
        }

        public void Print()
        {
            Console.WriteLine("You are in room  " + name);
            Console.WriteLine("There are passages to rooms " +
                neighbors[0].name + ", " +
                neighbors[1].name + ", and " +
                neighbors[2].name
                );

            if (HasDraft())
            {
                Console.WriteLine("~You can feel a draft~");
            }
            if (HearsBats())
            {
                Console.WriteLine("*Squeak* *Squeak* There must be bats nearby.");
            }
            if (CanSmellWumpus())
            {
                Console.WriteLine("I SMELL A WUMPUS!");
            }

        }

        /// <summary>
        /// Returns true if this room is adjacent to one with the Wumpus
        /// </summary>
        /// <returns></returns>
        public bool CanSmellWumpus()
        {
            //TODO - Return true if the hasWumpus
            //flag in any of neighbors
            //is set to true. Otherwise, return false.
            for (int i = 0; i < 3; i++)
            {
                if (neighbors[i].hasWumpus == true)
                    return true;
            }
            return false;
         }

        /// <summary>
        /// Returns true if this room is adjacent to one with a pit
        /// </summary>
        /// <returns></returns>
        public bool HasDraft()
        {
            //TODO - Return true if the hasPit
            //flag in any of neighbors
            //is set to true. Otherwise, return false.
            for (int i = 0; i < 3; i++)
            {
                if (neighbors[i].hasPit == true)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if this room is adjacent to one with a bats
        /// </summary>
        /// <returns></returns>
        public bool HearsBats()
        {
            //TODO - Return true if the hasBats
            //flag in any of neighbors
            //is set to true. Otherwise, return false.
            for (int i = 0; i < 3; i++)
            {
                if (neighbors[i].hasBats == true)
                    return true;
            }
            return false;
        }
    }
}
