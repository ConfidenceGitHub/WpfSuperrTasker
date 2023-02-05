using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;

namespace WpfSuperrTasker.MVVM.ViewModel
{
  
    public class UserTaskVm : ObservableObject
    {
        public void SetId(ulong id)
        {
            var userTask = DataBase.GetTasks(id);
        }

        public void SetData(UserTask task)
        {
            UserTask = task;
        }

        private UserTask userTask;

        public UserTask UserTask { get { return userTask; } 
            set 
            { 
                userTask= value;
                OnPropertyChanged(nameof(UserTask));
            } }

        public UserTaskVm()
        {
            UserTask= new UserTask();
        }

        public UserTaskVm(UserTask userTask)
        {
            UserTask = userTask;
        }

        public string Name { get => userTask.Name; set => userTask.Name = value; }

        public string Description { get => userTask.Description; set => userTask.Description = value; }

        public string Time { set => userTask.Date.ToString(); }

    }
}
