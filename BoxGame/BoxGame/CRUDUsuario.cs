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
            FillDataGridView();
        }

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

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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


    }
}
