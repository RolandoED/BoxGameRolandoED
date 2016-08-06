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


namespace BoxGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ranks frm2 = new Ranks();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MapEditor editor = new MapEditor();
            editor.Show();
        }



        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);                
                //Si el archivo Is Admin existe, entra como administrador
                //AnalizarCuantosMapasHay();
                if (File.Exists(currentPath + "\\isadmin.txt"))
                {
                    ClaseGlobal.IsAdmin = true;
                    Console.WriteLine("The file exists.");
                }
                else
                {
                    btnEditorNiveles.Hide();
                    btnCRUDUsuarios.Hide();
                }
                }
            catch (IOException)
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (ClaseGlobal._UsuarioActual == null)
            {
                
            bool resul;
            string message = "";
            var result = MessageBox.Show("Desea Jugar sin Registrarse ?\nNo se Guardará su puntaje", "Aviso",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Game frmJuego = new Game();
                    frmJuego.Show();
                    //if (textBox1.Text != "")
                    //{
                    //    person1.Id = Convert.ToInt16(textBox1.Text);
                    //}
                    //person1.Name = textBox2.Text;
                    //person1.LastName = textBox3.Text;

                    //resul = person1.NewData(person1);
                    //if (resul == true)
                    //{
                    //    message = "Información guardada";
                    //}
                    //else
                    //{
                    //    message = "No se guardó la información, los registros están llenos";
                    //}
                    //result = MessageBox.Show(message, "Aviso",
                    //                     MessageBoxButtons.OK,
                    //                     MessageBoxIcon.Question);
                }
        }

        }

        private void btnCRUDUsuarios_Click(object sender, EventArgs e)
        {
            CRUDUsuario crudUser = new CRUDUsuario();
            crudUser.Show();
        }

        private void btnNuevoJugador_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
    }
}
