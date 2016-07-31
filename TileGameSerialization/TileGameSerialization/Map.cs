using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Runtime.Serialization.Formatters.Binary;
//using System.Web.Script.Serialization;
using System.IO;

namespace TileGameSerialization
{
    [Serializable()]
    class Map
    {
        public Map(int[,] arr)
        {
            // TODO: Complete member initialization
            array = arr;
        }
        public Map()
        {
        }

        public int MaxMovements { get; set; }

        public int[,] array = new int[,]
	    {
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    	      
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    	      
 	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    };

        public string printArray() {
            string toPrint = "";
            for (int Y = 0; Y < array.GetLength(0) - 1; Y++)
            {
                toPrint += "\n";
                for (int X = 0; X < array.GetLength(1) - 1; X++)
                {
                    toPrint += array[Y, X];
                    //Console.WriteLine(array[i, xx]);                    
                }
            }
            Console.WriteLine(toPrint);
            return toPrint;
        }

    }
}
