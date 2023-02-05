using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfSuperrTasker.MVVM.View
{
    public partial class Chart : Window
    {
        public ChartValues<int> Values1 { get; set; }
        public ChartValues<int> Values2 { get; set; }


        public Chart()
        {
            InitializeComponent();

            Values1 = new ChartValues<int> { 1, 4, 1, 3, 2, 6 };
            Values2 = new ChartValues<int> { 5, 3, 5, 7, 3, 9 };

            DataContext = this;
        }
    }
}
