namespace BoxGame
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnLoguear = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.ckbxRegistered = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoguear
            // 
            this.btnLoguear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoguear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoguear.Location = new System.Drawing.Point(162, 229);
            this.btnLoguear.Name = "btnLoguear";
            this.btnLoguear.Size = new System.Drawing.Size(276, 67);
            this.btnLoguear.TabIndex = 0;
            this.btnLoguear.Text = "Loguear";
            this.btnLoguear.UseVisualStyleBackColor = false;
            this.btnLoguear.Click += new System.EventHandler(this.btnLoguear_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(164, 69);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(137, 20);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Nombre Completo";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(164, 126);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(79, 20);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Nickname";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(164, 94);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(273, 23);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Text = "Rolando2";
            // 
            // txtNickName
            // 
            this.txtNickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickName.Location = new System.Drawing.Point(164, 149);
            this.txtNickName.MaxLength = 10;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(273, 23);
            this.txtNickName.TabIndex = 4;
            this.txtNickName.Text = "Rol1";
            // 
            // ckbxRegistered
            // 
            this.ckbxRegistered.AutoSize = true;
            this.ckbxRegistered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbxRegistered.Location = new System.Drawing.Point(176, 187);
            this.ckbxRegistered.Name = "ckbxRegistered";
            this.ckbxRegistered.Size = new System.Drawing.Size(248, 24);
            this.ckbxRegistered.TabIndex = 5;
            this.ckbxRegistered.Text = "Ya estoy registrado, loguearme";
            this.ckbxRegistered.UseVisualStyleBackColor = true;
            this.ckbxRegistered.CheckedChanged += new System.EventHandler(this.ckbxRegistered_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoxGame.Properties.Resources.bgbright;
            this.ClientSize = new System.Drawing.Size(602, 431);
            this.Controls.Add(this.ckbxRegistered);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnLoguear);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Autenticacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoguear;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.CheckBox ckbxRegistered;
    }
}