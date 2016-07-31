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

namespace TileGameSerialization
{
    public partial class Form1 : Form
    {
        Map firstmap = new Map();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstmap != null)
            {
                Console.WriteLine("0 : " + firstmap.array.GetLength(0));
                Console.WriteLine("0 : " + firstmap.array.GetLength(1));
                label1.Text = firstmap.printArray();
                Console.WriteLine("MOVEMENTS" + firstmap.MaxMovements);
            }
            else
                label1.Text = "Nullarray";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            bool seguardo = false;
            try
            {
                using (Stream stream = File.Open(currentPath + "\\"+"test.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, firstmap);
                }
            }
            catch (IOException)
            {
            }
            finally
            {
                if (seguardo)
                {
                    Console.WriteLine("Se guardo el objeto");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                using (Stream stream = File.Open(currentPath + "\\" + "test.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var arrlibs = (Map)bin.Deserialize(stream);
                    firstmap = arrlibs;
                }
                Console.WriteLine("Se leyo correctamente el archivo Binario");
            }
            catch (IOException)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cont = 0;
            firstmap = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            firstmap.MaxMovements++;
            Console.WriteLine("MOVEMENTS" + firstmap.MaxMovements);
        }
    }
}
