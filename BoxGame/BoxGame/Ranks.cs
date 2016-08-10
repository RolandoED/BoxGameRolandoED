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
            try
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
            }
            catch (SqlException ex)
            {
                //STACKTRACE
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("number" + ex.Number);
            }

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderbyNick_Click(object sender, EventArgs e)
        {
            OrderByNick("asc");
        }

        private void btnOrderbyNick2_Click(object sender, EventArgs e)
        {
            OrderByNick("desc");
        }

        private void btnOrderbyScore_Click(object sender, EventArgs e)
        {
            OrderByMaxScore("desc");
        }

        private void btnOrderbyScore1_Click(object sender, EventArgs e)
        {
            OrderByMaxScore("asc");
        }

        private void btnOrderbyRank_Click(object sender, EventArgs e)
        {
            OrderByRank("desc");
        }

        private void btnOrderbyRank1_Click(object sender, EventArgs e)
        {
            OrderByRank("asc");
        }

        private void OrderByNick(string modo) {
            try
            {
                string sqlquery;
                if (modo.Equals("asc"))
                {
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY NICK ASC;";
                }
                else
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY NICK DESC;";
                listView1.Items.Clear();
                string conexion = "Data Source=(local); " +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                DataTable dt = new DataTable();
                ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
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
                    listView1.Items.Add(listitem);
                }
            }
            catch (SqlException ex)
            {
                //STACKTRACE
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("number" + ex.Number);
            }
        }

        private void OrderByRank(string modo) {
            try
            {
                string sqlquery;
                if (modo.Equals("asc"))
                {
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY RANK ASC;";
                }
                else
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY RANK DESC;";
                listView1.Items.Clear();
                string conexion = "Data Source=(local); " +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                DataTable dt = new DataTable();
                ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
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
                    listView1.Items.Add(listitem);
                }
            }
            catch (SqlException ex)
            {
                //STACKTRACE
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("number" + ex.Number);
            }
        
        }

        private void OrderByMaxScore(string modo)
        {
            try
            {
                string sqlquery;
                if (modo.Equals("asc"))
                {
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY MAXSCORE ASC;";
                }
                else
                    sqlquery = "SELECT TOP 20 NICK , MAXSCORE, RANK  FROM PLAYER ORDER BY MAXSCORE DESC;";
                listView1.Items.Clear();
                string conexion = "Data Source=(local); " +
                    "Initial Catalog=Sokoban;" +
                    "Integrated Security=True;";
                DataTable dt = new DataTable();
                ///Seleccionar todo desde Jugador donde la puntuacion sea mayor
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
                    listView1.Items.Add(listitem);
                }
            }
            catch (SqlException ex)
            {
                //STACKTRACE
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
                Console.WriteLine("number" + ex.Number);
            }

        }

    }
}
