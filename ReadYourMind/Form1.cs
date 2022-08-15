using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadYourMind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SortedDictionary<int, List<int>> DicBase = new SortedDictionary<int, List<int>>();

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            StringBuilder strB = new StringBuilder();
            int[] arrValue = { 32, 16, 8, 4, 2, 1 };
            foreach (int value in arrValue) { 
                DicBase.Add(value, new List<int>());

            }

            for (i = 1; i <= 52; i++)
            {
                int iTempValue = i;
                foreach (int Consistvalue in DicBase.Keys.OrderByDescending(x=>x))
                {
                    if(Consistvalue <= iTempValue)
                    {
                        DicBase[Consistvalue].Add(i);
                        iTempValue -= Consistvalue;
                    }
                }
                
            }
           
            foreach (int key in DicBase.Keys.OrderByDescending (x=>x))
            {
                strB.Append(key).Append(Environment.NewLine);
                for (i = 0; i < DicBase[key].Count; i++)
                {
                    strB.Append(DicBase[key][i])
                        .Append(",");
                }
                strB.Append(Environment.NewLine);
            }
            this.textBox1.Text  = strB.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

           // list.Add (new Set (2,)
        }
        Game game = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Paint -= PictureBox1_Paint;
            this.pictureBox1.Paint += PictureBox1_Paint;
            game = new Game();
            game.NewGame();
        }
        private int GetCardNumberRow(int CardValue)
        {
            return CardValue / 13;
        }
        private void DrawCardSet(Set set, Graphics g)
        {
            int i;
            int CardWidth = 72;
            int CardHeight = 96;
            int SpaceWidthBetweenCard = 20;
            Dictionary<int, int> CurrentColumn = new Dictionary<int, int>();
            CurrentColumn.Add(0, 0);
            CurrentColumn.Add(1, 0);
            CurrentColumn.Add(2, 0);
            CurrentColumn.Add(3, 0);

            for (i = 0; i < set.listNumber.Count; i++)
            {
                int CardValue = set.listNumber[i];
                int RowNumber = GetCardNumberRow(CardValue + 1);
                if(RowNumber == 4)
                {
                    RowNumber = 3;
                }
                Point point = new Point((CardWidth + SpaceWidthBetweenCard) * CurrentColumn [RowNumber],
                                        (CardHeight + SpaceWidthBetweenCard ) * RowNumber);

                CurrentColumn[RowNumber]++;

                g.DrawImage(BitMapCache.GetImageForCard(CardValue), point);
            }
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            if(game.IsThereAnyotherCardLeft)
            {
                DrawCardSet(game.CurrentSet, e.Graphics);
            }
        }
    }
}
