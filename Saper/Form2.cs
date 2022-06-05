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
    public partial class Form2 : Form
    {
        MineField game;
        int seconds;
        int minutes;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(int heig, int wid, int difficulty)
        {
            InitializeComponent();
            this.Text = "Field " + heig.ToString() + "x" + wid.ToString();

            flowLayoutPanel1.Height = (heig * 20) + 2;
            flowLayoutPanel1.Width = (wid * 20) + 2;
            this.AutoSize = true;
            double temp = 0;
            temp = Math.Ceiling(heig * wid * (difficulty/100.0));
            if (difficulty == 99)
                temp--;
            game = new MineField(heig, wid, Convert.ToInt32(temp));
            BoardConstructor(heig, wid);
            timer1.Interval = 1000;

        }
        public void BtnTemp_Click(object sender, MouseEventArgs e)
        {
            Cell tempCell = (Cell)sender;
            if (e.Button == MouseButtons.Left && !tempCell.flag && !tempCell.opened && !Autoplay.Checked)
            {
                game.OpenCell(tempCell.x, tempCell.y);
                if (game.field[tempCell.x, tempCell.y].bomb)
                {
                    MessageBox.Show("Koniec gry");
                    this.Close();
                }
            }
            else if (e.Button == MouseButtons.Right && !Autoplay.Checked)
            {
                if (tempCell.opened == true)
                    ;
                else if (tempCell.opened == false)
                {
                    if (tempCell.flag == true)
                        tempCell.Image = null;
                    else if (tempCell.flag == false)
                        tempCell.Image = Image.FromFile(@"C:\Users\User\source\repos\Minesweeper\Minesweeper\flag.png");
                    tempCell.flag = !tempCell.flag;
                }
            }
            if (game.Win())
            {
                MessageBox.Show("Wygrałeś.");
                this.Close();
            }
        }
        public void BoardConstructor(int heig, int wid)
        {
            for (int i = 0; i < heig; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    Cell btnTemp = new Cell(i, j);

                    btnTemp.Name = "btnTemp" + i.ToString();
                    btnTemp.Size = new System.Drawing.Size(20, 20);
                    btnTemp.Margin = new Padding(0, 0, 0, 0);
                    btnTemp.UseVisualStyleBackColor = true;
                    btnTemp.FlatAppearance.BorderSize = 0;
                    btnTemp.MouseUp += BtnTemp_Click;

                    game.field[i, j] = btnTemp;
                    flowLayoutPanel1.Controls.Add(btnTemp);
                }

            }

            for (int i = 0; i < game.bombs; i++)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, heig);
                int y = rnd.Next(0, wid);
                while (game.field[x, y].bomb)
                {
                    x = rnd.Next(0, heig);
                    y = rnd.Next(0, wid);
                }
                game.field[x, y].bomb = true;
                //plansza.field[x, y].BackColor = Color.Red;
            }
            for (int i = 0; i < heig; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    game.CountBombs(i, j);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (seconds < 10)
            {
                if (minutes < 10)
                    textBox1.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                else
                    textBox1.Text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                if (minutes < 10)
                    textBox1.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
                else
                    textBox1.Text = minutes.ToString() + ":" + seconds.ToString();
            }
        }

        private void Tips_Click(object sender, EventArgs e)
        {
            Tips.Checked = !Tips.Checked;
            if (Tips.Checked)
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (game.field[i, j].opened)
                        {
                            if (game.field[i, j].number == 1)
                            {
                                game.Checker(i, j, true);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (!game.field[i, j].opened)
                        {
                            game.field[i, j].BackColor = default(Color);
                            game.field[i, j].UseVisualStyleBackColor = true;
                        }
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Tips.Checked)
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (game.field[i, j].opened)
                        {
                            game.Checker(i, j, true);
                        }
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!Autoplay.Checked)
                return;
            int counter = 0;
            for (int i = 0; i < game.height; i++)
            {
                for (int j = 0; j < game.width; j++)
                {
                    if (game.field[i, j].opened)
                    {
                        game.Checker(i, j, false);
                    }
                    else if (!game.field[i, j].opened && game.field[i, j].autoplayFlag == 3)
                    {
                        game.OpenCell(i, j);
                        counter++;
                    }
                }
            }
            if (game.Win())
            {
                timer3.Enabled = false;
                MessageBox.Show("Wygrałeś.");
                this.Close();
            }
            if (counter == 0)
            {
                Cell[] tempField = new Cell[game.height * game.width];
                int tempCounter = 0;
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (game.field[i, j].autoplayFlag != 2 && !game.field[i,j].opened)
                            tempField[tempCounter++] = game.field[i, j];
                    }
                }
                Random rnd = new Random();
                int randCell = rnd.Next(0, tempCounter);
                if(!game.Win())
                    game.OpenCell(tempField[randCell].x, tempField[randCell].y);
                if (tempField[randCell].bomb == true)
                {
                    timer3.Enabled = false;
                    MessageBox.Show("Koniec gry");
                    this.Close();
                }
                //int x = rnd.Next(0, plansza.wysokosc);
                //int y = rnd.Next(0, plansza.szerokosc);
                //if (!plansza.field[x, y].opened && plansza.field[x, y].autoplayFlag != 2)
                //{
                //    plansza.OpenCell(x, y);
                //    if (plansza.field[x, y].bomb == true)
                //        this.Close();
                //}
            }
        }

        private void Autoplay_Click(object sender, EventArgs e)
        {
            Autoplay.Checked = !Autoplay.Checked;
            if(!Autoplay.Checked)
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (!game.field[i, j].opened)
                        {
                            game.field[i, j].BackColor = default(Color);
                            game.field[i, j].UseVisualStyleBackColor = true;
                        }
                    }
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer3.Enabled = false;
        }

        private void NextMove_Click(object sender, EventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < game.height; i++)
            {
                for (int j = 0; j < game.width; j++)
                {
                    if (game.field[i, j].opened)
                    {
                        game.Checker(i, j, false);
                    }
                }
            }
            for (int i = 0; i < game.height; i++)
            {
                for (int j = 0; j < game.width; j++)
                {
                    if (!game.field[i, j].opened && game.field[i, j].autoplayFlag == 3)
                    {
                        game.OpenCell(i, j);
                        counter++;
                    }
                    if (counter > 0)
                        break;
                }
            }

            if (game.Win())
            {
                timer3.Enabled = false;
                MessageBox.Show("Wygrałeś.");
                this.Close();
            }
            if (counter == 0)
            {
                Cell[] tempField = new Cell[game.height * game.width];
                int tempCounter = 0;
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (game.field[i, j].autoplayFlag != 2 && !game.field[i, j].opened)
                            tempField[tempCounter++] = game.field[i, j];
                    }
                }
                Random rnd = new Random();
                int randCell = rnd.Next(0, tempCounter);
                if (!game.Win())
                    game.OpenCell(tempField[randCell].x, tempField[randCell].y);
                if (tempField[randCell].bomb == true)
                {
                    timer3.Enabled = false;
                    MessageBox.Show("Koniec gry");
                    this.Close();
                }
            }
        }
        private void ShowBombs_Click(object sender, EventArgs e)
        {
            ShowBombs.Checked = !ShowBombs.Checked;
            if (ShowBombs.Checked)
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if(game.field[i, j].bomb)
                            game.field[i, j].BackColor = Color.Purple;
                    }
                }
            }
            else
            {
                for (int i = 0; i < game.height; i++)
                {
                    for (int j = 0; j < game.width; j++)
                    {
                        if (!game.field[i, j].opened)
                        {
                            game.field[i, j].BackColor = default(Color);
                            game.field[i, j].UseVisualStyleBackColor = true;
                        }
                    }
                }
            }
        }
    }
}
