using System;
using System.Windows.Forms;

namespace EmployeeBase
{
    public partial class SelectionForm : Form
    {
        public static string PostToSearchFor;
        public static string DivisionToSearchFor;

        /// <summary>
        /// Окно для получения параметров поиска.
        /// </summary>
        public SelectionForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик кнопки, который передаёт параметры поиска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSelectButton_Click(object sender, EventArgs e)
        {
            PostToSearchFor = TitleOfPostTextBox.Text.Trim().ToLower();
            DivisionToSearchFor = TitleOfDivisionTextBox.Text.Trim().ToLower();
            Close();
        }
    }
}
