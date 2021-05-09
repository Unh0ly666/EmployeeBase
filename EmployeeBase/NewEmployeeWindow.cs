using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmployeeBase
{
    public partial class NewEmployeeWindow : Form
    {
        //Поле для сравнения поступившей записи с вновь созданной (для предотвращения изменения записи на уже существующуюю).
        private Employee EmployeeForСomparison;

        /// <summary>
        /// Окно для создания новой или изменения существующей записи.
        /// </summary>
        /// <param name="EmployeeForEditing">Не равно null, если необходимо изменить запись.</param>
        public NewEmployeeWindow(Employee EmployeeForEditing = null)
        {
            InitializeComponent();
            //Если окно было вызванно с целью изменения какой-либо записи. То есть запись для изменения не пустая.
            if (EmployeeForEditing != null)
            {
                PrepareWindow(true, EmployeeForEditing);
                EmployeeForСomparison = EmployeeForEditing;
            }
            else PrepareWindow(false);
        }
        /// <summary>
        /// Обработчик кнопки, которая создает новую запись о сотруднике, взяв параметры из элементов окна,
        /// проверяет, сущетсвует ли такая запись и передаёт её в главное окно, если такой записи ещё не сущетсвует.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Employee NewEmployee;
            MainWindow main = Owner as MainWindow;
            try
            {
                NewEmployee = new Employee
               (
                   FullNameTextBox.Text,
                   BirthDateTextBox.Text,
                   SexComboBox.SelectedItem.ToString(),
                   PostComboBox.Text,
                   UniqueInformationComboBox.Text
               );
            }
            catch
            {
                return;
            }
            if (IfRecordAlreadyExist(NewEmployee))
            {
                main.EmployeeToAdd = null;
                MessageBox.Show("Такая запись уже существует!");
                return;
            }
            if (main != null) main.EmployeeToAdd = NewEmployee;
            else MessageBox.Show("Программа была закрыта!");
            Close();
        }
        /// <summary>
        /// Метод, который подготавливает окно создания новой записи в зависимости от того, создаётся ли новая запись или изменяется уже существующая.
        /// </summary>
        /// <param name="ToEditRecord">Если необходимо обновление записи.</param>
        /// <param name="EmployeeForEditing">Запись, которую необходимо обновить.</param>
        private void PrepareWindow(bool ToEditRecord, Employee EmployeeForEditing = null)
        {
            if (ToEditRecord) PrepareWindowForEditing(EmployeeForEditing);
            else PrepareWindowForCreatingNewRecord();
        }
        /// <summary>
        /// Подготавливает окно для изменения записи.
        /// </summary>
        /// <param name="EmployeeForEditing">Запись, которую необходимо изменить</param>
        private void PrepareWindowForEditing(Employee EmployeeForEditing)
        {
            FullNameTextBox.Text = EmployeeForEditing.FullName;
            BirthDateTextBox.Text = EmployeeForEditing.BirthDate;

            if (EmployeeForEditing.Sex.Contains('М')) SexComboBox.SelectedIndex = 0;
            else SexComboBox.SelectedIndex = 1;

            PostComboBox.Items.Clear();
            PostComboBox.SelectedItem = "";
            
            switch (EmployeeForEditing.Post)
            {
                case string a when a == "Директор":
                    {
                        PostComboBox.Items.AddRange(new string[] { "Директор", "Руководитель подразделения", "Контролер", "Рабочий" });
                        PostComboBox.SelectedIndex = 0;
                        UniqueInformationComboBox.Text = EmployeeForEditing.UniqueInformation;
                    }
                    break;
                case string b when b == "Руководитель подразделения":
                    {
                        PostComboBox.Items.AddRange(new string[] { "Руководитель подразделения", "Контролер", "Рабочий" });
                        PostComboBox.SelectedIndex = 0;
                        UniqueInformationComboBox.Text = EmployeeForEditing.UniqueInformation;
                    }
                    break;
                case string c when c == "Контролер":
                    {
                        PostComboBox.Items.AddRange(new string[] { "Контролер", "Рабочий" });
                        PostComboBox.SelectedIndex = 0;
                        UniqueInformationComboBox.Text = EmployeeForEditing.UniqueInformation;
                    }
                    break;
                case string d when d == "Рабочий":
                    {
                        PostComboBox.Items.AddRange(new string[] { "Рабочий" });
                        PostComboBox.SelectedIndex = 0;
                        UniqueInformationComboBox.Text = EmployeeForEditing.UniqueInformation;
                    }
                    break;
            }
        }
        /// <summary>
        /// Подготавливает окно для создания новой записи.
        /// </summary>
        private void PrepareWindowForCreatingNewRecord()
        {
            SexComboBox.SelectedIndex = 0;
            PostComboBox.Items.Clear();
            PostComboBox.Items.Add("Директор");
            PostComboBox.SelectedIndex = 0;

            if (MainWindow.ListOfEmployees.Exists(x => x.Post == "Директор"))
            {
                PostComboBox.Items.Clear();
                PostComboBox.Items.Add("Руководитель подразделения");
                PostComboBox.SelectedItem = "Руководитель подразделения";
            }
            if (MainWindow.ListOfEmployees.Exists(x => x.Post == "Руководитель подразделения")) PostComboBox.Items.AddRange(new string[] { "Рабочий", "Контролер" });
        }
        /// <summary>
        /// Метод, который проверяет, существует ли вновь созданная запись в уже существующей таблице сотрудников.
        /// </summary>
        /// <param name="NewEmployee">Новая запись, которую необходимо проверить.</param>
        /// <returns>true, если запись уже существует, false, если нет.</returns>
        private bool IfRecordAlreadyExist(Employee NewEmployee)
        {
            if (MainWindow.ListOfEmployees.Count == 0) return false;
            if (EmployeeForСomparison != null)
                if (NewEmployee.Post == "Директор" && EmployeeForСomparison.Post != "Директор" && MainWindow.ListOfEmployees.Exists(x => x.Post == "Директор")) return true;
            if (MainWindow.ListOfEmployees.Exists(x => x.FullName == NewEmployee.FullName && x.BirthDate == NewEmployee.BirthDate)) return true;
            if (MainWindow.ListOfEmployees.Exists(x => x.Post == "Руководитель подразделения" && x.UniqueInformation == NewEmployee.UniqueInformation)) return true;
            return false;
        }
        /// <summary>
        /// Обработчик, который подготавливает элементы окна в зависимости от того, какая должность была выбрана в элементе PostComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UniqueInformationComboBox.Items.Clear();
            UniqueInformationComboBox.Text = "";

            List<string> ManagersList = new List<string>();
            foreach (Employee emp in MainWindow.ListOfEmployees)
                if (emp.Post == "Руководитель подразделения") ManagersList.Add(emp.FullName);

            switch (PostComboBox.SelectedItem.ToString())
            {
                case string a when a == "Директор":
                    {
                        UniqueInformationLabel.Text = "Название предприятия";
                        UniqueInformationComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    }
                    break;
                case string b when b == "Руководитель подразделения":
                    {
                        UniqueInformationLabel.Text = "Подразделение";
                        UniqueInformationComboBox.DropDownStyle = ComboBoxStyle.Simple;
                    }
                    break;
                case string c when c == "Рабочий":
                    {
                        UniqueInformationLabel.Text = "Руководитель";
                        UniqueInformationComboBox.Items.AddRange(ManagersList.ToArray());
                        UniqueInformationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    break;
                case string d when d == "Контролер":
                    {
                        UniqueInformationLabel.Text = "Руководитель";
                        UniqueInformationComboBox.Items.AddRange(ManagersList.ToArray());
                        UniqueInformationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    break;
            }
        }
    }
}
