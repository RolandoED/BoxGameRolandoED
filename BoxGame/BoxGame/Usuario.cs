
/////USUARIO QUE SE Guarda en Clase Global como logueado
namespace BoxGame
{
    class Usuario
    {
        //public int ID           { get; set; } 
        public string NAME      { get; set; } 
        public string NICK      { get; set; } 
        public float MAXSCORE   { get; set; } 
        public float RANK       { get; set; }

        public Login Login
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        } 
                                  
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
