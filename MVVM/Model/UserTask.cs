using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfSuperrTasker.MVVM.Model
{
    public class UserTask
    {
        public UserTask()
        {

        }

        public UserTask(ulong id)
        {
            Id = id;
        }

        public ulong Id { get;  private set; }   
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
      
    }
    
}
