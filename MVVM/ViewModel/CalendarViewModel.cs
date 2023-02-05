using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.View;

namespace WpfSuperrTasker.MVVM.ViewModel
{
    internal class CalendarViewModel : ObservableObject
    {

        public RelayCommand TomorrowCommand { get; set; }
        public RelayCommand TodayCommand { get; set; }
        public RelayCommand NoDateCommand { get; set; }

        public CalendarViewModel()
        {
            TomorrowCommand = new RelayCommand(Tomorrow);
            TodayCommand = new RelayCommand(Today);
            NoDateCommand = new RelayCommand(NoDate);
        }

        private void NoDate(object obj)
        {
            if (obj is DatePicker dp)
            {
                dp.SelectedDate = null;
            }
          
        }

        private void Today(object obj)
        {
            if (obj is DatePicker dp)
            {
                dp.SelectedDate = DateTime.Now;
            }
        }

        private void Tomorrow(object obj)
        {
            if (obj is DatePicker dp)
            {
                dp.SelectedDate = DateTime.Now.AddDays(1);
                string date = dp.Text;
            }

        }
    }
}
