using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Saper
{
    class Cell : Button
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool bomb { get; set; }
        public short number { get; set; }
        public bool opened { get; set; }
        public bool flag { get; set; }
        //0 - default
        //1 - unknown
        //2 - bomb
        //3 - safe
        public short autoplayFlag { get; set; }
        public Cell()
        {
            bomb = false;
            number = 0;
            opened = false;
            flag = false;
        }
        public Cell(int _x, int _y)
        {
            bomb = false;
            number = 0;
            opened = false;
            flag = false;
            x = _x; y = _y;
        }
        public void Open()
        {
            opened = true;
            FlatStyle = FlatStyle.Flat;
            if (bomb)
            {
                Text = null;
                Image = Image.FromFile(@"..\..\bomb.jpg");
            }
            else
            {
                switch (number)
                {
                    case 1:
                        ForeColor = Color.Blue;
                        break;
                    case 2:
                        ForeColor = Color.Cyan;
                        break;
                    case 3:
                        ForeColor = Color.Red;
                        break;
                    case 4:
                        ForeColor = Color.Yellow;
                        break;
                    case 5:
                        ForeColor = Color.Green;
                        break;
                    case 6:
                        ForeColor = Color.Magenta;
                        break;
                    case 7:
                        ForeColor = Color.DarkCyan;
                        break;
                    case 8:
                        ForeColor = Color.Orange;
                        break;
                }
                if (number != 0)
                    Text = Convert.ToString(number);
                BackColor = Color.DarkGray;
            }
            //Enabled = false;
        }
    }
}
