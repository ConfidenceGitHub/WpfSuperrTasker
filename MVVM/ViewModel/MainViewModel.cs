using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSuperrTasker.Core;
using WpfSuperrTasker.MVVM.Model;
using WpfSuperrTasker.MVVM.ViewModel;
using WpfSuperrTasker.MVVM.View;
using System.Windows;
using System.Windows.Controls;

namespace WpfSuperrTasker.MVVM.ViewModel
{
     class MainViewModel : ObservableObject
    {
        private string searchText = "";
        public string SearchText 
        {
            get => searchText;
            set 
            {
                searchText = value;
                if ((_currentView as UserControl) != null && (_currentView as UserControl).DataContext is ITaskView vm)
                {
                    vm.SetSeachText(searchText);                    
                }
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FutureViewCommand { get; set; }
        public RelayCommand CartesianChartCommand { get; set; }
        public RelayCommand AddTaskViewCommand { get; set; }
        public RelayCommand AllProjectsViewCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand VersionViewCommand { get; set; }

        public VersionViewModel VersionVm { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public TodayViewModel DiscoveryVm { get; set; }
        public FutureViewModel FutureVM { get; set; }
        public CartesianChartViewModel CartesianChartVM { get; set; }
        public AddTaskViewModel AddTaskViewVM { get; set; }
        public AllProjectsViewModel AllProjectsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);

            HomeVM = new HomeViewModel();

            VersionVm = new VersionViewModel();
            CurrentView = HomeVM;

            DiscoveryVm = new TodayViewModel();
            CurrentView = HomeVM;

            FutureVM = new FutureViewModel();
            CurrentView = HomeVM;

            CartesianChartVM = new CartesianChartViewModel();
            CurrentView = HomeVM;

            AddTaskViewVM = new AddTaskViewModel();
            CurrentView = HomeVM;

            AllProjectsVM = new AllProjectsViewModel();
            CurrentView = HomeVM;

            VersionViewCommand = new RelayCommand(o =>
             {
                 CurrentView = VersionVm;
             });

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = new TodayView();
            });

            FutureViewCommand = new RelayCommand(o =>
            {
                CurrentView = FutureVM;
            });

            CartesianChartCommand = new RelayCommand(o =>
            {
                CurrentView = CartesianChartVM;
            });

            AddTaskViewCommand = new RelayCommand(o =>
            {
                CurrentView = AddTaskViewVM;
            });

            AllProjectsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AllProjectsVM;
            });

        }

        private void CloseWindow(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
}
