using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguageTransformation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static Form1 CurrentActiveForm1
        {
            get
            {
                return preForm1;
            }
            set
            {
                preForm1 = value;
            }
        }

        private static Form1 preForm1 = null;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (preForm1 == null)
            {
                preForm1 = new Form1();
                preForm1.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
