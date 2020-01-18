namespace Client.Forme
{
    partial class FrmAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKursevi = new System.Windows.Forms.TabPage();
            this.tabPolaznici = new System.Windows.Forms.TabPage();
            this.dvgKursevi = new System.Windows.Forms.DataGridView();
            this.dvgPolaznici = new System.Windows.Forms.DataGridView();
            this.btnKUnos = new System.Windows.Forms.Button();
            this.btnKIzmena = new System.Windows.Forms.Button();
            this.btnKBrisanje = new System.Windows.Forms.Button();
            this.btnTermini = new System.Windows.Forms.Button();
            this.btnKPracenja = new System.Windows.Forms.Button();
            this.btnPIzmena = new System.Windows.Forms.Button();
            this.btnPBrisanje = new System.Windows.Forms.Button();
            this.btnPPracenja = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabKursevi.SuspendLayout();
            this.tabPolaznici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgKursevi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPolaznici)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKursevi);
            this.tabControl1.Controls.Add(this.tabPolaznici);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 407);
            this.tabControl1.TabIndex = 1;
            // 
            // tabKursevi
            // 
            this.tabKursevi.Controls.Add(this.btnKPracenja);
            this.tabKursevi.Controls.Add(this.btnTermini);
            this.tabKursevi.Controls.Add(this.btnKBrisanje);
            this.tabKursevi.Controls.Add(this.btnKIzmena);
            this.tabKursevi.Controls.Add(this.btnKUnos);
            this.tabKursevi.Controls.Add(this.dvgKursevi);
            this.tabKursevi.Location = new System.Drawing.Point(4, 25);
            this.tabKursevi.Name = "tabKursevi";
            this.tabKursevi.Padding = new System.Windows.Forms.Padding(3);
            this.tabKursevi.Size = new System.Drawing.Size(768, 378);
            this.tabKursevi.TabIndex = 0;
            this.tabKursevi.Text = "Kursevi";
            this.tabKursevi.UseVisualStyleBackColor = true;
            // 
            // tabPolaznici
            // 
            this.tabPolaznici.Controls.Add(this.btnPPracenja);
            this.tabPolaznici.Controls.Add(this.btnPBrisanje);
            this.tabPolaznici.Controls.Add(this.btnPIzmena);
            this.tabPolaznici.Controls.Add(this.dvgPolaznici);
            this.tabPolaznici.Location = new System.Drawing.Point(4, 25);
            this.tabPolaznici.Name = "tabPolaznici";
            this.tabPolaznici.Padding = new System.Windows.Forms.Padding(3);
            this.tabPolaznici.Size = new System.Drawing.Size(768, 378);
            this.tabPolaznici.TabIndex = 1;
            this.tabPolaznici.Text = "Polaznici";
            this.tabPolaznici.UseVisualStyleBackColor = true;
            // 
            // dvgKursevi
            // 
            this.dvgKursevi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgKursevi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgKursevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgKursevi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgKursevi.Location = new System.Drawing.Point(6, 6);
            this.dvgKursevi.MultiSelect = false;
            this.dvgKursevi.Name = "dvgKursevi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgKursevi.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgKursevi.RowTemplate.Height = 24;
            this.dvgKursevi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgKursevi.Size = new System.Drawing.Size(635, 366);
            this.dvgKursevi.TabIndex = 2;
            // 
            // dvgPolaznici
            // 
            this.dvgPolaznici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgPolaznici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgPolaznici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgPolaznici.DefaultCellStyle = dataGridViewCellStyle5;
            this.dvgPolaznici.Location = new System.Drawing.Point(6, 6);
            this.dvgPolaznici.MultiSelect = false;
            this.dvgPolaznici.Name = "dvgPolaznici";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgPolaznici.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dvgPolaznici.RowTemplate.Height = 24;
            this.dvgPolaznici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgPolaznici.Size = new System.Drawing.Size(635, 366);
            this.dvgPolaznici.TabIndex = 3;
            // 
            // btnKUnos
            // 
            this.btnKUnos.Location = new System.Drawing.Point(647, 6);
            this.btnKUnos.Name = "btnKUnos";
            this.btnKUnos.Size = new System.Drawing.Size(115, 30);
            this.btnKUnos.TabIndex = 3;
            this.btnKUnos.Text = "Unos";
            this.btnKUnos.UseVisualStyleBackColor = true;
            // 
            // btnKIzmena
            // 
            this.btnKIzmena.Location = new System.Drawing.Point(647, 42);
            this.btnKIzmena.Name = "btnKIzmena";
            this.btnKIzmena.Size = new System.Drawing.Size(115, 30);
            this.btnKIzmena.TabIndex = 4;
            this.btnKIzmena.Text = "Izmena";
            this.btnKIzmena.UseVisualStyleBackColor = true;
            // 
            // btnKBrisanje
            // 
            this.btnKBrisanje.Location = new System.Drawing.Point(647, 78);
            this.btnKBrisanje.Name = "btnKBrisanje";
            this.btnKBrisanje.Size = new System.Drawing.Size(115, 30);
            this.btnKBrisanje.TabIndex = 5;
            this.btnKBrisanje.Text = "Brisanje";
            this.btnKBrisanje.UseVisualStyleBackColor = true;
            // 
            // btnTermini
            // 
            this.btnTermini.Location = new System.Drawing.Point(647, 130);
            this.btnTermini.Name = "btnTermini";
            this.btnTermini.Size = new System.Drawing.Size(115, 30);
            this.btnTermini.TabIndex = 6;
            this.btnTermini.Text = "Termini";
            this.btnTermini.UseVisualStyleBackColor = true;
            // 
            // btnKPracenja
            // 
            this.btnKPracenja.Location = new System.Drawing.Point(647, 182);
            this.btnKPracenja.Name = "btnKPracenja";
            this.btnKPracenja.Size = new System.Drawing.Size(115, 30);
            this.btnKPracenja.TabIndex = 7;
            this.btnKPracenja.Text = "Pracenja";
            this.btnKPracenja.UseVisualStyleBackColor = true;
            // 
            // btnPIzmena
            // 
            this.btnPIzmena.Location = new System.Drawing.Point(647, 6);
            this.btnPIzmena.Name = "btnPIzmena";
            this.btnPIzmena.Size = new System.Drawing.Size(115, 30);
            this.btnPIzmena.TabIndex = 4;
            this.btnPIzmena.Text = "Izmena";
            this.btnPIzmena.UseVisualStyleBackColor = true;
            // 
            // btnPBrisanje
            // 
            this.btnPBrisanje.Location = new System.Drawing.Point(647, 42);
            this.btnPBrisanje.Name = "btnPBrisanje";
            this.btnPBrisanje.Size = new System.Drawing.Size(115, 30);
            this.btnPBrisanje.TabIndex = 5;
            this.btnPBrisanje.Text = "Brisanje";
            this.btnPBrisanje.UseVisualStyleBackColor = true;
            // 
            // btnPPracenja
            // 
            this.btnPPracenja.Location = new System.Drawing.Point(647, 100);
            this.btnPPracenja.Name = "btnPPracenja";
            this.btnPPracenja.Size = new System.Drawing.Size(115, 30);
            this.btnPPracenja.TabIndex = 6;
            this.btnPPracenja.Text = "Pracenja";
            this.btnPPracenja.UseVisualStyleBackColor = true;
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAdmin";
            this.Text = "FrmAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdmin_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabKursevi.ResumeLayout(false);
            this.tabPolaznici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgKursevi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPolaznici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKursevi;
        private System.Windows.Forms.TabPage tabPolaznici;
        private System.Windows.Forms.DataGridView dvgKursevi;
        private System.Windows.Forms.DataGridView dvgPolaznici;
        private System.Windows.Forms.Button btnTermini;
        private System.Windows.Forms.Button btnKBrisanje;
        private System.Windows.Forms.Button btnKIzmena;
        private System.Windows.Forms.Button btnKUnos;
        private System.Windows.Forms.Button btnKPracenja;
        private System.Windows.Forms.Button btnPIzmena;
        private System.Windows.Forms.Button btnPPracenja;
        private System.Windows.Forms.Button btnPBrisanje;
    }
}