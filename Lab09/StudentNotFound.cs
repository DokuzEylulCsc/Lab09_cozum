using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
    class StudentNotFound : Exception
    {
        public StudentNotFound():base()
        {

        }

        public StudentNotFound(string name) : base($"{name} isimli öğrenci üniversitemize kayıtlı değildir.")
        {

        }


        public StudentNotFound(int StuNo):base($"{StuNo} numaralı öğrenci universitemize kayıtlı değildir.")
        {

        }


    }
}
