using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class Move
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int sweatRate { get; set; }

        public Move(int anId, string aName,  string aDescription, int aSweatRate) 
        {
            id = anId;
            name = aName;
            description = aDescription;
            sweatRate = aSweatRate;
        }

        //public string toShortString()
        //{
        //    return id.ToString() + ") " + name;
        //}

        //public string toString()
        //{
        //    return id.ToString() + ") " + name + " " + description + "" + sweatRate; 
        //}
    }
}
