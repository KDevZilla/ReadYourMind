using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadYourMind
{
    public class Game
    {
        List<Set> list = new List<Set>();
        public enum GameState
        {
            ShowAllCard,
            ShowSet,
            ShowAnswer
        }
        public  GameState State { get;private set; }
        public Game()
        {
            /*
          32
32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,
16
16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,48,49,50,51,52,
8
8,9,10,11,12,13,14,15,24,25,26,27,28,29,30,31,40,41,42,43,44,45,46,47,
4
4,5,6,7,12,13,14,15,20,21,22,23,28,29,30,31,36,37,38,39,44,45,46,47,52,
2
2,3,6,7,10,11,14,15,18,19,22,23,26,27,30,31,34,35,38,39,42,43,46,47,50,51,
1
1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,
           */
            list = new List<Set>();
            list.Add(new Set(32, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52));
            list.Add(new Set(16, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 48, 49, 50, 51, 52));
            list.Add(new Set(8, 8, 9, 10, 11, 12, 13, 14, 15, 24, 25, 26, 27, 28, 29, 30, 31, 40, 41, 42, 43, 44, 45, 46, 47));
            list.Add(new Set(4, 4, 5, 6, 7, 12, 13, 14, 15, 20, 21, 22, 23, 28, 29, 30, 31, 36, 37, 38, 39, 44, 45, 46, 47, 52));
            list.Add(new Set(2, 2, 3, 6, 7, 10, 11, 14, 15, 18, 19, 22, 23, 26, 27, 30, 31, 34, 35, 38, 39, 42, 43, 46, 47, 50, 51));
            list.Add(new Set(1, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51));


        }
        private int _ReadMindNumber;
        public int ReadMindNumber
        {
            get { return _ReadMindNumber; }
        }
        public Boolean IsUserActuallyChooseaCard
        {
            get
            {
                return _ReadMindNumber > 0 &&
                    _ReadMindNumber < 53;
            }
        }
        public void CalReadMineNumber()
        {
            int iCount = 0;
            int iSum = 0;
            foreach (Set s in list)
            {
                if (s.IsSelected)
                {
                    iSum += s.Base2Number;
                }
            }
            _ReadMindNumber = iSum;
        }
        public Boolean IsGameFinished { get; private set; } = false;
      
        List<int> ListOrderShow = null;

        public Boolean IsThisTheLastSet
        {
            get { return CurrentSetNumber == 5; }
        }
        public int CurrentSetNumber { get; private set; }
        public void NewGame()
        {
            foreach (Set s in list)
            {
                s.UnSelect();
            }
            ListOrderShow = Utility.GetUniqueOrderFor0To5();
            CurrentSetNumber = 0;
            this.State = GameState.ShowAllCard ;
            

            //CurrentSet = list[ListOrderShow[CurrentSetNumber]];
        }
        public void ShowAllCard()
        {
            this.State = GameState.ShowAllCard ;
            

        }
        public void ShowFirstSet()
        {
            this.State = GameState.ShowSet;
            CurrentSetNumber = 0;

        }
        public Set CurrentSet { get =>list[ListOrderShow[CurrentSetNumber]] ;}
        public void Next()
        {
            
            if(CurrentSetNumber >= 5)
            {
                this.State = GameState.ShowAnswer;
                return;
            }
            CurrentSetNumber++;
        }

    }
}
