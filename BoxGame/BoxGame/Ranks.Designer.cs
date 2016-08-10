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
            this.SuspendLayout();
            // 
            // listView1
            // 
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
            this.lblRanks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRanks.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanks.Location = new System.Drawing.Point(730, 23);
            this.lblRanks.Name = "lblRanks";
            this.lblRanks.Size = new System.Drawing.Size(200, 27);
            this.lblRanks.TabIndex = 4;
            this.lblRanks.Text = "Lista de Rankings";
            // 
            // btnOrderbyNick
            // 
            this.btnOrderbyNick.Location = new System.Drawing.Point(573, 513);
            this.btnOrderbyNick.Name = "btnOrderbyNick";
            this.btnOrderbyNick.Size = new System.Drawing.Size(75, 23);
            this.btnOrderbyNick.TabIndex = 6;
            this.btnOrderbyNick.Text = "NICK";
            this.btnOrderbyNick.UseVisualStyleBackColor = true;
            this.btnOrderbyNick.Click += new System.EventHandler(this.btnOrderbyNick_Click);
            // 
            // btnOrderbyScore
            // 
            this.btnOrderbyScore.Location = new System.Drawing.Point(654, 513);
            this.btnOrderbyScore.Name = "btnOrderbyScore";
            this.btnOrderbyScore.Size = new System.Drawing.Size(75, 23);
            this.btnOrderbyScore.TabIndex = 7;
            this.btnOrderbyScore.Text = "Score";
            this.btnOrderbyScore.UseVisualStyleBackColor = true;
            this.btnOrderbyScore.Click += new System.EventHandler(this.btnOrderbyScore_Click);
            // 
            // btnOrderbyRank
            // 
            this.btnOrderbyRank.Location = new System.Drawing.Point(735, 513);
            this.btnOrderbyRank.Name = "btnOrderbyRank";
            this.btnOrderbyRank.Size = new System.Drawing.Size(75, 23);
            this.btnOrderbyRank.TabIndex = 8;
            this.btnOrderbyRank.Text = "Rank";
            this.btnOrderbyRank.UseVisualStyleBackColor = true;
            this.btnOrderbyRank.Click += new System.EventHandler(this.btnOrderbyRank_Click);
            // 
            // Ranks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1111, 624);
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

    }
}