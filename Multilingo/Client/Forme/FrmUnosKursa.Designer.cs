namespace Client.Forme
{
    partial class FrmUnosKursa
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
            this.txtJezik = new System.Windows.Forms.TextBox();
            this.txtNivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numBroj = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPon = new System.Windows.Forms.CheckBox();
            this.cbUto = new System.Windows.Forms.CheckBox();
            this.cbSre = new System.Windows.Forms.CheckBox();
            this.cbCet = new System.Windows.Forms.CheckBox();
            this.cbPet = new System.Windows.Forms.CheckBox();
            this.cbSub = new System.Windows.Forms.CheckBox();
            this.cbNed = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBroj)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJezik
            // 
            this.txtJezik.Location = new System.Drawing.Point(195, 49);
            this.txtJezik.Name = "txtJezik";
            this.txtJezik.Size = new System.Drawing.Size(143, 22);
            this.txtJezik.TabIndex = 0;
            // 
            // txtNivo
            // 
            this.txtNivo.Location = new System.Drawing.Point(195, 96);
            this.txtNivo.Name = "txtNivo";
            this.txtNivo.Size = new System.Drawing.Size(143, 22);
            this.txtNivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jezik:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Broj Raspolozivih Mesta:";
            // 
            // numBroj
            // 
            this.numBroj.Location = new System.Drawing.Point(195, 148);
            this.numBroj.Name = "numBroj";
            this.numBroj.Size = new System.Drawing.Size(143, 22);
            this.numBroj.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cbNed);
            this.groupBox1.Controls.Add(this.cbSub);
            this.groupBox1.Controls.Add(this.cbPet);
            this.groupBox1.Controls.Add(this.cbCet);
            this.groupBox1.Controls.Add(this.cbSre);
            this.groupBox1.Controls.Add(this.cbUto);
            this.groupBox1.Controls.Add(this.cbPon);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVreme);
            this.groupBox1.Location = new System.Drawing.Point(15, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 393);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Termini:";
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(180, 34);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(143, 22);
            this.txtVreme.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Vreme:";
            // 
            // cbPon
            // 
            this.cbPon.AutoSize = true;
            this.cbPon.Location = new System.Drawing.Point(180, 71);
            this.cbPon.Name = "cbPon";
            this.cbPon.Size = new System.Drawing.Size(100, 21);
            this.cbPon.TabIndex = 7;
            this.cbPon.Text = "Ponedeljak";
            this.cbPon.UseVisualStyleBackColor = true;
            // 
            // cbUto
            // 
            this.cbUto.AutoSize = true;
            this.cbUto.Location = new System.Drawing.Point(180, 98);
            this.cbUto.Name = "cbUto";
            this.cbUto.Size = new System.Drawing.Size(72, 21);
            this.cbUto.TabIndex = 8;
            this.cbUto.Text = "Utorak";
            this.cbUto.UseVisualStyleBackColor = true;
            // 
            // cbSre
            // 
            this.cbSre.AutoSize = true;
            this.cbSre.Location = new System.Drawing.Point(180, 125);
            this.cbSre.Name = "cbSre";
            this.cbSre.Size = new System.Drawing.Size(68, 21);
            this.cbSre.TabIndex = 9;
            this.cbSre.Text = "Sreda";
            this.cbSre.UseVisualStyleBackColor = true;
            // 
            // cbCet
            // 
            this.cbCet.AutoSize = true;
            this.cbCet.Location = new System.Drawing.Point(180, 152);
            this.cbCet.Name = "cbCet";
            this.cbCet.Size = new System.Drawing.Size(82, 21);
            this.cbCet.TabIndex = 10;
            this.cbCet.Text = "Cetvrtak";
            this.cbCet.UseVisualStyleBackColor = true;
            // 
            // cbPet
            // 
            this.cbPet.AutoSize = true;
            this.cbPet.Location = new System.Drawing.Point(180, 179);
            this.cbPet.Name = "cbPet";
            this.cbPet.Size = new System.Drawing.Size(66, 21);
            this.cbPet.TabIndex = 11;
            this.cbPet.Text = "Petak";
            this.cbPet.UseVisualStyleBackColor = true;
            // 
            // cbSub
            // 
            this.cbSub.AutoSize = true;
            this.cbSub.Location = new System.Drawing.Point(180, 206);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(75, 21);
            this.cbSub.TabIndex = 12;
            this.cbSub.Text = "Subota";
            this.cbSub.UseVisualStyleBackColor = true;
            // 
            // cbNed
            // 
            this.cbNed.AutoSize = true;
            this.cbNed.Location = new System.Drawing.Point(180, 233);
            this.cbNed.Name = "cbNed";
            this.cbNed.Size = new System.Drawing.Size(78, 21);
            this.cbNed.TabIndex = 13;
            this.cbNed.Text = "Nedelja";
            this.cbNed.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 617);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Sacuvaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(123, 289);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(123, 336);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pocetak:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kraj:";
            // 
            // FrmUnosKursa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 674);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numBroj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNivo);
            this.Controls.Add(this.txtJezik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUnosKursa";
            this.Text = "Unos Kursa";
            ((System.ComponentModel.ISupportInitialize)(this.numBroj)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJezik;
        private System.Windows.Forms.TextBox txtNivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBroj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbNed;
        private System.Windows.Forms.CheckBox cbSub;
        private System.Windows.Forms.CheckBox cbPet;
        private System.Windows.Forms.CheckBox cbCet;
        private System.Windows.Forms.CheckBox cbSre;
        private System.Windows.Forms.CheckBox cbUto;
        private System.Windows.Forms.CheckBox cbPon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}