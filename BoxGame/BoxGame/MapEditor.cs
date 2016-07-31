using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxGame
{
    public partial class MapEditor : Form
    {
        public PictureBox[] boxes = new PictureBox[100];

        int ConQuePintar = 0;

        int[,] array = new int[,]
        {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},    	                      	             
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},    	             
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},    	             
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        public MapEditor()
        {
            InitializeComponent();
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            int contador = 0;
            int cantidad = -1;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {                              
                cantidad++;
            }
            //se popula alrevez para que no quede del ultimo al primero
            contador = cantidad;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                boxes[contador] = pictureBox;
                boxes[contador].Image = Properties.Resources.terr; 
                boxes[contador].Image.Tag = "terr";
                contador--;
            }
            Console.WriteLine("");
        }

        //-BUTTONS
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

        private void addSidesAndCorners() {
            int contador = 0;
                foreach (var pictureBox in Controls.OfType<PictureBox>())
                {
                    Console.WriteLine(contador + " " + boxes[contador].Tag.ToString());
                }        
        }

        private void testmethod(){
        
            for (int x = 0; x < 100; x++)
			{
                Console.WriteLine(x+" TAG "+boxes[x].Image.Tag);

			}
        
        }

        //-PICTUREBOX EVENTS
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (ConQuePintar)
            {
                case 0:
                    ((PictureBox)sender).Image = Properties.Resources.isolatedtile;
                    ((PictureBox)sender).Image.Tag = "isolatedtile";
                    Console.WriteLine("TAG "+((PictureBox)sender).Image.Tag);
                    Console.WriteLine("TAG "+boxes[0].Image.Tag);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //AnalizarPictureBoxes();
            //addSidesAndCorners();
            testmethod();
        }

    }
}
