
namespace EmployeeBase
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddRecordButton = new System.Windows.Forms.Button();
            this.DeleteRecordButton = new System.Windows.Forms.Button();
            this.EmployeeTable = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Additionalnformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeRecordButton = new System.Windows.Forms.Button();
            this.PromoteButton = new System.Windows.Forms.Button();
            this.SelectionCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // AddRecordButton
            // 
            this.AddRecordButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddRecordButton.Location = new System.Drawing.Point(1113, 12);
            this.AddRecordButton.Name = "AddRecordButton";
            this.AddRecordButton.Size = new System.Drawing.Size(145, 71);
            this.AddRecordButton.TabIndex = 1;
            this.AddRecordButton.Text = "Добавить запись";
            this.AddRecordButton.UseVisualStyleBackColor = true;
            this.AddRecordButton.Click += new System.EventHandler(this.AddRecordButton_Click);
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteRecordButton.Location = new System.Drawing.Point(1113, 166);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Size = new System.Drawing.Size(145, 71);
            this.DeleteRecordButton.TabIndex = 2;
            this.DeleteRecordButton.Text = "Удалить запись";
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            this.DeleteRecordButton.Click += new System.EventHandler(this.DeleteRecordButton_Click);
            // 
            // EmployeeTable
            // 
            this.EmployeeTable.AllowUserToAddRows = false;
            this.EmployeeTable.AllowUserToDeleteRows = false;
            this.EmployeeTable.AllowUserToResizeColumns = false;
            this.EmployeeTable.AllowUserToResizeRows = false;
            this.EmployeeTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EmployeeTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.EmployeeTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.BirthDate,
            this.Sex,
            this.Post,
            this.Additionalnformation});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeeTable.GridColor = System.Drawing.SystemColors.Window;
            this.EmployeeTable.Location = new System.Drawing.Point(12, 12);
            this.EmployeeTable.MultiSelect = false;
            this.EmployeeTable.Name = "EmployeeTable";
            this.EmployeeTable.ReadOnly = true;
            this.EmployeeTable.RowHeadersVisible = false;
            this.EmployeeTable.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.EmployeeTable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeTable.RowTemplate.Height = 29;
            this.EmployeeTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EmployeeTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeTable.Size = new System.Drawing.Size(1084, 629);
            this.EmployeeTable.TabIndex = 3;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.Frozen = true;
            this.FullName.HeaderText = "ФИО";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FullName.Width = 310;
            // 
            // BirthDate
            // 
            this.BirthDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BirthDate.HeaderText = "Дата Рождения";
            this.BirthDate.MinimumWidth = 6;
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            this.BirthDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BirthDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BirthDate.Width = 110;
            // 
            // Sex
            // 
            this.Sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Sex.HeaderText = "Пол";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sex.Width = 60;
            // 
            // Post
            // 
            this.Post.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Post.HeaderText = "Должность";
            this.Post.MinimumWidth = 6;
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            this.Post.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Post.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Post.Width = 300;
            // 
            // Additionalnformation
            // 
            this.Additionalnformation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Additionalnformation.DefaultCellStyle = dataGridViewCellStyle2;
            this.Additionalnformation.HeaderText = "Доп. Информация";
            this.Additionalnformation.MinimumWidth = 6;
            this.Additionalnformation.Name = "Additionalnformation";
            this.Additionalnformation.ReadOnly = true;
            this.Additionalnformation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Additionalnformation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Additionalnformation.Width = 300;
            // 
            // ChangeRecordButton
            // 
            this.ChangeRecordButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeRecordButton.Location = new System.Drawing.Point(1113, 89);
            this.ChangeRecordButton.Name = "ChangeRecordButton";
            this.ChangeRecordButton.Size = new System.Drawing.Size(145, 71);
            this.ChangeRecordButton.TabIndex = 5;
            this.ChangeRecordButton.Text = "Изменить запись";
            this.ChangeRecordButton.UseVisualStyleBackColor = true;
            this.ChangeRecordButton.Click += new System.EventHandler(this.ChangeRecordButton_Click);
            // 
            // PromoteButton
            // 
            this.PromoteButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PromoteButton.Location = new System.Drawing.Point(1113, 243);
            this.PromoteButton.Name = "PromoteButton";
            this.PromoteButton.Size = new System.Drawing.Size(145, 71);
            this.PromoteButton.TabIndex = 6;
            this.PromoteButton.Text = "Повысить сотрудника";
            this.PromoteButton.UseVisualStyleBackColor = true;
            this.PromoteButton.Click += new System.EventHandler(this.PromoteButton_Click);
            // 
            // SelectionCheckBox
            // 
            this.SelectionCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.SelectionCheckBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectionCheckBox.Location = new System.Drawing.Point(1113, 320);
            this.SelectionCheckBox.Name = "SelectionCheckBox";
            this.SelectionCheckBox.Size = new System.Drawing.Size(145, 71);
            this.SelectionCheckBox.TabIndex = 8;
            this.SelectionCheckBox.Text = "Найти сотрудников";
            this.SelectionCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectionCheckBox.UseVisualStyleBackColor = true;
            this.SelectionCheckBox.CheckedChanged += new System.EventHandler(this.SelectionCheckBox_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.SelectionCheckBox);
            this.Controls.Add(this.PromoteButton);
            this.Controls.Add(this.ChangeRecordButton);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.AddRecordButton);
            this.Controls.Add(this.EmployeeTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddRecordButton;
        private System.Windows.Forms.Button DeleteRecordButton;
        private System.Windows.Forms.Button ChangeRecordButton;
        private System.Windows.Forms.DataGridView EmployeeTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Additionalnformation;
        private System.Windows.Forms.Button PromoteButton;
        private System.Windows.Forms.CheckBox SelectionCheckBox;
    }
}

