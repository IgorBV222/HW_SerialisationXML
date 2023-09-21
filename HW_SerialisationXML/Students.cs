using HW_SerialisationXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; // добавили пространство имён

namespace HW_SerialisationXML
{
    [Serializable] // Указали атрибут класса
    public class Student : IComparer<Student>, IComparable<Student> // Изменили модификатор на public
    {
        [XmlAttribute]
        public int Number { get; set; }
        [XmlAttribute]
        public string Surname { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Patronimic { get; set; }
        [XmlAttribute]
        public string DateOfBirn { get; set; }
        [XmlAttribute]
        public int Variant { get; set; }
        public Student() { } // Добавили конструктор БЕЗ параметров
        public Student(int number, string surname, string name, string patronimic, string dateOfBirn, int variant = 0)
        {
            Number = number;
            this.Surname = surname;
            this.Name = name;
            this.Patronimic = patronimic;
            this.DateOfBirn = dateOfBirn;
            this.Variant = variant;
        }
        static public void Serealize_it(List<Student> objectGrath, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {               
                xmlSerializer.Serialize(fStream, objectGrath);
            }
        }
        static public void Deserealize_it(string filename, out List<Student> lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream fStream = new FileStream(filename, FileMode.OpenOrCreate,
                FileAccess.Read))
            {
                lst = (List<Student>)xmlSerializer.Deserialize(fStream);
            }
        }
        public int Compare(Student x, Student y)
        {
            if (x.Surname == y.Surname && x.Name == y.Name)
            {
                return 0;
            }
            else
            {
                if (x.Surname.CompareTo(y.Surname) < 0)
                {
                    return -1;
                }
                else
                {
                    if (x.Surname.CompareTo(y.Surname) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        if (x.Name.CompareTo(y.Name) < 0)
                        {
                            return -1;
                        }
                        else
                        {
                            if (x.Name.CompareTo(y.Name) > 0)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
        }
        public int CompareTo(Student other)
        {

            return Compare(this, other);
        }
    }
}
