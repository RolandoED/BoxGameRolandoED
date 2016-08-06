//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BoxGame
{
    class Usuario
    {
        //public int ID           { get; set; } 
        public string NAME      { get; set; } 
        public string NICK      { get; set; } 
        public float MAXSCORE   { get; set; } 
        public float RANK       { get; set; } 
                                  
        public Usuario() 
        {
            //ID = 0;
            NAME = string.Empty;
            NICK = string.Empty;
            MAXSCORE = float.MinValue;
            RANK = float.MinValue;        
        }
    }
}
