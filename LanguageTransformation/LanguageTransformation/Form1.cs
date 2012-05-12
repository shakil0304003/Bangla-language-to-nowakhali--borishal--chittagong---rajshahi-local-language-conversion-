using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageTransformation;

namespace LanguageTransformation
{
    public partial class Form1 : Form
    {
        private List<Panel> allPanel = new List<Panel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control p1 in panelDestination.Controls)
            {
                foreach (Control c1 in p1.Controls)
                {
                    if (c1.Name == "txt" + p1.Name)
                    {
                        TextBox tb =  c1 as TextBox;
                        tb.Text = Parser.Parser.Instance.LanguageTransformation(textBox1.Text, comboBox1.SelectedItem.ToString(), p1.Name);
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bangla":
                    clbTargetLanguage.Items.Clear();
                    clbTargetLanguage.Items.Add("Ctg");
                    clbTargetLanguage.Items.Add("Barishal");
                    clbTargetLanguage.Items.Add("Nowakhali");
                    //clbTargetLanguage.Items.Add("Rajshahi");
                    break;

                case "Chittagong":
                    clbTargetLanguage.Items.Clear();
                    clbTargetLanguage.Items.Add("Bangla");
                    clbTargetLanguage.Items.Add("Barishal");
                    clbTargetLanguage.Items.Add("Nowakhali");
                    //clbTargetLanguage.Items.Add("Rajshahi");
                    break;

                case "Barishal":
                    clbTargetLanguage.Items.Clear();
                    clbTargetLanguage.Items.Add("Ctg");
                    clbTargetLanguage.Items.Add("Bangla");
                    clbTargetLanguage.Items.Add("Nowakhali");
                    //clbTargetLanguage.Items.Add("Rajshahi");
                    break;

                case "Nowakhali":
                    clbTargetLanguage.Items.Clear();
                    clbTargetLanguage.Items.Add("Ctg");
                    clbTargetLanguage.Items.Add("Barishal");
                    clbTargetLanguage.Items.Add("Bangla");
                    //clbTargetLanguage.Items.Add("Rajshahi");
                    break;
                /*
                case "Rajshahi":
                    clbTargetLanguage.Items.Clear();
                    clbTargetLanguage.Items.Add("Ctg");
                    clbTargetLanguage.Items.Add("Barishal");
                    clbTargetLanguage.Items.Add("Nowakhali");
                    clbTargetLanguage.Items.Add("Bangla");
                    break;
                */
            }

            while (panelDestination.Controls.Count != 0)
            {
                panelDestination.Controls.RemoveAt(0);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2.CurrentActiveForm1 = null;
        }

        private void clbTargetLanguage_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                Panel pnl = new Panel();
                pnl.Name = clbTargetLanguage.SelectedItem.ToString();

                int Top = 0;

                foreach (Control p1 in panelDestination.Controls)
                {
                    if (p1.Top + p1.Height > Top)
                        Top = p1.Top + p1.Height;
                }

                Label lbl = new Label();
                lbl.Text = "Translate into: " + clbTargetLanguage.SelectedItem.ToString();
                lbl.Name = "La" + clbTargetLanguage.SelectedItem.ToString();
                lbl.Width = panelDestination.Width;

                TextBox tb = new TextBox();
                tb.Top = 25;
                tb.Width = panelDestination.Width;
                tb.Height = panelDestination.Height / 3 - 25;
                tb.Multiline = true;
                tb.ReadOnly = true;
                tb.Name = "txt" + clbTargetLanguage.SelectedItem.ToString();

                pnl.Controls.Add(lbl);
                pnl.Controls.Add(tb);

                pnl.Left = 0;
                pnl.Top = Top;
                pnl.Height = panelDestination.Height/3;
                pnl.Width = panelDestination.Width;
                panelDestination.Controls.Add(pnl);
            }
            else
            {
                string name = clbTargetLanguage.SelectedItem.ToString();
                int i = 0;
                int top = 0;
                int hight = 0;
                foreach (Control p1 in panelDestination.Controls)
                {
                    if (p1.Name == name)
                    {
                        top = p1.Top;
                        hight = p1.Height;
                        break;
                    }
                    i++;
                }
                panelDestination.Controls.RemoveAt(i);

                foreach (Control p1 in panelDestination.Controls)
                {
                    if (p1.Top > top)
                    {
                        p1.Top = p1.Top - hight;
                    }
                }
            }
        }
    }
}
