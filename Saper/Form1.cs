using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Run(new Form2());
            //int szerokosc = Convert.ToInt32(TBszer.Text);
            //int wysokosc = Convert.ToInt32(TBwys.Text);
            int szerokosc = 9, wysokosc = 9;
            if (Maly.Checked)
            {
                wysokosc = 9;
                szerokosc = 9;
            }
            else if (Sredni.Checked)
            {
                wysokosc = 16;
                szerokosc = 16;
            }
            else if (Duzy.Checked)
            {
                wysokosc = 25;
                szerokosc = 25;
            }
            else if (Custom.Checked)
            {
                try
                {
                    szerokosc = Convert.ToInt32(TBszer.Text);
                    wysokosc = Convert.ToInt32(TBwys.Text);
                    if (szerokosc < 2 || wysokosc < 2)
                        throw new FormatException();
                }
                catch(FormatException)
                {
                    szerokosc = 9;
                    wysokosc = 9;
                    MessageBox.Show("Wprowadzono niewłaściwe dane. Rozmiar został ustawiony na mały.");
                }
            }
            int difficulty = trackBar1.Value;
            if (difficulty == 1)
                difficulty = 10;
            if (difficulty == 2)
                difficulty = 17;
            if (difficulty == 3)
                difficulty = 25;
            if (difficulty == 4)
                difficulty = Convert.ToInt32(customDifficulty.Value);
            Form2 plansza = new Form2(wysokosc, szerokosc, difficulty);
            plansza.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Custom_CheckedChanged(object sender, EventArgs e)
        {
            TBszer.Visible = !TBszer.Visible;
            TBwys.Visible = !TBwys.Visible;
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if(trackBar1.Value == 4)
            {
                DifficultyLabel.Visible = true;
                DifficultyLabel.Enabled = true;
                customDifficulty.Visible = true;
                customDifficulty.Enabled = true;
            }
            else
            {
                DifficultyLabel.Visible = false;
                DifficultyLabel.Enabled = false;
                customDifficulty.Visible = false;
                customDifficulty.Enabled = false;
            }
        }
    }
}
