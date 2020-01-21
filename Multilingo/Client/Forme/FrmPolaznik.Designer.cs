namespace Client.Forme
{
    partial class FrmPolaznik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPolaznik));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKursevi = new System.Windows.Forms.TabPage();
            this.tabPracenja = new System.Windows.Forms.TabPage();
            this.dvgKursevi = new System.Windows.Forms.DataGridView();
            this.btnKPonisti = new System.Windows.Forms.Button();
            this.btnKPretraga = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKursevi = new System.Windows.Forms.TextBox();
            this.btnOdaberi = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabKursevi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgKursevi)).BeginInit();
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
            this.tabControl1.Controls.Add(this.tabPracenja);
            this.tabControl1.Location = new System.Drawing.Point(13, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 406);
            this.tabControl1.TabIndex = 1;
            // 
            // tabKursevi
            // 
            this.tabKursevi.Controls.Add(this.btnOdaberi);
            this.tabKursevi.Controls.Add(this.btnKPonisti);
            this.tabKursevi.Controls.Add(this.btnKPretraga);
            this.tabKursevi.Controls.Add(this.label1);
            this.tabKursevi.Controls.Add(this.txtKursevi);
            this.tabKursevi.Controls.Add(this.dvgKursevi);
            this.tabKursevi.Location = new System.Drawing.Point(4, 25);
            this.tabKursevi.Name = "tabKursevi";
            this.tabKursevi.Padding = new System.Windows.Forms.Padding(3);
            this.tabKursevi.Size = new System.Drawing.Size(767, 377);
            this.tabKursevi.TabIndex = 0;
            this.tabKursevi.Text = "Kursevi";
            this.tabKursevi.UseVisualStyleBackColor = true;
            // 
            // tabPracenja
            // 
            this.tabPracenja.Location = new System.Drawing.Point(4, 25);
            this.tabPracenja.Name = "tabPracenja";
            this.tabPracenja.Padding = new System.Windows.Forms.Padding(3);
            this.tabPracenja.Size = new System.Drawing.Size(767, 377);
            this.tabPracenja.TabIndex = 1;
            this.tabPracenja.Text = "Pracenja";
            this.tabPracenja.UseVisualStyleBackColor = true;
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
            this.dvgKursevi.Location = new System.Drawing.Point(6, 52);
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
            this.dvgKursevi.Size = new System.Drawing.Size(635, 319);
            this.dvgKursevi.TabIndex = 3;
            // 
            // btnKPonisti
            // 
            this.btnKPonisti.Location = new System.Drawing.Point(406, 9);
            this.btnKPonisti.Name = "btnKPonisti";
            this.btnKPonisti.Size = new System.Drawing.Size(115, 30);
            this.btnKPonisti.TabIndex = 15;
            this.btnKPonisti.Text = "Ponisti";
            this.btnKPonisti.UseVisualStyleBackColor = true;
            // 
            // btnKPretraga
            // 
            this.btnKPretraga.Location = new System.Drawing.Point(285, 9);
            this.btnKPretraga.Name = "btnKPretraga";
            this.btnKPretraga.Size = new System.Drawing.Size(115, 30);
            this.btnKPretraga.TabIndex = 14;
            this.btnKPretraga.Text = "Pretraga";
            this.btnKPretraga.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pretraga:";
            // 
            // txtKursevi
            // 
            this.txtKursevi.Location = new System.Drawing.Point(79, 13);
            this.txtKursevi.Name = "txtKursevi";
            this.txtKursevi.Size = new System.Drawing.Size(200, 22);
            this.txtKursevi.TabIndex = 12;
            // 
            // btnOdaberi
            // 
            this.btnOdaberi.Location = new System.Drawing.Point(647, 52);
            this.btnOdaberi.Name = "btnOdaberi";
            this.btnOdaberi.Size = new System.Drawing.Size(115, 30);
            this.btnOdaberi.TabIndex = 16;
            this.btnOdaberi.Text = "Odaberi";
            this.btnOdaberi.UseVisualStyleBackColor = true;
            // 
            // FrmPolaznik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPolaznik";
            this.Text = "FrmPolaznik";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabKursevi.ResumeLayout(false);
            this.tabKursevi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgKursevi)).EndInit();
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
        private System.Windows.Forms.TabPage tabPracenja;
        private System.Windows.Forms.DataGridView dvgKursevi;
        private System.Windows.Forms.Button btnOdaberi;
        private System.Windows.Forms.Button btnKPonisti;
        private System.Windows.Forms.Button btnKPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKursevi;
    }
}