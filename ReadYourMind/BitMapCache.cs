using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadYourMind
{
    public class BitMapCache
    {
        private static Dictionary<int, Bitmap> _DicCardBitmap = null;
        public  static Bitmap GetImageForCard(int CardValue)
        {
            if(_DicCardBitmap == null)
            {
                _DicCardBitmap = new Dictionary<int, Bitmap>();
            }
            if(!_DicCardBitmap.ContainsKey(CardValue))
            {
                Bitmap Bit =(Bitmap) Image.FromFile(Utility.ImagePath + CardValue + ".png");

                _DicCardBitmap.Add(CardValue, Bit);
            }
            return _DicCardBitmap[CardValue];
        }
    }
}
