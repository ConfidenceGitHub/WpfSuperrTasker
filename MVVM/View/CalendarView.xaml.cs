using System;
using System.Windows.Controls;

namespace WpfSuperrTasker.MVVM.View
{
   public partial class CalendarView : UserControl
    {
        public DateTime DT
        {
            get => choceDate.DisplayDate;
            set => choceDate.DisplayDate = value;
        }

        public CalendarView()
        {
            InitializeComponent();
        }
    }
}
