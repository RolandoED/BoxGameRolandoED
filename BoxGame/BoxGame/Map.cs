﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Runtime.Serialization.Formatters.Binary;
//using System.Web.Script.Serialization;
using System.IO;


namespace BoxGame
{
    [Serializable()]

    public class Map
    {
        public Map(int[,] arr)
        {
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
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    	      
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    	      
	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    	      
 	    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	    };

        public void printArray() {
            string toPrint = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                toPrint += "\n";
                for (int xx = 0; xx < array.GetLength(1); xx++)
                {
                    toPrint += array[i, xx];
                }
            }
            Console.WriteLine(toPrint);
        }    
    }
}
