using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;
using WpfSuperrTasker.MVVM.View;

namespace WpfSuperrTasker.MVVM.ViewModel
{
    class VersionViewModel : ObservableObject
    {
        const string VerPath = "version.txt";

        public VersionViewModel()
        {
            OnPropertyChanged(nameof(Test));
        }

        public string Test
        {
            get
            {
                string str;
                try
                {
                    str = File.ReadAllText(VerPath);
                }
                catch (Exception e)
                {
                    str = e.Message;
                }
                return str;
            }
        }

    }
}