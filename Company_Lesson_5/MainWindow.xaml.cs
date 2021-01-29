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
using Company_Lesson_5.ViewModels;

namespace Company_Lesson_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDepatment_Click(object sender, RoutedEventArgs e)
        {
            var model = (CompanyViewModels)DataContext;
            model.AddNewDepatment();
        }

        private void DeleteDepatment_Click(object sender, RoutedEventArgs e)
        {
            var model = (CompanyViewModels)DataContext;
            model.RemoveSelectedDepatment();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var model = (CompanyViewModels)DataContext;
            model.AddNewEmployee();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var model = (CompanyViewModels)DataContext;
            model.RemoveSelectedEmployee();
        }

        private void MoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            var model = (CompanyViewModels)DataContext;
            model.Move();
        }
    }
}
