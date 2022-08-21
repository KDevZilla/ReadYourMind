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
            this.pictureBox1.Height = yOffset * 2 + (CardHeight + SpaceWidthBetweenCard) * 4;
            this.pictureBox1.Width = xOffset * 2 + (CardWidth + SpaceWidthBetweenCard) * 13;

            game = new Game();
            game.NewGame();
        }
        private int GetCardNumberRow(int CardValue)
        {
            if(CardValue % 13 == 0)
            {
                return (CardValue / 13) - 1;
            }

            return CardValue / 13;
        }
        int CardWidth = 72;
        int CardHeight = 96;
        int SpaceWidthBetweenCard = 10;
        int xOffset = 15;
        int yOffset = 15;
        /*
        private void DrawExplain()
        {
            this.pnlMessage.Visible = true;
            this.lblMessage.Text =
                @"Please choose a card from this 52 cards." + Environment.NewLine +
            "Don't tell anyone which card you choose." + Environment.NewLine +
            "Then I will show you 6 sets of card" + Environment.NewLine +
            "If you see the card you choose in the set please click yes." +Environment.NewLine +
            "And I will show you which card you choose.";
            this.btnYes.Visible = true;
            this.btnNo.Visible = false;
            this.lblExplain2.Visible = false;

        }
        */

        private void DrawAllCard(Graphics g)
        {
            //  this.pnlMessage.Visible = false ;
            pnlMessage.Visible = false;
            this.lblExplain2.Text =
                @"Please choose a card from this 52 cards. Don't tell anyone which card you choose." + Environment.NewLine +
            "Then I will show you 6 sets of card, If you see the choosen card in the set please click yes." + Environment.NewLine +            
            "And I will show you which card you choose.";
            this.btnYes.Visible = true;
            this.btnNo.Visible = false;
            this.lblExplain2.Visible = true;

            List<int> list = new List<int>();
            int i;
            for (i = 1; i <= 52; i++)
            {
                list.Add(i);
            }
            Set s = new Set(1, list.ToArray());
            DrawCardSet(s, g);
        }
        private void DrawCard(Graphics g)
        {
            pnlMessage.Visible = false;
            this.btnYes.Visible = true;
            this.btnNo.Visible = true;
            this.lblExplain2.Visible = true;
            this.lblExplain2.Text =(game.CurrentSetNumber +1) + ". If you see your card belong to here click Yes, if not click No.";
            DrawCardSet(this.game.CurrentSet, g);

        }
        private void DrawCardSet(Set set, Graphics g)
        {
            int i;
          
            Dictionary<int, int> CurrentColumn = new Dictionary<int, int>();
            CurrentColumn.Add(0, 0);
            CurrentColumn.Add(1, 0);
            CurrentColumn.Add(2, 0);
            CurrentColumn.Add(3, 0);
            CurrentColumn.Add(4, 0);

            for (i = 0; i < set.listNumber.Count; i++)
            {
                int CardValue = set.listNumber[i];
                int RowNumber = GetCardNumberRow(CardValue);
               
                Point point = new Point(xOffset + (CardWidth + SpaceWidthBetweenCard) * CurrentColumn [RowNumber],
                                        yOffset + (CardHeight + SpaceWidthBetweenCard ) * RowNumber);

                CurrentColumn[RowNumber]++;
                g.DrawImage(BitMapCache.GetImageForCard(CardValue), point);
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            if(game.IsThisTheLastSet)
            {
              
            }
            switch (this.game.State) {
                
                case Game.GameState.ShowAllCard:
                    DrawAllCard(e.Graphics);
                    break;
                case Game.GameState.ShowSet:
                    DrawCard(e.Graphics);
                    break;
                
            }
          //  DrawCardSet(game.CurrentSet, e.Graphics);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Text = GetCardNumberRow(12) + " " + GetCardNumberRow(13);
            /*
            if(!game.IsThereAnyotherCardLeft)
            {
                return;
            }
            */

            game.Next();
            this.pictureBox1.Invalidate();

        }
        private void NextSet()
        {
            game.Next();
            this.UpdateRender();
            if (game.IsThisTheLastSet)
            {
               // btnYes.Visible  = false;
               // btnNo.Visible  = false;

               // ShowAnswer();
            } 
        }
        private void ShowAnswer()
        {
            this.pnlMessage.Visible = true;
            this.game.CalReadMineNumber();
            this.btnYes.Visible = false;
            this.btnNo.Visible = false;
            this.lblExplain2.Text = "";
            Timer tShowAnswer = new Timer();
            tShowAnswer.Enabled = true;
            tShowAnswer.Interval = 2000;
            tShowAnswer.Tick += TShowAnswer_Tick;
            tShowAnswer.Tag = 0;
            this.picCardAnswer.Image = BitMapCache.GetImageForCard(0);
            this.lblMessage.Text = "";
           
            this.UpdateRender();
        }

        private void TShowAnswer_Tick(object sender, EventArgs e)
        {
            int index = 0;
            Timer tShowAnswer = (Timer)sender;
            index = int.Parse(tShowAnswer.Tag.ToString());
            string[] arrWord = {"Your choosen card is going to be revealed.",
            "3",
            "2",
            "1",
            "Your chosen card is"};


            this.lblMessage.Text = arrWord[index];

            if (index >= 4)
            {
                if (this.game.IsUserActuallyChooseaCard)
                {
                   
                    this.picCardAnswer.Image = BitMapCache.GetImageForCard(this.game.ReadMindNumber);
                }
                else
                {
                    this.lblMessage.Text = "You don't actually choose a card!";
                  
                }
                tShowAnswer.Enabled = false;
                return;
            }
            index++;
            tShowAnswer.Tag = index;


            // throw new NotImplementedException();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

            switch (this.game.State)
            {

                case Game.GameState.ShowAllCard:
                    game.ShowFirstSet();
                    this.UpdateRender();
                    break;
                case Game.GameState.ShowSet:
                    game.CurrentSet.Select();
                    NextSet();
                    if(game.State == Game.GameState.ShowAnswer)
                    {
                        ShowAnswer();
                    }
                    /*
                    if (game.IsThisTheLastSet)
                    {
                        ShowAnswer();
                    }
                    else
                    {

                        
                    }
                    */
                    break;
                
            }


        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            NextSet();
            if (game.State == Game.GameState.ShowAnswer)
            {
                ShowAnswer();
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void UpdateRender()
        {


            this.pictureBox1.Invalidate();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            game = new Game();
            game.NewGame();
            UpdateRender();
        }
    }
}
