using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MySql_MVVM.Model;
using WPF_MySql_MVVM.ViewModel.Command;
using static WPF_MySql_MVVM.studentDataSet;

namespace WPF_MySql_MVVM.ViewModel
{
    public class MainViewModel
    {
        public studentDataTable StudentTable { get; private set; }
        public MainModel model;

        public DelegateCommand ReadCommand { get; private set; }
        public DelegateCommand CreateCommand { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        public MainViewModel()
        {
            StudentTable = new studentDataTable();
            model = new MainModel();

            ReadCommand = new DelegateCommand(ReadDataBase);
            CreateCommand = new DelegateCommand(CreateDataBase, isSelected);
            UpdateCommand = new DelegateCommand(UpdateDataBase, isSelected);
            DeleteCommand = new DelegateCommand(DeleteDataBase, isSelected);
        }

        public void ReadDataBase(object rowData)
        {
            studentDataTable temp = model.Read();

            StudentTable.Clear();

            foreach (studentRow row in temp)
            {
                StudentTable.ImportRow(row);
            }
        }

        public void CreateDataBase(object rowData)
        {
            DataRowView rowView = rowData as DataRowView;
            studentDataTable temp = model.Create(rowView);

            StudentTable.Clear();

            foreach (studentRow row in temp)
            {
                StudentTable.ImportRow(row);
            }
        }

        public void UpdateDataBase(object rowData)
        {
            DataRowView rowView = rowData as DataRowView;
            studentDataTable temp = model.Update(rowView);

            StudentTable.Clear();

            foreach (studentRow row in temp)
            {
                StudentTable.ImportRow(row);
            }
        }

        public void DeleteDataBase(object rowData)
        {
            DataRowView rowView = rowData as DataRowView;
            studentDataTable temp = model.Delete(rowView);

            StudentTable.Clear();

            foreach (studentRow row in temp)
            {
                StudentTable.ImportRow(row);
            }
        }

        public bool isSelected(object rowData)
        {
            if (rowData == null) return false;

            return true;
        }
    }
}