using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab09
{
    [Serializable]
    /*[XmlRoot("University")]
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(BSc))]
    [XmlInclude(typeof(MSc))]
    [XmlInclude(typeof(PhD))]
    public class University*/
    class University
    {
        private string name;
        private List<Student> students;
        /* Xml Serileştirme için eklenen cons.*/
        public University()
        {

        }
          public string Name { get { return name; }  }  
        /*
        [XmlElement("Name")]
        public string Name { get { return name; } set { name = value; } }
        */
        public List<Student> Students { get { return students; }  }
        /*
        [XmlArray("Students")]
        [XmlArrayItem("Student", typeof(Student))]
        public List<Student> Students { get { return students; } set { students = value; } }
        */

        public University(string name)
        {
            this.name = name;
            students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public Student SearchStudent(string name)
        {
            Student t = null;
            foreach(Student a in students)
            {
                if(String.Equals(a.Name,name))
                {
                    t = a;
                    break;
                }
            }
            if (t == null) throw new StudentNotFound(name);
            return t;
        }
     
        
        public Student SearchStudent(int no)
        {
            Student t = null;
            foreach (Student a in students)
            {
                if (a.No == no)
                {
                    t = a;
                    break;
                }
            }
            if (t == null) throw new StudentNotFound(no);
            return t;
        }

       
    }
}
