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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;

namespace BoxGame
{
    public partial class Game : Form
    {
        public Map Mapa = new Map();

        private int Xpos;
        private int Ypos;
        private int oldXpos;
        private int oldYpos;
        private int MaxDer;
        private int MaxIzq;
        //Sentido en que se mueve el personaje
        // 1 arriba 2 abajo 3 derecha 4 izq
        private int sentido;
        List<Objective> objectives = new List<Objective>();
        List<Objective> blocks = new List<Objective>();
        //List<Map> historial = new List<Map>();

        Map firstmap = new Map();
        Map recoverymap = new Map();
        List<Objective> objectivesrecovery = new List<Objective>();
        List<Objective> blocksrecovery = new List<Objective>();
        public bool istherearecovery = false;

        public PictureBox[] boxes = new PictureBox[100];

        int[,] array = new int[,]
        {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 2, 2, 0, 2, 2, 2, 2, 2, 0},
        {0, 0, 4, 1, 2, 3, 3, 0, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 4, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 2, 3, 0, 2, 4, 2, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        int[,] newarray2 = new int[,]
        {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 0, 4, 1, 2, 3, 3, 0, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 4, 2, 2, 2, 2, 2, 2, 0},
        {0, 2, 2, 3, 2, 2, 4, 2, 2, 0},
        {0, 2, 2, 2, 2, 2, 2, 0, 2, 0},    	                      	             
        {0, 2, 2, 2, 2, 2, 2, 0, 2, 0},
        {0, 0, 2, 0, 2, 0, 2, 0, 2, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        public Game()
        {
            Mapa.array = array;
            InitializeComponent();
            int contador = 0;
            int cantidad = -1;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                cantidad++;
            }
            // Se popula alrevez para que no quede del ultimo al primero
            contador = cantidad;
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                boxes[contador] = pictureBox;
                contador--;
            }
            Console.WriteLine("");
            //boxes[0] = pictureBox1;
            // - - - -
            //boxes[34] = pictureBox35;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Console.WriteLine("");
            int tamano = array.GetLength(1);
            Console.WriteLine(array.GetLength(0));
            MaxDer = array.GetLength(1) - 1;
            Console.WriteLine(array.GetLength(1));
            MaxIzq = array.GetLength(0) - 1;
            Console.WriteLine("");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                //update += "\n";
                for (int xx = 0; xx < array.GetLength(1); xx++)
                {
                    firstmap.array[i, xx] = array[i, xx];
                    //update += array[i, xx];
                }
            }

            Console.WriteLine("CHECKING FIRST MAP");
            firstmap.printArray();
            //label1.Text = update;
            RefrescaPosdeJugador();
            RefrescaTiles();
        }


