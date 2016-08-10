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
            listView1.Columns.Add("NICK");
            listView1.Columns.Add("MAXSCORE");
            listView1.Columns.Add("RANK");
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
            sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY  RANK DESC;";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            listView1.View = View.Details;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["NICK"].ToString());
                listitem.SubItems.Add(dr["MAXSCORE"].ToString());
                listitem.SubItems.Add(dr["RANK"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                listView1.Items.Add(listitem);
            }

            //FillDataGridView();
        }

        //private void FillDataGridView()
        //{
        //    string sqlquery;
        //    string conexion = "Data Source=(local); " +
        //        "Initial Catalog=Sokoban;" +
        //        "Integrated Security=True;";
        //    DataTable dt = new DataTable();
        //    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY  RANK DESC;";
        //    SqlConnection sqlconn = new SqlConnection(conexion);
        //    sqlconn.Open();
        //    SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
        //    sqlda.Fill(dt);
        //    sqlconn.Close();
        //    dataGridView1.DataSource = dt;
        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderbyNick_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=Sokoban;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
            sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY NICK DESC;";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            listView1.View = View.Details;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["NICK"].ToString());
                listitem.SubItems.Add(dr["MAXSCORE"].ToString());
                listitem.SubItems.Add(dr["RANK"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                listView1.Items.Add(listitem);
            }

            //FillDataGridView();
        }

        private void btnOrderbyScore_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=Sokoban;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
            sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY MAXSCORE DESC;";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            listView1.View = View.Details;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["NICK"].ToString());
                listitem.SubItems.Add(dr["MAXSCORE"].ToString());
                listitem.SubItems.Add(dr["RANK"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                listView1.Items.Add(listitem);
            }

            //FillDataGridView();
        }

        private void btnOrderbyRank_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=Sokoban;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
            sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY RANK DESC;";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            listView1.View = View.Details;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["NICK"].ToString());
                listitem.SubItems.Add(dr["MAXSCORE"].ToString());
                listitem.SubItems.Add(dr["RANK"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                listView1.Items.Add(listitem);
            }
        }

    }
}
