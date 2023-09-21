using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW_SerialisationXML
{
    public partial class Form1 : Form
    {
        List<Student> journal = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
        private void saveToXml(string path = "student.xml")
        {
            Student.Serealize_it(journal, path);
        }
        private void btnSaveXML_Click(object sender, EventArgs e)
        {
           saveToXml();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {          
            listBoxStudents.Items.Add(("Фамилия: " + textBoxSurname.Text + " Имя: " + textBoxName.Text + " Отчество: " + textBoxPatronymic.Text + " Дата рождения: " + maskedTextBoxBirthday.Text + " Вариант: " + Convert.ToInt32(textBoxVariant.Text)));
            listBoxStudents.Sorted = true;
            var student = new Student(Convert.ToInt32(textBoxNumber.Text),                                         
                                        textBoxSurname.Text,
                                        textBoxName.Text,
                                        textBoxPatronymic.Text,
                                        maskedTextBoxBirthday.Text,
                                        Convert.ToInt32(textBoxVariant.Text));
            journal.Add(student);            
            journal.Sort(); // сортируем лист в алфавитном порядке           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {            
            int deletStudent = listBoxStudents.SelectedIndex;
            listBoxStudents.Items.RemoveAt(listBoxStudents.SelectedIndex);
            journal.RemoveAt(deletStudent);            
        }        
    }
}
