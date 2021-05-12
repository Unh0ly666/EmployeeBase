using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmployeeBase
{
    public partial class MainWindow : Form
    {
        public static List<Employee> ListOfEmployees = new List<Employee>();
        public Employee EmployeeToAdd;
        /// <summary>
        /// Создание главного окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик, который загружает список сотрудников из базы данных и помещает его в таблицу главного окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            ListOfEmployees = Database.LoadData();
            EnterEmployeesInTheTable(ListOfEmployees);
        }
        /// <summary>
        /// Обработчки кнопки добавления новой записи, который вызывает окно добавления(изменения) записи, принимает от него новую запись, а затем
        /// вносит её в базу данных и таблицу сотрудников в главном окне.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            int IndexToWhichWeAdd = ListOfEmployees.Count;
            new NewEmployeeWindow() { Owner = this }.ShowDialog();
            if (EmployeeToAdd == null) return;
            ListOfEmployees.Add(EmployeeToAdd);
            try
            {
                Database.AddRecord(EmployeeToAdd, IndexToWhichWeAdd + 1);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
            EmployeeToAdd = null;
        }
        /// <summary>
        /// Обработчки кнопки изменения записи, который удаляет выделенную в таблице запись, вызывает окно добавления(изменения) записи, и если запись успешно изменилась 
        /// вносит её на место старой, а случае неудачи восстанавливает старую. Это касается и базы данных и таблицы на главном окне.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeRecordButton_Click(object sender, EventArgs e)
        {
            if (EmployeeTable.Rows.Count == 0) return;
            EmployeeToAdd = null;
            int SelectedRowIndex = EmployeeTable.SelectedCells[0].RowIndex;
            Employee temp = ListOfEmployees[SelectedRowIndex];

            ListOfEmployees.RemoveAt(SelectedRowIndex);
            new NewEmployeeWindow(temp) { Owner = this }.ShowDialog();
            if (EmployeeToAdd == null)
            {
                ListOfEmployees.Insert(SelectedRowIndex, temp);
                return;
            }
            ListOfEmployees.Insert(SelectedRowIndex, EmployeeToAdd);
            try
            {
                Database.UpdateRecord(EmployeeToAdd, SelectedRowIndex + 1);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
            EmployeeTable.Rows[SelectedRowIndex].Cells[0].Selected = true;
        }
        /// <summary>
        /// Обработчки кнопки удаления записи, который удаляет выделенную в таблице запись из таблицы и базы данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            if (EmployeeTable.Rows.Count == 0) return;
            int LastIndexOfTable = ListOfEmployees.Count;
            int SelectedRowIndex = EmployeeTable.SelectedCells[0].RowIndex;
            try
            {
                Database.DeleteRecord(SelectedRowIndex + 1, LastIndexOfTable);
                ListOfEmployees.RemoveAt(SelectedRowIndex);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }

        }
        /// <summary>
        /// Обработчки кнопки повышения сотрудника, который в зависимости от его текущей должности повышает выделенного в таблице сотрудника и 
        /// редактирует связанные с ним записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromoteButton_Click(object sender, EventArgs e)
        {
            if (EmployeeTable.Rows.Count == 0) return;
            Employee EmployeeForPromote = ListOfEmployees[EmployeeTable.SelectedCells[0].RowIndex];

            switch (EmployeeForPromote.Post)
            {
                case string a when a == "Руководитель подразделения":
                    {
                        if (!ListOfEmployees.Exists(x => x.Post == "Директор"))
                        {
                            PromoteManageWithNoDirector(EmployeeForPromote);
                            break;
                        }
                        PromoteManageWithDirector(EmployeeForPromote);
                    }
                    break;
                case string b when b == "Контролер":
                    {
                        PromoteСontroller(EmployeeForPromote);
                    }
                    break;
                case string c when c == "Рабочий":
                    {
                        PromoteWorker(EmployeeForPromote);
                    }
                    break;
                case string d when d == "Директор":
                    {
                        MessageBox.Show("Директора нельзя повысить!");
                    }
                    break;
            }
            EmployeeTable.Rows[EmployeeTable.SelectedCells[0].RowIndex].Cells[0].Selected = true;
        }
        /// <summary>
        /// Обработчик кнопки, которая при нажатии вызывет окно для получения параметров поиска, получает от него параметры и по ним 
        /// ищет в таблице подходящие записи и помещает их в таблицу. При повторном нажатии возвращает общую таблицу сотрудников.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectionCheckBox.CheckState == CheckState.Checked)
            {
                new SelectionForm().ShowDialog();
                List<Employee> SelectedEmployees = new List<Employee>();
                List<Employee> ManagersList = new List<Employee>();

                foreach (var employee in ListOfEmployees)
                    if (employee.Post == "Руководитель подразделения" && employee.UniqueInformation.ToLower() == SelectionForm.DivisionToSearchFor)
                        ManagersList.Add(employee);

                if (SelectionForm.PostToSearchFor == null && SelectionForm.DivisionToSearchFor == null)
                {
                    SelectionCheckBox.CheckState = CheckState.Unchecked;
                    return;
                }

                if (SelectionForm.PostToSearchFor.Trim() != "" && SelectionForm.DivisionToSearchFor.Trim() == "")
                    SelectedEmployees = ListOfEmployees.FindAll(x => x.Post.ToLower() == SelectionForm.PostToSearchFor);
                if (SelectionForm.DivisionToSearchFor.Trim() != "" && SelectionForm.PostToSearchFor.Trim() == "")
                    SelectedEmployees = ListOfEmployees.FindAll(x => ManagersList.Exists(y => x.UniqueInformation == y.FullName) || x.UniqueInformation.ToLower() == SelectionForm.DivisionToSearchFor);

                if (SelectionForm.DivisionToSearchFor.Trim() != "" && SelectionForm.PostToSearchFor.Trim() != "")
                    SelectedEmployees = ListOfEmployees.FindAll(x => (x.Post.ToLower() == SelectionForm.PostToSearchFor && ManagersList.Exists(y => x.UniqueInformation == y.FullName) || (SelectionForm.PostToSearchFor == "Руководитель подразделения" && x.UniqueInformation == SelectionForm.DivisionToSearchFor)));
                EnterEmployeesInTheTable(SelectedEmployees);
                SelectionForm.PostToSearchFor = null;
                SelectionForm.DivisionToSearchFor = null;
            }
            else
            {
                EnterEmployeesInTheTable(ListOfEmployees);
            }
        }
        /// <summary>
        /// Метод, который используется для повышения сотрудника имеющего должность руководителя подразделения и редактирования связанных с ним записей, когда в таблице отсутствует директор и
        /// повышаемый сотрудник им станет.
        /// </summary>
        /// <param name="EmployeeForPromote">Сотрудник, которго повышают.</param>
        private void PromoteManageWithNoDirector(Employee EmployeeForPromote)
        {
            List<Employee>
                ListOfSubordinates = new List<Employee>(),
                EntriesToUpdate = new List<Employee>();

            ListOfSubordinates = ListOfEmployees.FindAll(x => x.UniqueInformation == EmployeeForPromote.FullName);
            EmployeeForPromote.UniqueInformation = "Название компании не задано";
            EmployeeForPromote.Post = "Директор";
            EntriesToUpdate.Add(EmployeeForPromote);
            EntriesToUpdate.AddRange(ListOfSubordinates);
            try
            {
                UpdateSeveralRecords(EntriesToUpdate);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
            MessageBox.Show("Дайте название компании для нового директора", "Название компании не задано");

        }
        /// <summary>
        /// Метод, который используется для повышения сотрудника имеющего должность руководителя подразделения и редактирования связанных с ним записей, когда в таблице присутсвует директор и
        /// повышаемый сотрудник меняется с ним местами.
        /// </summary>
        /// <param name="EmployeeForPromote">Сотрудник, которго повышают.</param>
        private void PromoteManageWithDirector(Employee EmployeeForPromote)
        {
            List<Employee>
                ListOfSubordinates = new List<Employee>(),
                EntriesToUpdate = new List<Employee>();
            Employee EmployeeForDowngrade;
            string temp;

            EmployeeForDowngrade = ListOfEmployees.Find(x => x.Post == "Директор");

            ListOfSubordinates = ListOfEmployees.FindAll(x => EmployeeForPromote.FullName == x.UniqueInformation);
            temp = EmployeeForDowngrade.UniqueInformation;
            EmployeeForDowngrade.UniqueInformation = EmployeeForPromote.UniqueInformation;
            foreach (var Subordinates in ListOfSubordinates) Subordinates.UniqueInformation = EmployeeForDowngrade.FullName;
            EmployeeForDowngrade.Post = "Руководитель подразделения";
            EmployeeForPromote.UniqueInformation = temp;
            EmployeeForPromote.Post = "Директор";

            EntriesToUpdate.Add(EmployeeForPromote);
            EntriesToUpdate.Add(EmployeeForDowngrade);
            EntriesToUpdate.AddRange(ListOfSubordinates);
            try
            {
                UpdateSeveralRecords(EntriesToUpdate);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
        }
        /// <summary>
        /// Метод, который используется для повышения сотрудника имеющего должность котролера, и передачи ему в подчинение сотрудников, которые подчиняюлись его
        /// старому начальнику.
        /// </summary>
        /// <param name="EmployeeForPromote">Сотрудник, которго повышают.</param>
        private void PromoteСontroller(Employee EmployeeForPromote)
        {
            List<Employee>
                ListOfSubordinates = new List<Employee>(),
                EntriesToUpdate = new List<Employee>();
            Employee EmployeeForDowngrade;
            string temp;

            EmployeeForDowngrade = ListOfEmployees.Find(x => x.FullName == EmployeeForPromote.UniqueInformation);

            ListOfSubordinates = ListOfEmployees.FindAll(x => x.UniqueInformation == ListOfEmployees.Find(x => x.FullName == EmployeeForPromote.UniqueInformation).FullName);
            temp = EmployeeForDowngrade.UniqueInformation;
            EmployeeForDowngrade.UniqueInformation = EmployeeForPromote.FullName;
            EmployeeForDowngrade.Post = "Контролер";
            EmployeeForPromote.Post = "Руководитель подразделения";
            foreach (var Subordinates in ListOfSubordinates) Subordinates.UniqueInformation = EmployeeForPromote.FullName;
            EmployeeForPromote.UniqueInformation = temp;

            EntriesToUpdate.Add(EmployeeForPromote);
            EntriesToUpdate.Add(EmployeeForDowngrade);
            EntriesToUpdate.AddRange(ListOfSubordinates);
            try
            {
                UpdateSeveralRecords(EntriesToUpdate);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
        }
        /// <summary>
        /// Метод, который повышает работника до контролера.
        /// </summary>
        /// <param name="EmployeeForPromote">Сотрудник, которго повышают.</param>
        private void PromoteWorker(Employee EmployeeForPromote)
        {
            EmployeeForPromote.Post = "Контролер";
            try
            {
                Database.UpdateRecord(EmployeeForPromote, EmployeeTable.SelectedCells[0].RowIndex + 1);
                EnterEmployeesInTheTable(ListOfEmployees);
                MessageBox.Show("Изменения успешно применены!");
            }
            catch
            {
                MessageBox.Show("Изменения не были применены!");
            }
        }
        /// <summary>
        /// Очищает таблицу главного окна и заполняет её актуальным списком сотрудников.
        /// </summary>
        /// <param name="ListOfEmployees">Актуальный список сотрудников.</param>
        private void EnterEmployeesInTheTable(List<Employee> ListOfEmployees)
        {
            EmployeeTable.Rows.Clear();
            for (int i = 0; i < ListOfEmployees.Count; i++)
                EmployeeTable.Rows.Add
                    (
                        ListOfEmployees[i].FullName,
                        ListOfEmployees[i].BirthDate,
                        ListOfEmployees[i].Sex,
                        ListOfEmployees[i].Post,
                        ListOfEmployees[i].UniqueInformation
                    );
        }
        /// <summary>
        /// Выборочно обновляет несколько записей в базе данных.
        /// </summary>
        /// <param name="RowsToUpdate">Выборка записей, которые необходимо обновить.</param>
        private void UpdateSeveralRecords(List<Employee> RowsToUpdate)
        {
            for (int i = 0; i < ListOfEmployees.Count; i++)
                for (int j = 0; j < RowsToUpdate.Count; j++)
                    if (RowsToUpdate[j] == ListOfEmployees[i])
                        Database.UpdateRecord(RowsToUpdate[j], i + 1);
        }
    }
}
