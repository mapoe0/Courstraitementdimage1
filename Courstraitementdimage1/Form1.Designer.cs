
namespace Courstraitementdimage1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.BtnNoirEtBlanc = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBin = new System.Windows.Forms.Button();
            this.tbSeuil = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.negBtn = new System.Windows.Forms.Button();
            this.histogrameBtn = new System.Windows.Forms.Button();
            this.recadrage = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.errosionBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeuil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSource
            // 
            this.pbSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSource.Location = new System.Drawing.Point(190, 68);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(256, 256);
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // BtnNoirEtBlanc
            // 
            this.BtnNoirEtBlanc.Location = new System.Drawing.Point(482, 26);
            this.BtnNoirEtBlanc.Name = "BtnNoirEtBlanc";
            this.BtnNoirEtBlanc.Size = new System.Drawing.Size(256, 23);
            this.BtnNoirEtBlanc.TabIndex = 1;
            this.BtnNoirEtBlanc.Text = "Noir et Blanc";
            this.BtnNoirEtBlanc.UseVisualStyleBackColor = true;
            this.BtnNoirEtBlanc.Click += new System.EventHandler(this.BtnNoirEtBlanc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(482, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(856, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnBin
            // 
            this.btnBin.Location = new System.Drawing.Point(856, 26);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(256, 23);
            this.btnBin.TabIndex = 4;
            this.btnBin.Text = "binariser";
            this.btnBin.UseVisualStyleBackColor = true;
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // tbSeuil
            // 
            this.tbSeuil.Location = new System.Drawing.Point(856, 365);
            this.tbSeuil.Maximum = 255;
            this.tbSeuil.Name = "tbSeuil";
            this.tbSeuil.Size = new System.Drawing.Size(256, 45);
            this.tbSeuil.TabIndex = 5;
            this.tbSeuil.Scroll += new System.EventHandler(this.tbSeuil_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(965, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "seuil: 127";
            // 
            // negBtn
            // 
            this.negBtn.Location = new System.Drawing.Point(482, 352);
            this.negBtn.Name = "negBtn";
            this.negBtn.Size = new System.Drawing.Size(256, 23);
            this.negBtn.TabIndex = 7;
            this.negBtn.Text = "Negative";
            this.negBtn.UseVisualStyleBackColor = true;
            this.negBtn.Click += new System.EventHandler(this.negBtn_Click);
            // 
            // histogrameBtn
            // 
            this.histogrameBtn.Location = new System.Drawing.Point(482, 401);
            this.histogrameBtn.Name = "histogrameBtn";
            this.histogrameBtn.Size = new System.Drawing.Size(256, 23);
            this.histogrameBtn.TabIndex = 8;
            this.histogrameBtn.Text = "Histograme";
            this.histogrameBtn.UseVisualStyleBackColor = true;
            this.histogrameBtn.Click += new System.EventHandler(this.histogrameBtn_Click);
            // 
            // recadrage
            // 
            this.recadrage.Location = new System.Drawing.Point(482, 455);
            this.recadrage.Name = "recadrage";
            this.recadrage.Size = new System.Drawing.Size(256, 23);
            this.recadrage.TabIndex = 9;
            this.recadrage.Text = "recadrage";
            this.recadrage.UseVisualStyleBackColor = true;
            this.recadrage.Click += new System.EventHandler(this.recadrage_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(482, 484);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(256, 256);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(1175, 68);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(256, 256);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "filtre moyenneur",
            "filtre passe bas",
            "filtre passe haut",
            "filtre laplacien",
            "filtre gradient"});
            this.listBox1.Location = new System.Drawing.Point(1259, 377);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 69);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // errosionBtn
            // 
            this.errosionBtn.Location = new System.Drawing.Point(856, 435);
            this.errosionBtn.Name = "errosionBtn";
            this.errosionBtn.Size = new System.Drawing.Size(256, 23);
            this.errosionBtn.TabIndex = 18;
            this.errosionBtn.Text = "Erosion";
            this.errosionBtn.UseVisualStyleBackColor = true;
            this.errosionBtn.Click += new System.EventHandler(this.errosionBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 782);
            this.Controls.Add(this.errosionBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.recadrage);
            this.Controls.Add(this.histogrameBtn);
            this.Controls.Add(this.negBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSeuil);
            this.Controls.Add(this.btnBin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnNoirEtBlanc);
            this.Controls.Add(this.pbSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeuil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.Button BtnNoirEtBlanc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnBin;
        private System.Windows.Forms.TrackBar tbSeuil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button negBtn;
        private System.Windows.Forms.Button histogrameBtn;
        private System.Windows.Forms.Button recadrage;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button errosionBtn;
    }
}

