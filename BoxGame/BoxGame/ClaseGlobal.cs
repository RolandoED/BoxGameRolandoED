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
        //usuario actualmente registrado si es nulo es que no se ha registrado
        public static Usuario _UsuarioActual;

        //cantidad de mapas encontrados en el folder maps
        public static int CantMaps = 0;

        //guada el valor true si se encontro un Archivo con el nombre isadmin.txt en el root
        public static Boolean IsAdmin = false;


        /// <summary>
        /// Cuenta cuantos Mapas existen en la carpeta maps
        /// </summary>
        /// <returns>int</returns>
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
                Console.WriteLine("CONTADOR !!!!!!!!!: " + cont);
                return cont+1;
            }
            catch (Exception)
            {
                Console.WriteLine("error leyendo la carpeta maps");
                return 0;
            }            
        }

        /// <summary>
        /// Metodos para mostrar mensajes y hacer el codigo mas corto en la parte funcional
        /// </summary>
        /// <param name="s"></param>
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

        /// <summary>
        /// Metodo Stub por si se necesitara guardar como TXT algun resultado
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="send"></param>
        public static void guardarDoc(string filename, string send)
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            StreamWriter sw = new StreamWriter(currentPath + "\\" + filename, true, Encoding.ASCII); //Ruta
            sw.Write(send);
            sw.Close();
        }
    }
}
