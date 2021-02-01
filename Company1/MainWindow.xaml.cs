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
using Company1.ViewModels;

namespace Company1
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

        
        
        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void TypeOfPositionInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DepatmentInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void PositionInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CreateExample_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.CreateExample();
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.CreateNew();
        }

        private void Companyes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.LoadCompany();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.SaveCompany();
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.RenameThis();
        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeleteCompany();
        }

        private void AddDepatment_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.AddDepatment();
        }

        private void DeleteDepatment_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModels company = (CompanyViewModels)DataContext;
            company.DeleteDepatment();
        }
    }
}