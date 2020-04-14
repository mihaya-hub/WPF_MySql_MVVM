using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static WPF_MySql_MVVM.studentDataSet;

namespace WPF_MySql_MVVM.Model
{
    public class MainModel
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=student;Uid=root;Pwd=password");

        private studentDataTable LoadDataDase()
        {
            try
            {
                string query = "SELECT * FROM student";

                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                studentDataTable dataTable = new studentDataTable();

                adapter.Fill(dataTable);

                connection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return null;
            }
        }

        public studentDataTable Read()
        {
            MessageBox.Show("Read!");

            return LoadDataDase();
        }

        public studentDataTable Create(DataRowView rowView)
        {
            try
            {
                string query = "INSERT INTO student (grade, cclass, no, name, score) VALUES ('"
                        + rowView.Row.ItemArray[0].ToString() + "', '"
                        + rowView.Row.ItemArray[1].ToString() + "', '"
                        + rowView.Row.ItemArray[2].ToString() + "', '"
                        + rowView.Row.ItemArray[3].ToString() + "', '"
                        + rowView.Row.ItemArray[4].ToString() + "')";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Create!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select a Row!");
            }

            return LoadDataDase();
        }
        public studentDataTable Update(DataRowView rowView)
        {
            try
            {
                string query = "UPDATE student SET "
                    + rowView.Row.Table.Columns[0].ColumnName.ToString() + " = '" + rowView.Row.ItemArray[0].ToString() + "', "
                    + rowView.Row.Table.Columns[1].ColumnName.ToString() + " = '" + rowView.Row.ItemArray[1].ToString() + "', "
                    + rowView.Row.Table.Columns[2].ColumnName.ToString() + " = '" + rowView.Row.ItemArray[2].ToString() + "', "
                    + rowView.Row.Table.Columns[3].ColumnName.ToString() + " = '" + rowView.Row.ItemArray[3].ToString() + "', "
                    + rowView.Row.Table.Columns[4].ColumnName.ToString() + " = '" + rowView.Row.ItemArray[4].ToString() + "' "
                    + "WHERE no = '" + rowView.Row.ItemArray[2].ToString() + "'";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Update!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select a Row!");
            }

            return LoadDataDase();
        }

        public studentDataTable Delete(DataRowView rowView)
        {
            try
            {
                string query = "DELETE FROM student WHERE no = '" + rowView.Row.ItemArray[2].ToString() + "'";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Delete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select a Row!");
            }

            return LoadDataDase();
        }
    }
}