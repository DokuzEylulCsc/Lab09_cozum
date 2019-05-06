using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace Lab09
{
    class Program
    {
        /*
        XML Serileştirme için proje içerisinden ki yorum satılarını açarak kod haline getirin. Bunu yaparken bunların yerine şu  anda duran kodları yorum haline getirmeyi unutmayın.
         */
        static void Main(string[] args)
        {
            University deu = null;
            try
            {
                deu = Deserialize();
                //deu = XmlDeserialize();
            }
            catch (Exception e)
            {
                
                string name = "deu";
                deu = new University(name);
                deu.AddStudent(new BSc("Ahmet", "Mehmet", 1));
                deu.AddStudent(new MSc("Ali", "Veli", 2));
                deu.AddStudent(new PhD("Ali", "Mehmet", 3));
            }
            finally
            {
                if (deu != null)
                {
                    foreach (Student a in deu.Students)
                    {
                        Console.WriteLine(a.ToString());
                    }
                    Serialize(deu);
                    //XmlSerialize(deu);
                    Console.WriteLine();
                }
            }


            try
            {
                Student s = deu.SearchStudent(3);
                Console.WriteLine(s.ToString());
                s = deu.SearchStudent(4);
                Console.WriteLine(s.ToString());
            }
            catch(StudentNotFound e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {

            }
            try
            {
                Student s = deu.SearchStudent("Ali");
                Console.WriteLine(s.ToString());
                s = deu.SearchStudent("Hasan");
                Console.WriteLine(s.ToString());
            }
            catch (StudentNotFound e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {

            }
        }

        static void XmlSerialize(University deu)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(University));

            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, deu);
                    xml = sww.ToString();
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(xml);
                    xdoc.Save("university.xml");
                }

            }
        }

        static University XmlDeserialize()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(University));
            University deu = null;
            string path = "university.xml";
            using (StreamReader reader = new StreamReader(path))
            {
                deu = (University)xsSubmit.Deserialize(reader);

            }
            return deu; 
        }

        static void Serialize(University deu)
        {
            using (FileStream fs = new FileStream("university.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, deu);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
            }
        }
        static University Deserialize()
        {
            University deu;
            using (FileStream fs = new FileStream("university.dat", FileMode.Open))
            {
                
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    deu = (University)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }

            }
            return deu;
        }
    }
}

