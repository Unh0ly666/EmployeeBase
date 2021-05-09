using System;
using System.Windows.Forms;

namespace EmployeeBase
{
    public class Employee
    {
        public string FullName;
        public string BirthDate;
        public string Sex;
        public string Post;
        public string UniqueInformation;

        public Employee(string FullName, string BirthDate, string Sex, string Post, string UniqueInformation)
        {
            if (FullName.Trim().Split(' ').Length == 3) this.FullName = FullName;
            else
            {
                MessageBox.Show("Введено неверное имя сотрудника!");
                throw new Exception();
            }
            if (DateTime.TryParse(BirthDate, out DateTime s)) this.BirthDate = s.ToString(@"dd.MM.yyyy");
            else
            {
                MessageBox.Show("Введена некорректная дата рождения!");
                throw new Exception();
            }

            this.Sex = Sex;
            
            this.Post = Post;
            
            if (UniqueInformation.Trim() != "") this.UniqueInformation = UniqueInformation;
            else
            {
                MessageBox.Show("Введена некорректная дополнительная информация!");
                throw new Exception();
            }

        }
    }
}
