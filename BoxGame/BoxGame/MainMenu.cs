﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}