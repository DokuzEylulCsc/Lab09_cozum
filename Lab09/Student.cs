using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab09
{

    [Serializable]
    //public abstract class Student
    abstract class Student
    {
        protected string name;
        protected string surname;
        protected int no;
        /*
        public Student()
        {

        }
        [XmlElement("Name")]
        public string Name { get { return name; } set { name = value; } }
        [XmlElement("Surname")]
        public string Surname { get { return surname; } set { surname = value; } }
        [XmlElement("No")]
        public int No { get { return no; } set { no = value; } }*/
        public Student(string name, string surname, int no)
        {
            this.name = name;
            this.surname = surname;
            this.no = no;
        }
        

        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public int No { get { return no; } }

        public override string ToString()
        {
            return $"Ad:{name} Soyad:{surname} No:{no} Tip:{this.GetType().Name}";
        }

    }
}
