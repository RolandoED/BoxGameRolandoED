namespace BoxGame
{
    partial class Ranks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ranks));
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblRanks = new System.Windows.Forms.Label();
            this.btnOrderbyNick = new System.Windows.Forms.Button();
            this.btnOrderbyScore = new System.Windows.Forms.Button();
            this.btnOrderbyRank = new System.Windows.Forms.Button();
            this.btnOrderbyNick2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOrderbyScore1 = new System.Windows.Forms.Button();
            this.btnOrderbyRank1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(573, 53);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(518, 453);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // lblRanks
            // 
            this.lblRanks.AutoSize = true;
            this.lblRanks.BackColor = System.Drawing.Color.SkyBlue;
            this.lblRanks.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanks.Location = new System.Drawing.Point(730, 23);
            this.lblRanks.Name = "lblRanks";
            this.lblRanks.Size = new System.Drawing.Size(200, 27);
            this.lblRanks.TabIndex = 4;
            this.lblRanks.Text = "Lista de Rankings";
            // 
            // btnOrderbyNick
            // 
            this.btnOrderbyNick.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyNick.Location = new System.Drawing.Point(330, 75);
            this.btnOrderbyNick.Name = "btnOrderbyNick";
            this.btnOrderbyNick.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyNick.TabIndex = 6;
            this.btnOrderbyNick.Text = "↑";
            this.btnOrderbyNick.UseVisualStyleBackColor = false;
            this.btnOrderbyNick.Click += new System.EventHandler(this.btnOrderbyNick_Click);
            // 
            // btnOrderbyScore
            // 
            this.btnOrderbyScore.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyScore.Location = new System.Drawing.Point(406, 74);
            this.btnOrderbyScore.Name = "btnOrderbyScore";
            this.btnOrderbyScore.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyScore.TabIndex = 7;
            this.btnOrderbyScore.Text = "↑";
            this.btnOrderbyScore.UseVisualStyleBackColor = false;
            this.btnOrderbyScore.Click += new System.EventHandler(this.btnOrderbyScore_Click);
            // 
            // btnOrderbyRank
            // 
            this.btnOrderbyRank.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyRank.Location = new System.Drawing.Point(487, 74);
            this.btnOrderbyRank.Name = "btnOrderbyRank";
            this.btnOrderbyRank.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyRank.TabIndex = 8;
            this.btnOrderbyRank.Text = "↑";
            this.btnOrderbyRank.UseVisualStyleBackColor = false;
            this.btnOrderbyRank.Click += new System.EventHandler(this.btnOrderbyRank_Click);
            // 
            // btnOrderbyNick2
            // 
            this.btnOrderbyNick2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyNick2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyNick2.Location = new System.Drawing.Point(330, 122);
            this.btnOrderbyNick2.Name = "btnOrderbyNick2";
            this.btnOrderbyNick2.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyNick2.TabIndex = 9;
            this.btnOrderbyNick2.Text = "↓";
            this.btnOrderbyNick2.UseVisualStyleBackColor = false;
            this.btnOrderbyNick2.Click += new System.EventHandler(this.btnOrderbyNick2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Max Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SkyBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rank";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ordenar por: ";
            // 
            // btnOrderbyScore1
            // 
            this.btnOrderbyScore1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyScore1.Location = new System.Drawing.Point(406, 122);
            this.btnOrderbyScore1.Name = "btnOrderbyScore1";
            this.btnOrderbyScore1.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyScore1.TabIndex = 14;
            this.btnOrderbyScore1.Text = "↓";
            this.btnOrderbyScore1.UseVisualStyleBackColor = false;
            this.btnOrderbyScore1.Click += new System.EventHandler(this.btnOrderbyScore1_Click);
            // 
            // btnOrderbyRank1
            // 
            this.btnOrderbyRank1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOrderbyRank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderbyRank1.Location = new System.Drawing.Point(487, 122);
            this.btnOrderbyRank1.Name = "btnOrderbyRank1";
            this.btnOrderbyRank1.Size = new System.Drawing.Size(37, 37);
            this.btnOrderbyRank1.TabIndex = 15;
            this.btnOrderbyRank1.Text = "↓";
            this.btnOrderbyRank1.UseVisualStyleBackColor = false;
            this.btnOrderbyRank1.Click += new System.EventHandler(this.btnOrderbyRank1_Click);
            // 
            // Ranks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1111, 624);
            this.Controls.Add(this.btnOrderbyRank1);
            this.Controls.Add(this.btnOrderbyScore1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrderbyNick2);
            this.Controls.Add(this.btnOrderbyRank);
            this.Controls.Add(this.btnOrderbyScore);
            this.Controls.Add(this.btnOrderbyNick);
            this.Controls.Add(this.lblRanks);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ranks";
            this.Text = "Ranks";
            this.Load += new System.EventHandler(this.Ranks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblRanks;
        private System.Windows.Forms.Button btnOrderbyNick;
        private System.Windows.Forms.Button btnOrderbyScore;
        private System.Windows.Forms.Button btnOrderbyRank;
        private System.Windows.Forms.Button btnOrderbyNick2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOrderbyScore1;
        private System.Windows.Forms.Button btnOrderbyRank1;

    }
}