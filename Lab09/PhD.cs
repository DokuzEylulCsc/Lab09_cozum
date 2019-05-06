using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
    [Serializable]
    //public class PhD : Student
    class PhD : Student
    {
        /*public PhD()
        {
        }*/
        public PhD(string name, string surname, int no) : base(name, surname, no)
        {

        }
    }
}
