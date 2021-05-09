using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EmployeeBase
{
    class Database
    {
        static string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=mydatabase;AttachDbFilename=" + new DirectoryInfo("../../../Database1.mdf").FullName + ";Integrated Security=True";
        /// <summary>
        /// Данный метод загружает список сотрудников из базы данных.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public static List<Employee> LoadData()
        {
            List<Employee> ListOfEmployees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    for (int i = 0; reader.Read(); i++)
                    {
                        ListOfEmployees.Add(new Employee
                            (
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5)
                            )
                        );
                    }
                }

                reader.Close();
            }
            return ListOfEmployees;
        }
        /// <summary>
        /// Добавляет запись в базу данных за заданым индексом.
        /// </summary>
        /// <param name="employee">Запись для добавления.</param>
        /// <param name="IndexToWhichWeAdd">С каким индексом её добавить.</param>
        public static void AddRecord(Employee employee, int IndexToWhichWeAdd)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = @"INSERT INTO Employees (Id, FullName, BirthDate, Sex, Post, UniqueInformation) VALUES (@Id, @FullName, @BirthDate, @Sex, @Post, @UniqueInformation)";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@BirthDate", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@Sex", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@Post", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@UniqueInformation", SqlDbType.NVarChar, 50);

                    command.Parameters["@Id"].Value = IndexToWhichWeAdd;
                    command.Parameters["@FullName"].Value = employee.FullName;
                    command.Parameters["@BirthDate"].Value = employee.BirthDate;
                    command.Parameters["@Sex"].Value = employee.Sex;
                    command.Parameters["@Post"].Value = employee.Post;
                    command.Parameters["@UniqueInformation"].Value = employee.UniqueInformation;
                    command.ExecuteNonQuery();
                    
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception();
                }
                connection.Close();
            }
        }
        /// <summary>
        /// Обновляет запись в базе данных по индексу.
        /// </summary>
        /// <param name="employee">Запись для обновления.</param>
        /// <param name="RowIndex">Индекс записи, которую необходимо обновить.</param>
        public static void UpdateRecord(Employee employee, int RowIndex)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = @"UPDATE Employees SET Id = @Id, FullName = @FullName, BirthDate = @BirthDate, Sex = @Sex, Post = @Post, UniqueInformation = @UniqueInformation WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@BirthDate", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@Sex", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@Post", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@UniqueInformation", SqlDbType.NVarChar, 50);

                    command.Parameters["@Id"].Value = RowIndex;
                    command.Parameters["@FullName"].Value = employee.FullName;
                    command.Parameters["@BirthDate"].Value = employee.BirthDate;
                    command.Parameters["@Sex"].Value = employee.Sex;
                    command.Parameters["@Post"].Value = employee.Post;
                    command.Parameters["@UniqueInformation"].Value = employee.UniqueInformation;
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Удаляет запись по индексу.
        /// </summary>
        /// <param name="RowIndex">Индекс удаляемой записи.</param>
        /// <param name="LastIndexOfTable">Индекс последней записи таблицы, для того чтобы сдвинуть все индесы после удаляемой записи на один.</param>
        public static void DeleteRecord(int RowIndex, int LastIndexOfTable)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = @"DELETE FROM Employees WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = RowIndex;
                    command.ExecuteNonQuery();

                    command.CommandText = @"UPDATE Employees SET Id = @NewId WHERE Id = @Id";
                    command.Parameters.Add("@NewId", SqlDbType.Int);

                    for (int i = RowIndex; i <= LastIndexOfTable; i++) 
                    {
                        command.Parameters["@Id"].Value = i;
                        command.Parameters["@NewId"].Value = i - 1;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception();
                }
                connection.Close();
            }
        }

    }

}

