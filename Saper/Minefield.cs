using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    class MineField
    {
        public Cell[,] field;
        public int height;
        public int width;
        public int winCounter;
        public int bombs;
        public MineField(int heig, int wid, int bom)
        {
            height = heig;
            width = wid;
            bombs = bom;
            winCounter = 0;
            field = new Cell[heig, wid];
        }
        public bool Win()
        {
            //Jeżeli zostaną odkryte wszystkie pola poza bombami, to gracz wygrywa
            if (winCounter == (height * width) - bombs)
            {
                return true;
            }
            return false;
        }
        public void OpenCell(int x, int y)
        {
            //Otwierana jest komórka, następnie otwarta komórka jest dodawana do licznika
            //ostatecznie, może być zainicjowane otwieranie następnych komórek
            field[x, y].Open();
            winCounter++;
            if (field[x, y].number == 0)
                Opener(x, y);
        }
        public void Opener(int x, int y)
        {
            //Otwieranie kolejnych komórek od góry i zgodnie ze wskazówkami zegara
            //Górny
            if (Neighbour(x - 1, y))
                OpenCell(x - 1, y);
            //Prawy górny
            if (Neighbour(x - 1, y + 1))
                OpenCell(x - 1, y + 1);
            //Prawy
            if (Neighbour(x, y + 1))
                OpenCell(x, y + 1);
            //Prawy dolny
            if (Neighbour(x + 1, y + 1))
                OpenCell(x + 1, y + 1);
            //Dolny
            if (Neighbour(x + 1, y))
                OpenCell(x + 1, y);
            //Lewy dolny
            if (Neighbour(x + 1, y - 1))
                OpenCell(x + 1, y - 1);
            //Lewy
            if (Neighbour(x, y - 1))
                OpenCell(x, y - 1);
            //Lewy górny
            if (Neighbour(x - 1, y - 1))
                OpenCell(x - 1, y - 1);
        }
        public void CountBombs(int x, int y)
        {
            //Liczenie bomb
            if (!field[x, y].bomb)
            {
                if (BombNeighbour(x - 1, y))
                    field[x, y].number++;
                //Prawy górny
                if (BombNeighbour(x - 1, y + 1))
                    field[x, y].number++;
                //Prawy
                if (BombNeighbour(x, y + 1))
                    field[x, y].number++;
                //Prawy dolny
                if (BombNeighbour(x + 1, y + 1))
                    field[x, y].number++;
                //Dolny
                if (BombNeighbour(x + 1, y))
                    field[x, y].number++;
                //Lewy dolny
                if (BombNeighbour(x + 1, y - 1))
                    field[x, y].number++;
                //Lewy
                if (BombNeighbour(x, y - 1))
                    field[x, y].number++;
                //Lewy górny
                if (BombNeighbour(x - 1, y - 1))
                    field[x, y].number++;
            }
            else
                field[x, y].number = 9;
        }
        public bool Neighbour(int x, int y)
        {
            //Sprawdzanie czy komórka o danych współrzędnych leży w granicach planszy
            if (x < 0 || y < 0)
                return false;
            if (x >= height || y >= width)
                return false;
            if (field[x, y].opened)
                return false;
            if (field[x, y].flag)
                return false;
            return true;
        }
        public bool AutoplayNeighbour(int x, int y)
        {
            //Sprawdzanie czy komórka o danych współrzędnych leży w granicach planszy
            if (x < 0 || y < 0)
                return false;
            if (x >= height || y >= width)
                return false;
            if (field[x, y].opened)
                return false;
            return true;
        }
        public bool BombNeighbour(int x, int y)
        {
            //Sprawdzenie czy komórka o podanych współrzędnych leży na planszy oraz czy jest tam bomba
            if (x < 0 || y < 0)
                return false;
            if (x >= height || y >= width)
                return false;
            if (field[x, y].bomb)
                return true;
            return false;
        }
        public void ColorChanger(int x, int y, short flag, bool setColor)
        {
            if (field[x, y].autoplayFlag == 1 || field[x, y].autoplayFlag == 0)
                field[x, y].autoplayFlag = flag;
            if (setColor)
            {
                switch (field[x, y].autoplayFlag)
                {
                    case 1:
                        field[x, y].BackColor = System.Drawing.Color.Orange;
                        break;
                    case 2:
                        field[x, y].BackColor = System.Drawing.Color.OrangeRed;
                        break;
                    case 3:
                        field[x, y].BackColor = System.Drawing.Color.Green;
                        break;
                }
            }
        }
        public short AutoplayColor(int x, int y)
        {
            int num = field[x, y].number;
            int num2 = 0;
            //Górny
            if (AutoplayNeighbour(x - 1, y))
                if (!field[x - 1, y].opened)
                {
                    if (field[x - 1, y].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Prawy górny
            if (AutoplayNeighbour(x - 1, y + 1))
                if (!field[x - 1, y + 1].opened)
                {
                    if (field[x - 1, y + 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Prawy
            if (AutoplayNeighbour(x, y + 1))
                if (!field[x, y + 1].opened)
                {
                    if (field[x, y + 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Prawy dolny
            if (AutoplayNeighbour(x + 1, y + 1))
                if (!field[x + 1, y + 1].opened)
                {
                    if (field[x + 1, y + 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Dolny
            if (AutoplayNeighbour(x + 1, y))
                if (!field[x + 1, y].opened)
                {
                    if (field[x + 1, y].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Lewy dolny
            if (AutoplayNeighbour(x + 1, y - 1))
                if (!field[x + 1, y - 1].opened)
                {
                    if (field[x + 1, y - 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Lewy
            if (AutoplayNeighbour(x, y - 1))
                if (!field[x, y - 1].opened)
                {
                    if (field[x, y - 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            //Lewy górny
            if (AutoplayNeighbour(x - 1, y - 1))
                if (!field[x - 1, y - 1].opened)
                {
                    if (field[x - 1, y - 1].autoplayFlag == 2)
                        num2++;
                    num--;
                }
            if (num2 == field[x, y].number)
                return 3;
            if (num < 0)
                return 1;
            return 2;
        }
        public void Checker(int x, int y, bool setColor)
        {
            short color = AutoplayColor(x, y);
            //Górny
            if (AutoplayNeighbour(x - 1, y))
                if(!field[x - 1, y].opened)
                {
                    ColorChanger(x - 1, y, color, setColor);
                }
            //Prawy górny
            if (AutoplayNeighbour(x - 1, y + 1))
                if (!field[x - 1, y + 1].opened)
                {
                    ColorChanger(x - 1, y + 1, color, setColor);
                }
            //Prawy
            if (AutoplayNeighbour(x, y + 1))
                if (!field[x, y + 1].opened)
                {
                    ColorChanger(x, y + 1, color, setColor);
                }
            //Prawy dolny
            if (AutoplayNeighbour(x + 1, y + 1))
                if (!field[x + 1, y + 1].opened)
                {
                    ColorChanger(x + 1, y + 1, color, setColor);
                }
            //Dolny
            if (AutoplayNeighbour(x + 1, y))
                if (!field[x + 1, y].opened)
                {
                    ColorChanger(x + 1, y, color, setColor);
                }
            //Lewy dolny
            if (AutoplayNeighbour(x + 1, y - 1))
                if (!field[x + 1, y - 1].opened)
                {
                    ColorChanger(x + 1, y - 1, color, setColor);
                }
            //Lewy
            if (AutoplayNeighbour(x, y - 1))
                if (!field[x, y - 1].opened)
                {
                    ColorChanger(x, y - 1, color, setColor);
                }
            //Lewy górny
            if (AutoplayNeighbour(x - 1, y - 1))
                if (!field[x - 1, y - 1].opened)
                {
                    ColorChanger(x - 1, y - 1, color, setColor);
                }
        }
    }
}
