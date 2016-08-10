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
    public partial class CRUDUsuario : Form
    {
        public CRUDUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llena el grid vide con la info
        /// </summary>
        private void FillDataGridView()
        {
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=Sokoban;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            sqlquery = "SELECT * from Player";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dgvDatosJugadores.DataSource = dt;
        }

        private void CRUDUsuario_Load(object sender, EventArgs e)
        {
            //llena grid view
            FillDataGridView();
        }
        /// <summary>
        /// Pasa los datos del item seleccional del data grid view a los textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosJugadores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosJugadores.SelectedRows.Count > 0)
                {
                    txtID.Text = dgvDatosJugadores.SelectedRows[0].Cells[0].Value.ToString();
                    txtName.Text = dgvDatosJugadores.SelectedRows[0].Cells[1].Value.ToString();
                    txtNickName.Text = dgvDatosJugadores.SelectedRows[0].Cells[2].Value.ToString();
                    txtMaxscore.Text = dgvDatosJugadores.SelectedRows[0].Cells[3].Value.ToString();
                    txtRank.Text = dgvDatosJugadores.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error select all rows");
            }
        }

        /// <summary>
        /// Checkea todos los campos no vacios
        /// </summary>
        /// <returns></returns>
        private bool CheckAllFields()
        {
            if (txtID.Text.Length > 0 &&
                txtName.Text.Length > 0 &&
                txtNickName.Text.Length > 0 &&
                txtMaxscore.Text.Length > 0 &&
                txtRank.Text.Length > 0)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Checkea todos los campos excepto el ID
        /// Este metodo es para cuando se actualiza
        /// la info puesto que el ID es autoincrementable 
        /// y no es necesario para actualizar los datos que 
        /// como el campo de nick es UNIQUE en la base de datos
        /// no pueden haber repetidos
        /// </summary>
        /// <returns></returns>
        private bool CheckAllFieldsExceptID()
        {
            if (txtName.Text.Length > 0 &&
                txtNickName.Text.Length > 0 &&
                txtMaxscore.Text.Length > 0 &&
                txtRank.Text.Length > 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Agrega un usuario a la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsExceptID() == true)
                {
                    string conexion = "Data Source=(local); " +
                        "Initial Catalog=Sokoban;" +
                        "Integrated Security=True;";
                    string sqlquery;
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();
                    sqlquery =
                    "INSERT INTO Player " +
                    "VALUES ('" + txtName.Text + "', " +
                     "'"+txtNickName.Text + "', " +
                     txtMaxscore.Text + ", " +
                     txtRank.Text + " ) ;";
                    ;

                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();

                    FillDataGridView();
                }
                else
                {
                    throw new Exception("Campos requeridos Vacios");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    ClaseGlobal.ShowMessage("Ya existe un Jugador con el Nick " + txtNickName.Text);
                }
                else
                {
                    ClaseGlobal.ShowMessage("El formato de los Numeros Es Incorrecto");
                }
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("number" + ex.Number);
            }
        }

        /// <summary>
        /// Elimina el usuario por ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarporID_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Length > 0)
                {
                    string conexion =
                    "Data Source=(local);" +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                    string sqlquery;
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();
                    sqlquery =
                    "DELETE FROM Player WHERE " +
                    " ID = " + txtID.Text + ";";
                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();

                    FillDataGridView();
                }
                else
                    ClaseGlobal.ShowText("No se tiene ID para elminar el usuario");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    ClaseGlobal.ShowMessage("Ya existe un Jugador con el Nick " + txtNickName.Text);
                }
                else
                {
                    ClaseGlobal.ShowMessage("El formato de los Numeros Es Incorrecto");
                }
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("numbere" + ex.Number);
            }

        }

        /// <summary>
        /// Actualiza el usuario con los datos de los textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Length > 0 && CheckAllFields())
                {
                    string conexion =
                    "Data Source=(local);" +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                    string sqlquery;
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();

                    sqlquery =
                    "UPDATE Player " +
                    "SET NAME = '" + txtName.Text + "', " +
                    " NICK = '" + txtNickName.Text + "', " +
                    " MAXSCORE = " + txtMaxscore.Text + ", " +
                    " RANK = " + txtRank.Text + " " +
                    " WHERE ID = " + txtID.Text + ";";

                    Console.WriteLine("sql: " + sqlquery);
                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();

                    FillDataGridView();
                }
                else
                    ClaseGlobal.ShowText("No se tiene ID para elminar el usuario");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    ClaseGlobal.ShowMessage("Ya existe un Jugador con el Nick " + txtNickName.Text);
                }
                else
                {
                    ClaseGlobal.ShowMessage("El formato de los Numeros Es Incorrecto");
                }
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("numbere" + ex.Number);
            }
        }

        /// <summary>
        /// Guarda la tabla players a acrchivo de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarEnTexto_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlquery;
                string conexion = "Data Source=(local); " +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                DataTable dt = new DataTable();
                sqlquery = "SELECT * from Player";
                SqlConnection sqlconn = new SqlConnection(conexion);
                sqlconn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
                sqlda.Fill(dt);
                sqlconn.Close();
                //dataGridView1.DataSource = dt;

                string sendtosave = "\r\n";
                sendtosave += "---------------------------------------\r\n";
                sendtosave += "\t\tLista De Usuarios\r\n";
                sendtosave += "---------------------------------------\r\n";
                sendtosave += "\r\n";
                sendtosave += "Codigo\tNombre\tNick\tMaxScore\tRank";
                foreach (DataRow row in dt.Rows)
                {
                    sendtosave += "\r\n";
                    sendtosave += row["ID"].ToString();
                    sendtosave += "\t" + row["Name"].ToString();
                    sendtosave += "\t" + row["Nick"].ToString();
                    sendtosave += "\t" + row["Maxscore"].ToString();
                    sendtosave += "\t" + row["Rank"].ToString();
                }
                //Guarda el archivo
                Console.WriteLine(sendtosave);
                ClaseGlobal.guardarDoc("Listadeusuarios.txt", sendtosave);
                ClaseGlobal.ShowText("Guardado Lista de Jugadores a : \nListadeusuarios.txt");
            }
            catch (Exception es)
            {
                ClaseGlobal.ShowMessage(es.Message);
            }
        }


    }
}
