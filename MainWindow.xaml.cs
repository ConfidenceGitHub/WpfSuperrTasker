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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Events;
using LiveCharts.Wpf;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;
using WpfSuperrTasker.MVVM.View;

namespace WpfSuperrTasker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var d = DateTime.Now.Ticks;

            DateTime date = new DateTime(d);
            date =  date.AddDays(1);

            //var t = new UserTask() { Discription = "DESC", Name ="TEST"};
            //Core.DataBase.Add(t);
            InitializeComponent();

         //   var i = DataBase.GetTasks();
        }       
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)

                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        //private void ButtonClose_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskView addTaskView = new AddTaskView()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
            };
            addTaskView.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
