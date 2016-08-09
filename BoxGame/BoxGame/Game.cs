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
        public int currentMap = 0;
        public int maximumMap = 6;
        public int movimientos = 0;
        public int moviemientosbackup = 0;

        private int Xpos;
        private int Ypos;
        private int oldXpos = 0;
        private int oldYpos = 0;
        private int MaxDer = 9;
        private int MaxIzq = 9;
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

        public Game()
        {
            currentMap++;
            //Mapa.array = array;
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
            maximumMap = ClaseGlobal.AnalizarCuantosMapasHay();

            if (ClaseGlobal._UsuarioActual != null)
            {
                if (ClaseGlobal._UsuarioActual.MAXSCORE == 0)                
                {
                    ClaseGlobal._UsuarioActual.MAXSCORE = 1;
                    currentMap = 1;
                }
                else if(ClaseGlobal._UsuarioActual.MAXSCORE > maximumMap)
                {
                    ClaseGlobal._UsuarioActual.MAXSCORE = 1;
                    currentMap = 1;
                }
                else
                {
                    currentMap =  (int)(ClaseGlobal._UsuarioActual.MAXSCORE); 
                }
                CargaMapadesdeArchivo("map" + ClaseGlobal._UsuarioActual.MAXSCORE);

                lblUserNick.Text = ClaseGlobal._UsuarioActual.NICK;
            }
            else {
                currentMap = 1;
                CargaMapadesdeArchivo("map" + currentMap);
                lblUserNick.Hide();
                lblTexto3.Hide();
            }

            objectives.Clear();
            //recoverymap.array = Mapa.array;
            firstmap.array = Mapa.array;
            istherearecovery = false;
            RefrescaPosdeJugador();
            RefrescaTiles();

            Console.WriteLine("");
            int tamano = Mapa.array.GetLength(1);
            //Console.WriteLine(Mapa.array.GetLength(0));
            //MaxDer = Mapa.array.GetLength(1) - 1;
            //Console.WriteLine(Mapa.array.GetLength(1));
            //MaxIzq = Mapa.array.GetLength(0) - 1;
            Console.WriteLine("");
            //Guarda el mapa de recupercion
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    firstmap.array[i, xx] = Mapa.array[i, xx];                    
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

        public void BackSound()
        {
            Stream str = Properties.Resources.back;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        private void mostrarmovimientos() {
            lblMovs.Text = movimientos.ToString();
            lblMovsMap.Text = Mapa.MaxMovements.ToString();
            lblNivel.Text = "Nivel # " + currentMap;
            int doblemovs = Mapa.MaxMovements * 2;
            if (movimientos <= Mapa.MaxMovements)
            {
                btnStar1.Show();
                btnStar2.Show();
                btnStar3.Show();
            }
            else if (movimientos > Mapa.MaxMovements && movimientos <= doblemovs)
            {
                btnStar1.Show();
                btnStar2.Show();
                btnStar3.Hide();
            }
            else {
                btnStar1.Show();
                btnStar2.Hide();
                btnStar3.Hide();
            }
        }

        private void RefrescaPosdeJugador()
        {
            int x = 0;
            int y = 0;
            blocks.Clear();
            for (int i = 0; i < Mapa.array.GetLength(1); i++)
            {
                for (int xc = 0; xc < Mapa.array.GetLength(0); xc++)
                {
                    //salida +=
                    if (Mapa.array[xc, i] == 1)
                    {
                        x = xc;
                        y = i;
                    }
                    else if (Mapa.array[xc, i] == 4)
                    {
                        Objective guardar = new Objective(i, xc);
                        objectives.Add(guardar);
                        Mapa.array[xc, i] = 2;
                    }
                    else if (Mapa.array[xc, i] == 3)
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
                    if (Mapa.array[Xpos, (Ypos + 1)] == 2)
                    {
                        Console.WriteLine("Se mueve para Derecha");
                        WalkSound();
                        sentido = 3;
                        Mapa.array[Xpos, (Ypos + 1)] = 1;
                        Mapa.array[Xpos, (Ypos)] = 2;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
                    }
                    // si el cuadro es un bloque
                    else if (Mapa.array[Xpos, (Ypos + 1)] == 3 &&
                             Mapa.array[Xpos, (Ypos + 2)] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (Mapa.array[Xpos, (Ypos + 1)] == 3 &&
                             Mapa.array[Xpos, (Ypos + 2)] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 3;
                        Mapa.array[Xpos, (Ypos)] = 2;
                        Mapa.array[Xpos, (Ypos + 1)] = 1;
                        Mapa.array[Xpos, (Ypos + 2)] = 3;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
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
                    if (Mapa.array[Xpos, (Ypos - 1)] == 2)
                    {
                        Console.WriteLine("Se mueve para Izq");
                        WalkSound();
                        sentido = 4;
                        Mapa.array[Xpos, (Ypos - 1)] = 1;
                        Mapa.array[Xpos, (Ypos)] = 2;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
                    }
                    // si el cuadro es un bloque
                    else if (Mapa.array[Xpos, (Ypos - 1)] == 3 &&
                             Mapa.array[Xpos, (Ypos - 2)] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (Mapa.array[Xpos, (Ypos - 1)] == 3 &&
                             Mapa.array[Xpos, (Ypos - 2)] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 4;
                        Mapa.array[Xpos, (Ypos)] = 2;
                        Mapa.array[Xpos, (Ypos - 1)] = 1;
                        Mapa.array[Xpos, (Ypos - 2)] = 3;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
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
                    if (Mapa.array[(Xpos - 1), Ypos] == 2)
                    {
                        Console.WriteLine("Se mueve para Arriba");
                        WalkSound();
                        sentido = 1;
                        Mapa.array[(Xpos - 1), Ypos] = 1;
                        Mapa.array[(Xpos), Ypos] = 2;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
                    }
                    // si el cuadro es un bloque
                    else if (Mapa.array[(Xpos - 1), Ypos] == 3 &&
                             Mapa.array[(Xpos - 2), Ypos] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (Mapa.array[(Xpos - 1), Ypos] == 3 &&
                             Mapa.array[(Xpos - 2), Ypos] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 1;
                        Mapa.array[(Xpos), Ypos] = 2;
                        Mapa.array[(Xpos - 1), Ypos] = 1;
                        Mapa.array[(Xpos - 2), Ypos] = 3;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
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
                    if (Mapa.array[(Xpos + 1), Ypos] == 2)
                    {
                        Console.WriteLine("Se mueve para Arriba");
                        WalkSound();
                        sentido = 2;
                        Mapa.array[(Xpos + 1), Ypos] = 1;
                        Mapa.array[(Xpos), Ypos] = 2;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
                    }
                    // si el cuadro es un bloque
                    else if (Mapa.array[(Xpos + 1), Ypos] == 3 &&
                             Mapa.array[(Xpos + 2), Ypos] == 0)
                    {
                        Console.WriteLine("No se mueve");
                        BumpSound();
                        RefrescaPosdeJugador();
                    }
                    else if (Mapa.array[(Xpos + 1), Ypos] == 3 &&
                             Mapa.array[(Xpos + 2), Ypos] == 2)
                    {
                        Console.WriteLine("Mueve Bloque");
                        KickSound();
                        GurdarMapaRecuperacion();
                        sentido = 2;
                        Mapa.array[(Xpos), Ypos] = 2;
                        Mapa.array[(Xpos + 1), Ypos] = 1;
                        Mapa.array[(Xpos + 2), Ypos] = 3;
                        RefrescaPosdeJugador();
                        //Aumenta Moviemientos
                        movimientos++;
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
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    if (Mapa.array[i, xx] == 0)
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
                    else if (Mapa.array[i, xx] == 2)
                    {
                        boxes[cont].Image = Properties.Resources.terr;
                        cont++;
                    }
                    else if (Mapa.array[i, xx] == 3)
                    {
                        boxes[cont].Image = Properties.Resources.block;
                        cont++;
                    }
                    else if (Mapa.array[i, xx] == 1)
                    {
                        boxes[cont].Image = Properties.Resources.player;
                        cont++;
                    }
                    Console.Write(Mapa.array[i, xx]);
                }
            }
            cont = 0;
            //rellenar hotspots
            foreach (var item in objectives)
            {
                Console.WriteLine("\nHOTSPOT X {0}, Y{1}", item.x, item.y);
                for (int i = 0; i < Mapa.array.GetLength(0); i++)
                {
                    for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
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
                        else if (Mapa.array[i, xx] == 3 && xx == item.x && i == item.y)
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
            mostrarmovimientos();
        }

        /// <summary>
        /// Guarda el Mapa de recuperacion en memoria
        /// </summary>
        private void GurdarMapaRecuperacion()
        {
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
                    recoverymap.array[i, xx] = Mapa.array[i, xx];
                }
            }
            objectivesrecovery.Clear();
            blocksrecovery.Clear();

            moviemientosbackup = movimientos;
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
            //por cada bloque
            foreach (var blk in blocks)
            {
                //por cada objetivo
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
                mostrarmovimientos();

                Console.WriteLine("star 1 " + btnStar1.Visible);
                Console.WriteLine("star 2 " + btnStar2.Visible);
                Console.WriteLine("star 3 " + btnStar3.Visible);
                
                //Seleccion dependiendo de las estrellas obtenidas
                ///// Si Obtuvo :
                ///// 3 estrellas  25
                ///// 2 estrellas  10
                ///// 1 estrellas  5
                if (ClaseGlobal._UsuarioActual != null)
                {                    
                    if (btnStar3.Visible)
                    {
                        ClaseGlobal._UsuarioActual.RANK += 25;
                    }
                    else if (btnStar2.Visible && !btnStar3.Visible)
                    {
                        ClaseGlobal._UsuarioActual.RANK += 10;
                    }
                    else
                        ClaseGlobal._UsuarioActual.RANK += 5;
                Console.WriteLine("RANK : "+ ClaseGlobal._UsuarioActual.RANK);
                }

                

                MessageBox.Show("Ganó el nivel "+ (currentMap) +"!!!");
                /////Si gana el nivel y se puede avanzar por que existen más mapas
                if ((currentMap + 1) < maximumMap)
                {
                    currentMap++;
                    CargaMapadesdeArchivo("map" + currentMap);
                    objectives.Clear();
                    //recoverymap.array = Mapa.array;
                    firstmap.array = Mapa.array;
                    istherearecovery = false;
                    sentido = 2;
                    RefrescaPosdeJugador();
                    //Reinicia Moviemientos
                    movimientos = 0;
                    if (ClaseGlobal._UsuarioActual != null)
                    {
                        ClaseGlobal._UsuarioActual.MAXSCORE = currentMap;
                    }
                    RefrescaTiles();
                }
                else
                {
                    var result = MessageBox.Show("Ha alcanzado el Nivel Final del Juego "+
                        "\nDesea Volver a comenzar los mapas desde el primero?", "Aviso",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        currentMap = 1;
                        CargaMapadesdeArchivo("map" + currentMap);
                        objectives.Clear();
                        //recoverymap.array = Mapa.array;
                        firstmap.array = Mapa.array;
                        istherearecovery = false;
                        sentido = 2;
                        RefrescaPosdeJugador();
                        //Reinicia Moviemientos
                        movimientos = 0;
                        if (ClaseGlobal._UsuarioActual != null)
                        {
                            ClaseGlobal._UsuarioActual.MAXSCORE = currentMap;
                        }
                        RefrescaTiles();
                    }
                    else 
                        this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (istherearecovery)
            {
                BackSound();
                for (int i = 0; i < Mapa.array.GetLength(0); i++)
                {
                    for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                    {
                        Mapa.array[i, xx] = recoverymap.array[i, xx];
                    }
                }
                Xpos = oldXpos;
                Ypos = oldYpos;
                //objectives.Clear();
                blocks.Clear();
                blocksrecovery.Clear();
                sentido = 2;
                RefrescaPosdeJugador();
                movimientos = moviemientosbackup;
                RefrescaTiles();
            }
        }

        private void CargaMapadesdeArchivo(string mapname)
        {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
                using (Stream stream = File.Open(currentPath + "\\maps\\" + mapname, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var recuperado = (Map)bin.Deserialize(stream);
                    Mapa.array = recuperado.array;
                    Mapa.MaxMovements = recuperado.MaxMovements;
                    firstmap.array = recuperado.array;
                    GurdarMapaRecuperacion();
                }
                Console.WriteLine("Se leyo correctamente el archivo Binario");
                //txtIntentosActuales.Text = "" + Mapa.MaxMovements;
            }
            catch (IOException eexc)
            {
                ClaseGlobal.ShowMessage(eexc.Message);
            }
            finally
            {
                Mapa.printArray();
                PasarArrayAPictureBoxes();
            }
        }

         /// <summary>
        /// Pasa el Array Lógico de la clase a los picture boxes
        /// </summary>
        private void PasarArrayAPictureBoxes()
        {
            int position = 0;
            for (int i = 0; i < Mapa.array.GetLength(0); i++)
            {
                for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
                {
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //CargaMapadesdeArchivo(textBox1.Text);
            //objectives.Clear();
            ////recoverymap.array = Mapa.array;
            //firstmap.array = Mapa.array;
            //istherearecovery = false;
            //RefrescaPosdeJugador();
            //RefrescaTiles();


            //RestartSound();
            //for (int i = 0; i < Mapa.array.GetLength(0); i++)
            //{
            //    for (int xx = 0; xx < Mapa.array.GetLength(1); xx++)
            //    {
            //        Mapa.array[i, xx] = firstmap.array[i, xx];
            //    }
            //}
            //foreach (var item in objectives)
            //{
            //    Mapa.array[item.y, item.x] = 4;
            //}
            //objectives.Clear();
            //blocksrecovery.Clear();
            //blocks.Clear();
            //sentido = 2;
            //RefrescaPosdeJugador();
            //RefrescaTiles();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RestartSound();

            CargaMapadesdeArchivo("map" + currentMap);
            objectives.Clear();
            //recoverymap.array = Mapa.array;
            firstmap.array = Mapa.array;
            istherearecovery = false;
            sentido = 2;
            RefrescaPosdeJugador();
            //Reinicia Moviemientos
            movimientos = 0;
            RefrescaTiles();
        }

    }
}
