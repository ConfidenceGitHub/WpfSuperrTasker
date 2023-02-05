using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;
using WpfSuperrTasker.MVVM.View;

namespace WpfSuperrTasker.MVVM.ViewModel
{
  public  class AddTaskViewModel : ObservableObject
    {
        TextBox textBox= new TextBox();
        
            
        private DateTime dt;
        public DateTime Date
        {
            get => dt;
            set
            {
                dt = value;

            }
        }

        private UserTask userTask = new UserTask();

        public RelayCommand AddNewTaskCommand { get; set; }
        public RelayCommand ShowCalendarCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }

        private void AddTask(object arg)
        {
            DataBase.Add(userTask);
            if (arg is Window window)
            {
                window.Close();
            }
        }

        public AddTaskViewModel()
        {
            AddNewTaskCommand = new RelayCommand(AddTask);
            ShowCalendarCommand = new RelayCommand(ShowCalendar);
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        private void CloseWindow(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void ShowCalendar(object obj)
        {
            if (obj is AddTaskView window)
            {
                window.Calendar.Children.Clear();
                var cal = new CalendarView();
                window.Calendar.Children.Add(cal);
                window.Height += cal.Height;
            }
        }

        public bool EnableAddButton
        {
            get => userTask.Name.Length > 0;
        }

        public string Name
        {
            get => userTask.Name;
            set
            {
                userTask.Name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(EnableAddButton));
            }
        }

        public string Description
        {
            get => userTask.Description;
            set
            {
                userTask.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }      

    }
}
