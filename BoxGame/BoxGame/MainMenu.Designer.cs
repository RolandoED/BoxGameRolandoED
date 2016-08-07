﻿namespace BoxGame
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNuevoJugador = new System.Windows.Forms.Button();
            this.btnEditorNiveles = new System.Windows.Forms.Button();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnRankins = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCRUDUsuarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevoJugador
            // 
            this.btnNuevoJugador.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNuevoJugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoJugador.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNuevoJugador.Location = new System.Drawing.Point(12, 22);
            this.btnNuevoJugador.Name = "btnNuevoJugador";
            this.btnNuevoJugador.Size = new System.Drawing.Size(281, 73);
            this.btnNuevoJugador.TabIndex = 0;
            this.btnNuevoJugador.Text = "Nuevo Jugador";
            this.btnNuevoJugador.UseVisualStyleBackColor = false;
            this.btnNuevoJugador.Click += new System.EventHandler(this.btnNuevoJugador_Click);
            // 
            // btnEditorNiveles
            // 
            this.btnEditorNiveles.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditorNiveles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditorNiveles.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditorNiveles.Location = new System.Drawing.Point(12, 338);
            this.btnEditorNiveles.Name = "btnEditorNiveles";
            this.btnEditorNiveles.Size = new System.Drawing.Size(281, 73);
            this.btnEditorNiveles.TabIndex = 1;
            this.btnEditorNiveles.Text = "Editor De Niveles";
            this.btnEditorNiveles.UseVisualStyleBackColor = false;
            this.btnEditorNiveles.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJugar.Location = new System.Drawing.Point(12, 101);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(281, 73);
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnRankins
            // 
            this.btnRankins.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRankins.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRankins.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRankins.Location = new System.Drawing.Point(12, 180);
            this.btnRankins.Name = "btnRankins";
            this.btnRankins.Size = new System.Drawing.Size(281, 73);
            this.btnRankins.TabIndex = 3;
            this.btnRankins.Text = "Ver Ranking";
            this.btnRankins.UseVisualStyleBackColor = false;
            this.btnRankins.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSalir.Location = new System.Drawing.Point(12, 259);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(281, 73);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Guardar y Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BoxGame.Properties.Resources.titlesmall;
            this.pictureBox2.Location = new System.Drawing.Point(418, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(536, 111);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BoxGame.Properties.Resources.Animation;
            this.pictureBox1.Location = new System.Drawing.Point(472, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 323);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnCRUDUsuarios
            // 
            this.btnCRUDUsuarios.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCRUDUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCRUDUsuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCRUDUsuarios.Location = new System.Drawing.Point(12, 417);
            this.btnCRUDUsuarios.Name = "btnCRUDUsuarios";
            this.btnCRUDUsuarios.Size = new System.Drawing.Size(281, 73);
            this.btnCRUDUsuarios.TabIndex = 8;
            this.btnCRUDUsuarios.Text = "Mantenimiento Usuarios";
            this.btnCRUDUsuarios.UseVisualStyleBackColor = false;
            this.btnCRUDUsuarios.Click += new System.EventHandler(this.btnCRUDUsuarios_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 505);
            this.Controls.Add(this.btnCRUDUsuarios);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRankins);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.btnEditorNiveles);
            this.Controls.Add(this.btnNuevoJugador);
            this.Name = "MainMenu";
            this.Text = "Sokoban";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoJugador;
        private System.Windows.Forms.Button btnEditorNiveles;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnRankins;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCRUDUsuarios;
    }
}

