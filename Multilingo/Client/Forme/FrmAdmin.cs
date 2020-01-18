﻿using System;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KontrolerKI.Instance.Logout();
            Dispose();
        }
    }
}
