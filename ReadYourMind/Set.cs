using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadYourMind
{
    public class Set
    {
        public int Base2Number { get; private set; }
        public List<int> listNumber { get; private set; }
        public Set(int pBase2Number, params int[] arrList)
        {
            this.Base2Number = pBase2Number;
            listNumber = arrList.ToList();
        }
        public Boolean IsSelected { get; private set; } = false;
        public void Select()
        {
            this.IsSelected = true;
        }
        public void UnSelect()
        {
            this.IsSelected = false;
        }
    }
}
