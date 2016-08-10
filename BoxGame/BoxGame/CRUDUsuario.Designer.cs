namespace BoxGame
{
    partial class CRUDUsuario
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
            this.dgvDatosJugadores = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.txtMaxscore = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardarEnTexto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosJugadores
            // 
            this.dgvDatosJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosJugadores.Location = new System.Drawing.Point(134, 232);
            this.dgvDatosJugadores.Name = "dgvDatosJugadores";
            this.dgvDatosJugadores.Size = new System.Drawing.Size(632, 217);
            this.dgvDatosJugadores.TabIndex = 0;
            this.dgvDatosJugadores.SelectionChanged += new System.EventHandler(this.dgvDatosJugadores_SelectionChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(170, 29);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(58, 20);
            this.txtID.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(170, 75);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(170, 118);
            this.txtNickName.MaxLength = 10;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(137, 20);
            this.txtNickName.TabIndex = 3;
            // 
            // txtMaxscore
            // 
            this.txtMaxscore.Location = new System.Drawing.Point(170, 161);
            this.txtMaxscore.Name = "txtMaxscore";
            this.txtMaxscore.Size = new System.Drawing.Size(58, 20);
            this.txtMaxscore.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(170, 10);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(19, 17);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Id";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(170, 55);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(58, 17);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Nombre";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(170, 98);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(70, 17);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "Nickname";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(170, 141);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(70, 17);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "MaxScore";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(170, 183);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(41, 17);
            this.lbl5.TabIndex = 10;
            this.lbl5.Text = "Rank";
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(170, 203);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(58, 20);
            this.txtRank.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(363, 52);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(145, 46);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(363, 104);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(145, 46);
            this.btnBorrar.TabIndex = 12;
            this.btnBorrar.Text = "Eliminar por ID";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnEliminarporID_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(363, 156);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(145, 46);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnGuardarEnTexto
            // 
            this.btnGuardarEnTexto.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardarEnTexto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarEnTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEnTexto.Location = new System.Drawing.Point(514, 156);
            this.btnGuardarEnTexto.Name = "btnGuardarEnTexto";
            this.btnGuardarEnTexto.Size = new System.Drawing.Size(196, 46);
            this.btnGuardarEnTexto.TabIndex = 14;
            this.btnGuardarEnTexto.Text = "Guardar Usuarios en Archivo de Texto";
            this.btnGuardarEnTexto.UseVisualStyleBackColor = false;
            this.btnGuardarEnTexto.Click += new System.EventHandler(this.btnGuardarEnTexto_Click);
            // 
            // CRUDUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = global::BoxGame.Properties.Resources.bgedit___upsidedown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(918, 493);
            this.Controls.Add(this.btnGuardarEnTexto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtMaxscore);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dgvDatosJugadores);
            this.Name = "CRUDUsuario";
            this.Text = "Mantenimiento Usuarios";
            this.Load += new System.EventHandler(this.CRUDUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosJugadores;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.TextBox txtMaxscore;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardarEnTexto;
    }
}