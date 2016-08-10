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
using System.Data.Sql;
using System.Data.SqlClient;

namespace BoxGame
{
   public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        internal ClaseGlobal ClaseGlobal
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void btnLoguear_Click(object sender, EventArgs e)
        {
            if (ckbxRegistered.Checked)
            {
                //Buscarlo y asignarlo a la clase global como usuario
                try
                {
                    string conexion = "Data Source=(local); " +
                        "Initial Catalog=Sokoban;" +
                        "Integrated Security=True;";
                    String query = "select * from PLAYER where NICK = '" + txtNickName.Text + "'; ";
                    SqlConnection con = new SqlConnection(conexion);
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dbr;
                    con.Open();

                    dbr = cmd.ExecuteReader();
                    int count = 0;
                    while (dbr.Read())
                    {
                        Usuario UsuarioEncontrado = new Usuario();
                        count = count + 1;
                        Console.WriteLine(dbr.GetString(1));
                        Console.WriteLine(dbr.GetString(2));
                        Console.WriteLine(dbr.GetInt64(3).ToString());
                        Console.WriteLine(dbr.GetInt64(4).ToString());
                        ClaseGlobal._UsuarioActual = UsuarioEncontrado;
                        ClaseGlobal._UsuarioActual.NAME = (dbr.GetString(1));
                        ClaseGlobal._UsuarioActual.NICK = (dbr.GetString(2));
                        ClaseGlobal._UsuarioActual.MAXSCORE = (dbr.GetInt64(3));
                        ClaseGlobal._UsuarioActual.RANK = (dbr.GetInt64(4));
                    }
                    if (count == 1)
                    {                        
                        Console.WriteLine("clas glob" + ClaseGlobal._UsuarioActual.NAME);
                        Console.WriteLine("clas glob" + ClaseGlobal._UsuarioActual.NICK);
                        Console.WriteLine("clas glob" + ClaseGlobal._UsuarioActual.MAXSCORE);
                        Console.WriteLine("clas glob" + ClaseGlobal._UsuarioActual.RANK);
                        ClaseGlobal.ShowText("Usuario Encontrado: " +
                            "\nName: " + ClaseGlobal._UsuarioActual.NAME+
                            "\nNick: " + ClaseGlobal._UsuarioActual.NICK+
                            "\nMax level: " + ClaseGlobal._UsuarioActual.MAXSCORE+
                            "\nRank: " + ClaseGlobal._UsuarioActual.RANK
                            );
                        this.Close();
                    }
                    else
                    {
                        ClaseGlobal.ShowMessage("No se encontró el Usuario");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        ClaseGlobal.ShowMessage("Ya existe un Usuario con el mismo NOMBRE ");
                    }
                    Console.WriteLine(ex.GetType());
                    Console.WriteLine(ex.Data);
                    Console.WriteLine(ex.Message);
                }

            }
            else {
                try
                {
                    //Ingresarlo a la base de datos asignarlo a la clase global y 
                    //asignarle ranking y maxscore 0
                    Console.WriteLine("por fuera");

                    string conexion = "Data Source=(local); " +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                    string sqlquery;
                    //'User ID=UserName;Password=Password;
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();
                    sqlquery = "insert into Player values (" +
                        " '" + txtNombre.Text + "'," +
                        "'" + txtNickName.Text + "'," +
                        " " + 0 + " ," +
                        " " + 0 + "); ";
                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    ClaseGlobal.ShowText("Guardado el Usuario exitosamente");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        ClaseGlobal.ShowMessage("Ya existe un Jugador con el NICKNAME : " + txtNickName.Text);
                    }
                    Console.WriteLine(ex.GetType());
                    Console.WriteLine(ex.Data);
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

       /// <summary>
       /// Si todos los Textbox estan llenos
       /// </summary>
       /// <returns></returns>
        private bool checkAllFields() {
            if (txtNickName.Text.Length > 3
                && txtNombre.Text.Length > 3)
            {
                return true;
            }
            else
                return false;        
        }

       /// <summary>
       /// Si ya esta registrado solo necesita el nick para loguearse
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ckbxRegistered_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxRegistered.Checked)
            {
                txtNombre.Text = string.Empty;
                txtNombre.Enabled = false;
            }
            else
                txtNombre.Enabled = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

   public class Class1
   {
   }
}
