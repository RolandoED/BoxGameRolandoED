using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Windows.Forms;
using System.IO;

namespace BoxGame
{
    class ClaseGlobal
    {
        //public static UsuarioGuardado _UsuarioActualGuardado;
        //public static Usuario _UsuarioActual;

        public static int CantMaps = 0;

        public static Boolean IsAdmin = false;

        private static string gname = "";
        private static string glastname = "";

        public static string Gname
        {
            get { return gname; }
            set { gname = value; }
        }

        public static string Glastname
        {
            get { return glastname; }
            set { glastname = value; }
        }


        public static void ShowMessage(string s)
        {
            MessageBox.Show(s, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowText(string s)
        {
            MessageBox.Show(s, "-",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowText(string titulo, string msg)
        {
            MessageBox.Show(msg, titulo,
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void guardarDoc(string filename, string send)
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            StreamWriter sw = new StreamWriter(currentPath + "\\" + filename, true, Encoding.ASCII); //Ruta
            sw.Write(send);
            sw.Close();
        }

        public static int AnalizarCuantosMapasHay()
        {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                string[] filePaths = Directory.GetFiles(currentPath + "\\maps\\");
                //string paths = "";
                int cont = 0;
                foreach (string item in filePaths)
                {
                    string analizar = Path.GetFileName(item);
                    if (analizar.Length > 3)
                    {
                        if (analizar.Substring(0, 3).Equals("map"))
                        {
                            cont++;
                        }
                    }
                }
                Console.WriteLine("CONTADOR !!!!!!!!!!!!!!!!!!!!: " + cont);
                return cont+1;
            }
            catch (Exception)
            {
                Console.WriteLine("error leyendo la carpeta maps");
                return 0;
            }            
        }
    }
}
