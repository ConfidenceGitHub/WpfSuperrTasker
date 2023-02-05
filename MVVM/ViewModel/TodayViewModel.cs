using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;

namespace WpfSuperrTasker.MVVM.ViewModel
{
    public class TodayViewModel : ObservableObject, ITaskView
    {
        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                Tasks.Clear();
                foreach (var task in DataBase.GetTasks(value))
                {
                    Tasks.Add(new ListBoxItem() { Content = task.Name, DataContext = task.Id });
                }
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public RelayCommand RemoveTaskCommand { get; set; }

        public ulong TaskId { get; private set; }

        private ListBoxItem selectedItem;

        public ListBoxItem SelectBl
        {
            get => selectedItem;

            set
            {
                selectedItem = value;
                TaskId = (ulong)value.DataContext;
                UserTask = DataBase.GetTasks(TaskId);
                OnPropertyChanged(nameof(SelectBl));
                OnPropertyChanged(nameof(UserTask));
                OnPropertyChanged(nameof(RemoveTaskVisibility));
            }
        }
        public UserTask UserTask { get; set;}

        public ObservableCollection<ListBoxItem> Tasks { get; set; }

        public TodayViewModel()
        {
            RemoveTaskCommand = new RelayCommand(RemoveTask);
            DataBase.OnAddNewTask += DataBase_OnAddNewTask;
            DataBase.OnRemoveTask += DataBase_OnRemoveTask;
            Tasks = new ObservableCollection<ListBoxItem>();

            foreach (UserTask task in DataBase.GetTasks(searchText))
            {
                Tasks.Add(new ListBoxItem() { Content = task.Name, DataContext = task.Id });

            }
        }

        public void RemoveTask(object o)
        {
            DataBase.RemoveUserTask((ulong)selectedItem.DataContext);
        }

        private void DataBase_OnRemoveTask(ulong id)
        {
            foreach (var item in Tasks)
            {
                if ((ulong)(item.DataContext) == id)
                {

                }
            }
        }

        private void DataBase_OnAddNewTask(UserTask userTask)
        {
            Tasks.Add(new ListBoxItem() { Content = userTask.Name, DataContext = userTask.Id });
        }

        public void SetSeachText(string seartchText)
        {
            SearchText = seartchText;
        }

        public Visibility RemoveTaskVisibility
        {
            get => UserTask == null ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
