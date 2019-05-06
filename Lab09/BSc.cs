using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
   

    [Serializable]
    //public class BSc : Student
    class BSc :Student
    {
       /* public BSc()
        {

        }*/
        public BSc(string name, string surname, int no):base(name,surname,no)
        {

        }
    }
}
