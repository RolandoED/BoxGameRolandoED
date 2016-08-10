using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Runtime.Serialization.Formatters.Binary;
//using System.Web.Script.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace BoxGame
{
    public partial class MapEditor : Form
    {
        public PictureBox[] boxes = new PictureBox[100];
        public Map Mapa = new Map();

        int ConQuePintar = 0;

        public MapEditor()
        {
            InitializeComponent();
        }

        private void showAllFiles() 
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            string[] filePaths = Directory.GetFiles(currentPath+"\\maps\\");
            string paths = "";
            foreach (string item in filePaths)
	        {
                paths += "\n" + Path.GetFileName(item) + "\n\r";
	        }
            textBox2.Text = paths;
        }

        /// <summary>
        /// Si la carpeta maps no existe la crea
        /// </summary>
        private void ExisteCarpetaMaps() {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                string path = currentPath + "\\maps";
                if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
            }
            catch (Exception e)
            {
                ClaseGlobal.ShowMessage(" " + e.Message);                
            }
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            ExisteCarpetaMaps();
            showAllFiles();
            int contador = 0;
            int cantidad = -1;
            txtIntentosActuales.Text = ""+Mapa.MaxMovements;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {                              
                cantidad++;
            }
            //// Se popula alrevez para que no quede del ultimo al primero
            contador = cantidad;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                //// Todos los picturebox de los lados estan disabled para poder hacer este check
                //// al checkear si estan enabled false , se settean como borde/isolatedtile
                if (pictureBox.Enabled == false)
                {
                    boxes[contador] = pictureBox;
                    boxes[contador].Image = Properties.Resources.isolatedtile;
                    boxes[contador].Image.Tag = "isolatedtile";
                }
                else
                {
                    boxes[contador] = pictureBox;
                    boxes[contador].Image = Properties.Resources.terr;
                    boxes[contador].Image.Tag = "terr";
                }
                contador--;
            }
            Console.WriteLine("");
        }

        //-BUTTONS
        ////Decide con que Bloque quiere pintar 
        ///y se asigna a una variable local de clase
        private void btnBorde_Click(object sender, EventArgs e)
        {
            ConQuePintar = 0;
        }

        private void btnJugador_Click(object sender, EventArgs e)
        {
            ConQuePintar = 1;
        }

        private void btnVacio_Click(object sender, EventArgs e)
        {
            ConQuePintar = 2;
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            ConQuePintar = 3;
        }

        private void btnObjetivo_Click(object sender, EventArgs e)
        {
            ConQuePintar = 4;
        }

        private void testmethod(){
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                Console.WriteLine(" TAG " + pictureBox.Image.Tag);
            }
        }

        /// <summary>
        /// Pasa el Array Lógico de la clase a los picture boxes
        /// </summary>
        private void PasarArrayAPictureBoxes() {                      
            int position = 0;   
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    //Guarda en el array 2d el numero correspondiente al tile
                    if (Mapa.array[i, xx] == 0)
                    {
                        boxes[position].Image = Properties.Resources.isolatedtile;
                        boxes[position].Image.Tag = "isolatedtile";
                    }
                    else if (Mapa.array[i, xx] == 1)
                    {
                        boxes[position].Image = Properties.Resources.player;
                        boxes[position].Image.Tag = "player";
                    }
                    else if (Mapa.array[i, xx] == 2)
                    {                        
                        boxes[position].Image = Properties.Resources.terr;
                        boxes[position].Image.Tag = "terr";
                    }
                    else if (Mapa.array[i, xx] == 3)
                    {
                        boxes[position].Image = Properties.Resources.block;
                        boxes[position].Image.Tag = "block";
                    }
                    else if (Mapa.array[i, xx] == 4)
                    {                        
                        boxes[position].Image = Properties.Resources.hotspot;
                        boxes[position].Image.Tag = "hotspot";
                        //boxes[position].Image.Tag = "player";
                    }
                    position++;
                }
            }

            //foreach (var item in boxes)
            //{
                
            //}
        }


        private void testmethod2() {
            int position = 0;
            Console.WriteLine("\n---\n");
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    Console.Write(Mapa.array[i, xx]);
                    position++;
                }
            }        
        }

        private Boolean asignarPicturesBoxexAArray()
        {
            int position = 0;
            int player = 0;
            int block = 0;
            int hotspot = 0;
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    //if (boxes[position].Image.Tag == null)
                    //{
                    //    ClaseGlobal.ShowMessage("ERROR ");
                    //}
                    if (boxes[position].Image.Tag != null)
                    {
                        //Guarda en el array 2d el numero correspondiente al tile
                        if (boxes[position].Image.Tag.Equals("isolatedtile"))
                        {
                            Mapa.array[i, xx] = 0;
                        }
                        else if (boxes[position].Image.Tag.Equals("player"))
                        {
                            Mapa.array[i, xx] = 1;
                            player++;
                        }
                        else if (boxes[position].Image.Tag.Equals("terr"))
                        {
                            Mapa.array[i, xx] = 2;
                        }
                        else if (boxes[position].Image.Tag.Equals("block"))
                        {
                            Mapa.array[i, xx] = 3;
                            block++;
                        }
                        else if (boxes[position].Image.Tag.Equals("hotspot"))
                        {
                            Mapa.array[i, xx] = 4;
                            hotspot++;
                        }

                    }
                    //update += array[i, xx];
                    position++;
                }
            }

            if (hotspot > 0 && block > 0 && hotspot == block && player == 1)
	        {
                Console.WriteLine("\n Map is valid");
		        return true;
	        }
            else
                Console.WriteLine("\n MAP is invalid , requires fixes");
                return false;

        }

        //-PICTUREBOX EVENTS
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (ConQuePintar)
            {
                case 0:
                    ((PictureBox)sender).Image = Properties.Resources.isolatedtile;
                    ((PictureBox)sender).Image.Tag = "isolatedtile";
                    //Console.WriteLine("TAG "+((PictureBox)sender).Image.Tag);
                    //Console.WriteLine("TAG "+boxes[0].Image.Tag);
                    break;
                case 1:
                    ((PictureBox)sender).Image = Properties.Resources.player;
                    ((PictureBox)sender).Image.Tag = "player";
                    break;
                case 2:
                    ((PictureBox)sender).Image = Properties.Resources.terr;
                    ((PictureBox)sender).Image.Tag = "terr";
                    break;
                case 3:
                    ((PictureBox)sender).Image = Properties.Resources.block;
                    ((PictureBox)sender).Image.Tag = "block";
                    break;
                //Default to 4
                default:
                    ((PictureBox)sender).Image = Properties.Resources.hotspot;
                    ((PictureBox)sender).Image.Tag = "hotspot";
                    break;
            }          
            //MessageBox.Show("clicked on: " + ((PictureBox)sender).Name);            
        }




        /// <summary>
        /// Guarda en el subfolder maps los mapas como objeto serializado con el estado actual
        /// </summary>
        /// 
        private void button3_Click(object sender, EventArgs e)
        {
            if (asignarPicturesBoxexAArray())
            {                            
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                bool seguardo = false;
                try
                {
                    if (!txtIntentos.Text.Equals(""))
                    {
                        Mapa.MaxMovements =  Int32.Parse(txtIntentos.Text);
                        
                    }
                    else
                    {
                        Mapa.MaxMovements = 25;
                    }
                    using (Stream stream = File.Open(currentPath + "\\maps\\" + textBox1.Text, FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, Mapa);
                    }
                }
                catch (IOException ew)
                {
                    ClaseGlobal.ShowMessage(ew.Message);
                }
                finally
                {
                    if (seguardo)
                    {
                        Console.WriteLine("Se guardo el objeto");
                    }

                }
            }
            else
            {
                Console.WriteLine("ERRROR ERROR");
            }
        }

        /// <summary>
        /// Lee  del subfolder maps los mapas como objeto serializado con el estado actual
        /// </summary>
        /// 
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                using (Stream stream = File.Open(currentPath + "\\maps\\" + textBox1.Text, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var recuperado = (Map)bin.Deserialize(stream);
                    Mapa.array = recuperado.array;
                    Mapa.MaxMovements = recuperado.MaxMovements;
                }
                Console.WriteLine("Se leyo correctamente el archivo Binario");
                txtIntentosActuales.Text = "" + Mapa.MaxMovements;
            }
            catch (IOException eexc)
            {
                ClaseGlobal.ShowMessage(eexc.Message);
            }
            finally {
                Mapa.printArray();
                PasarArrayAPictureBoxes();
            }
        }

        /// <summary>
        /// Debug Methods to visualize what is logially happening behind the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDebug2_Click(object sender, EventArgs e)
        {
            asignarPicturesBoxexAArray();
            testmethod2();
        }

        private void btnDebug1_Click(object sender, EventArgs e)
        {        
            //AnalizarPictureBoxes();
            testmethod();
        }

        private void btnDebug3_Click(object sender, EventArgs e)
        {
            Mapa.printArray();
            PasarArrayAPictureBoxes();
        }

    }
}
