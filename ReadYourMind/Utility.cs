using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadYourMind
{
    public class Utility
    {
        public static string ApplicationPath
        {
            get { return System.IO.Path.GetDirectoryName(Application.ExecutablePath); }
        }
        public static string ImagePath
        {
            get { return ApplicationPath + @"\AppInfo\Images\"; }
        }
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        // Please find a better way to shfulle this
        // This is so poor.
        public static List<int> GetUniqueOrderFor0To5()
        {
            int[,] arrList =
            {
{ 0,1,2,3,4,5 },
{ 0,3,5,2,4,1},
{ 1,3,2,0,5,4},
{ 1,2,4,3,5,0},
{ 2,3,1,4,5,0},
{ 2,5,0,4,3,1},
{ 3,4,5,0,1,2},
{ 3,0,2,5,4,1},
{ 4,0,2,1,3,5},
{ 4,2,3,5,1,0},
{ 5,1,0,4,3,2},
{ 5,0,1,2,4,3}

            };
            int indexChoose = GetRandomNumber(0, arrList.GetUpperBound (0));
            List<int> listResult = new List<int>();
            int i;
            for (i = 0; i < arrList.GetUpperBound(1); i++)
            {
                listResult.Add(arrList[indexChoose, i]);
            }
            return listResult;
            //arrList[0, 2] = 5;

        }
       
    }
}
