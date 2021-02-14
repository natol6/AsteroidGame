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
using Company_Lesson_7.ViewModels;

namespace Company_Lesson_7
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

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateExample_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.CreateExample();
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _AddDepatment_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.AddDepatment();
        }

        private void _DeleteDepatment_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeleteDepatment();
        }

        private void Companyes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.LoadCompany();
        }

        private void _AddPosition_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.AddPosition();
        }

        private void _DeletePosition_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeletePosition();
        }

        private void _AddTypeOfPosition_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.AddTypeOfPosition();
        }

        private void _DeleteTypeOfPosition_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeleteTypeOfPosition();
        }

        private void _AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.AddEmployee();
        }

        private void _DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeleteEmployee();
        }
    }
}
