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
using System.Data.Sql;
using System.Data.SqlClient;

namespace BoxGame
{
    public partial class Ranks : Form
    {
        public Ranks()
        {
            InitializeComponent();
            listView1.Columns.Add("Nombre");
            listView1.Columns.Add("NivelActual");
            listView1.Columns.Add("Puntuacion");
            listView1.View = View.Details;
        }

        private void Ranks_Load(object sender, EventArgs e)
        {
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=Sokoban;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
            ////SELECT * FROM JUGADOR ORDER BY Puntuacion DESC
            //SELECT TOP number|percent column_name(s)
            //FROM table_name;
            sqlquery = "SELECT TOP 20 *  FROM JUGADOR ORDER BY Puntuacion DESC;";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            listView1.View = View.Details;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["NombreJugador"].ToString());
                listitem.SubItems.Add(dr["Nivel"].ToString());
                listitem.SubItems.Add(dr["Puntuacion"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                listView1.Items.Add(listitem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