        public void KickSound()
        {
            Stream str = Properties.Resources.kick;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        public void BumpSound()
        {
            Stream str = Properties.Resources.bump;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        public void WalkSound()
        {
            Stream str = Properties.Resources.walk;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        public void RestartSound()
        {
            Stream str = Properties.Resources.restart;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        private void RefrescaPosdeJugador()
        {
            int x = 0;
            int y = 0;
            blocks.Clear();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int xc = 0; xc < array.GetLength(0); xc++)
                {
                    //salida +=
                    if (array[xc, i] == 1)
                    {
                        x = xc;
                        y = i;
                    }
                    else if (array[xc, i] == 4)
                    {
                        Objective guardar = new Objective(i, xc);
                        objectives.Add(guardar);
                        array[xc, i] = 2;
                    }
                    else if (array[xc, i] == 3)
                    {
                        Objective guardar = new Objective(i, xc);
                        blocks.Add(guardar);
                    }
                }
            }
            Console.WriteLine("BLOCKS : " + blocks.Count);
            Console.WriteLine("OBJECTIVES : " + objectives.Count);
            if (blocks.Count != objectives.Count)
            {
                MessageBox.Show("ERROR NO HAY LA MISMA CANTIDAD DE BLOQUES Y OBJETIVOS");
            }
            Xpos = x;
            Ypos = y;
            //array[x, y] = 5;        
        }

        /// <summary>
        /// Método que procesa la entrada de teclado arriba abajo izquierda y derecha
        /// Y depende de la entrada modifica el mapa
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns>bool</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            RefrescaPosdeJugador();
            //Si se mueve hacia la derecha
            if (keyData == Keys.Right)
            {
                //SystemSounds.Asterisk.Play();
                if (Ypos + 1 >= MaxDer)
                {
                    Console.WriteLine("No se mueve");
                    BumpSound();
                }
                else if (Ypos + 1 != MaxDer)
                {
                    // si el cuadro es tierra
                    if (array[Xpos, (Ypos + 1)] == 2)
                    {
                        Console.WriteLine("Se mueve para Derecha");
                        WalkSound();
                        sentido = 3;
                        array[Xpos, (Ypos + 1)] = 1;
                        array[Xpos, (Ypos)] = 2;
                        RefrescaPosdeJugador();
                    }
                    // si el cuadro es un bloque
                    else if (array[Xpos, (Ypos + 1)] == 3 &&
                             array[Xpos, (Ypos + 2)] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (array[Xpos, (Ypos + 1)] == 3 &&
                             array[Xpos, (Ypos + 2)] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 3;
                        array[Xpos, (Ypos)] = 2;
                        array[Xpos, (Ypos + 1)] = 1;
                        array[Xpos, (Ypos + 2)] = 3;
                        RefrescaPosdeJugador();
                    }
                }
                RefrescaTiles();
                return true;
            }
            else if (keyData == Keys.Left)
            {
                //SystemSounds.Beep.Play();
                if (Ypos - 1 <= 0)
                {
                    Console.WriteLine("No se mueve");
                    BumpSound();
                }
                else if (Ypos - 1 != 0)
                {
                    // si el cuadro es tierra
                    if (array[Xpos, (Ypos - 1)] == 2)
                    {
                        Console.WriteLine("Se mueve para Izq");
                        WalkSound();
                        sentido = 4;
                        array[Xpos, (Ypos - 1)] = 1;
                        array[Xpos, (Ypos)] = 2;
                        RefrescaPosdeJugador();
                    }
                    // si el cuadro es un bloque
                    else if (array[Xpos, (Ypos - 1)] == 3 &&
                             array[Xpos, (Ypos - 2)] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (array[Xpos, (Ypos - 1)] == 3 &&
                             array[Xpos, (Ypos - 2)] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 4;
                        array[Xpos, (Ypos)] = 2;
                        array[Xpos, (Ypos - 1)] = 1;
                        array[Xpos, (Ypos - 2)] = 3;
                        RefrescaPosdeJugador();
                    }
                }
                RefrescaTiles();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                //SystemSounds.Hand.Play();
                if (Xpos - 1 <= 0)
                {
                    Console.WriteLine("No se mueve");
                    BumpSound();
                }
                else if (Xpos - 1 != 0)
                {
                    // si el cuadro es tierra
                    if (array[(Xpos - 1), Ypos] == 2)
                    {
                        Console.WriteLine("Se mueve para Arriba");
                        WalkSound();
                        sentido = 1;
                        array[(Xpos - 1), Ypos] = 1;
                        array[(Xpos), Ypos] = 2;
                        RefrescaPosdeJugador();
                    }
                    // si el cuadro es un bloque
                    else if (array[(Xpos - 1), Ypos] == 3 &&
                             array[(Xpos - 2), Ypos] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (array[(Xpos - 1), Ypos] == 3 &&
                             array[(Xpos - 2), Ypos] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 1;
                        array[(Xpos), Ypos] = 2;
                        array[(Xpos - 1), Ypos] = 1;
                        array[(Xpos - 2), Ypos] = 3;
                        RefrescaPosdeJugador();
                    }
                }

                RefrescaTiles();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                //SystemSounds.Question.Play();
                if (Xpos + 1 >= MaxIzq)
                {
                    Console.WriteLine("No se mueve");
                    BumpSound();
                }
                else if (Xpos + 1 != MaxIzq)
                {
                    // si el cuadro es tierra
                    if (array[(Xpos + 1), Ypos] == 2)
                    {
                        Console.WriteLine("Se mueve para Arriba");
                        WalkSound();
                        sentido = 2;
                        array[(Xpos + 1), Ypos] = 1;
                        array[(Xpos), Ypos] = 2;
                        RefrescaPosdeJugador();
                    }
                    // si el cuadro es un bloque
                    else if (array[(Xpos + 1), Ypos] == 3 &&
                             array[(Xpos + 2), Ypos] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (array[(Xpos + 1), Ypos] == 3 &&
                             array[(Xpos + 2), Ypos] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 2;
                        array[(Xpos), Ypos] = 2;
                        array[(Xpos + 1), Ypos] = 1;
                        array[(Xpos + 2), Ypos] = 3;
                        RefrescaPosdeJugador();
                    }
                }
                RefrescaTiles();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Refresca los Picture Boxes / Tiles acorde con el array
        /// </summary>
        private void RefrescaTiles()
        {
            int cont = 0;
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int xx = 0; xx < array.GetLength(1); xx++)
                {
                    if (array[i, xx] == 0)
                    {
                        if ((i == 0 && xx == 0) ||
                           (i == 0 && xx == MaxDer) ||
                           (i == MaxIzq && xx == MaxDer) ||
                           (i == MaxIzq && xx == 0))
                        {
                            boxes[cont].Image = Properties.Resources.corner;
                            cont++;
                        }
                        else if ((i != 0 && xx == 0) ||
                                 (i != 0 && xx == MaxDer))
                        {
                            boxes[cont].Image = Properties.Resources.bdhoriz;
                            cont++;
                        }
                        else if ((i == 0 && xx != 0) ||
                                (i == MaxIzq && xx != 0))
                        {
                            boxes[cont].Image = Properties.Resources.bd;
                            cont++;
                        }
                        else
                        {
                            boxes[cont].Image = Properties.Resources.isolatedtile;
                            cont++;
                        }
                    }
                    else if (array[i, xx] == 2)
                    {
                        boxes[cont].Image = Properties.Resources.terr;
                        cont++;
                    }
                    else if (array[i, xx] == 3)
                    {
                        boxes[cont].Image = Properties.Resources.block;
                        cont++;
                    }
                    else if (array[i, xx] == 1)
                    {
                        boxes[cont].Image = Properties.Resources.player;
                        cont++;
                    }
                    Console.Write(array[i, xx]);
                }
            }
            cont = 0;
            //rellenar hotspots
            foreach (var item in objectives)
            {
                Console.WriteLine("\nHOTSPOT X {0}, Y{1}", item.x, item.y);
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int xx = 0; xx < array.GetLength(1); xx++)
                    {
                        if (xx == Ypos && i == Xpos)
                        {
                            if (sentido == 1)
                            {
                                boxes[cont].Image = Properties.Resources.playerup;
                            }
                            else if (sentido == 2)
                            {
                                boxes[cont].Image = Properties.Resources.player;
                            }
                            else if (sentido == 3)
                            {
                                boxes[cont].Image = Properties.Resources.playerright;
                            }
                            else if (sentido == 4)
                            {
                                boxes[cont].Image = Properties.Resources.playerleft;
                            }
                            //boxes[cont].Image = Properties.Resources.player;
                            Console.WriteLine("ENTRO");
                            cont++;
                        }
                        else if (array[i, xx] == 3 && xx == item.x && i == item.y)
                        {
                            boxes[cont].Image = Properties.Resources.block;
                            cont++;
                        }
                        else if (xx == item.x && i == item.y)
                        {
                            boxes[cont].Image = Properties.Resources.hotspot;
                            cont++;
                        }
                        else
                        {
                            cont++;
                        }
                    }
                }
                cont = 0;
            }
            AnalizarGane();
        }

        /// <summary>
        /// Guarda el Mapa de recuperacion en memoria
        /// </summary>
        private void GurdarMapaRecuperacion()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int xx = 0; xx < array.GetLength(1); xx++)
                {
                    recoverymap.array[i, xx] = array[i, xx];
                }
            }
            objectivesrecovery.Clear();
            blocksrecovery.Clear();

            //oldXpos = Xpos;
            //oldYpos = Ypos;

            foreach (var item in objectives)
            {
                objectivesrecovery.Add(item);
            }
            foreach (var item in blocks)
            {
                blocksrecovery.Add(item);
            }
            istherearecovery = true;
        }

        private void AnalizarGane()
        {
            int cont = 0;
            foreach (var blk in blocks)
            {
                foreach (var obj in objectives)
                {
                    if (blk.x == obj.x && blk.y == obj.y)
                    {
                        cont++;
                    }

                }
            }
            if (cont == blocks.Count && cont == objectives.Count)
            {
                MessageBox.Show("GANO!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartSound();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int xx = 0; xx < array.GetLength(1); xx++)
                {
                    array[i, xx] = newarray2[i, xx];
                }
            }
            objectives.Clear();
            blocksrecovery.Clear();
            blocks.Clear();
            foreach (var item in blocks)
            {
                array[item.y, item.x] = 3;
                blocks.Add(item);
            }
            sentido = 2;
            RefrescaPosdeJugador();
            RefrescaTiles(); 
        }

    }
}
