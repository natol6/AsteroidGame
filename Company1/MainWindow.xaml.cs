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

namespace Company1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyNameList companyes = new CompanyNameList();
        private string companyNameBegin = "Предприятие не создано или не загружено";
        private string companyName;
        private Company company;
        private string titleSort;
        public MainWindow()
        {
            InitializeComponent();
            companyName = companyNameBegin;
            companyes.LoadCompanyName();
            this.Title = companyName;
            Companyes.ItemsSource = companyes;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createExample_Click(object sender, RoutedEventArgs e)
        {
            
            company = new Company();
            company.Generate_Company(110, 8);
            companyName = company.Title;
            this.Title = companyName;
            if (!companyes.Contains(companyName)) companyes.Add(companyName);
            this.Binding(0);
        }

        private void createNew_Click(object sender, RoutedEventArgs e)
        {
            CompanyNameDialog cnd = new CompanyNameDialog();

            if (cnd.ShowDialog() == true)
            {
                if (cnd.NameCompany == "")
                    MessageBox.Show("Вы не ввели наименование. Предприятие не создано.");
                else if (companyes.Contains(companyName))
                {
                    MessageBox.Show("Предприятие с таким наименованием было создано ранее. Загрузите его для работы.");
                }
                else
                {
                    companyName = cnd.NameCompany;
                    this.Title = companyName;
                    company = new Company(companyName);
                    if (!companyes.Contains(companyName)) companyes.Add(companyName);
                    this.Binding(0);
                }
            
            }
            else
            {
                MessageBox.Show("Предприятие не создано.");
            }
                   }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            company.Save();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //companyName = companyNameBegin;
            //this.Title = companyName;

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (!(company == null)) company.Save();
            companyes.Save();
        }

        private void Companyes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            companyName = (string)Companyes.SelectedItem;
            this.Title = companyName;
            company = new Company(companyName);
            company.Load();
            this.Binding(0);
        }
        private void Binding(int i)
        {
            switch (i)
            {
                case 0:
                    var emplAll = from e in company.Employees
                                  join p in company.Positions on e.PositionId equals p.Id
                                  join d in company.Depatments on e.DepatmentId equals d.Id
                                  select new { Surname = e.Surname, Name = e.Name, MiddleName = e.MiddleName, PositionId = p.Title, DepatmentId = d.Title };
                    employees.ItemsSource = emplAll;
                    break;
                case 1:
                    var emplType = from e in company.Employees
                                  join p in company.Positions on e.PositionId equals p.Id
                                  join d in company.Depatments on e.DepatmentId equals d.Id
                                  join t in company.TypeOfPositions on p.TypeOfPositionId equals t.Id
                                  where t.Title == titleSort
                                  select new { Surname = e.Surname, Name = e.Name, MiddleName = e.MiddleName, PositionId = p.Title, DepatmentId = d.Title };
                    employees.ItemsSource = emplType;
                    break;
                case 2:
                    var emplDep = from e in company.Employees
                                  join p in company.Positions on e.PositionId equals p.Id
                                  join d in company.Depatments on e.DepatmentId equals d.Id
                                  where d.Title == titleSort
                                  select new { Surname = e.Surname, Name = e.Name, MiddleName = e.MiddleName, PositionId = p.Title, DepatmentId = d.Title };
                    employees.ItemsSource = emplDep;
                    break;
                case 3:
                    var emplPos = from e in company.Employees
                                  join p in company.Positions on e.PositionId equals p.Id
                                  join d in company.Depatments on e.DepatmentId equals d.Id
                                  where p.Title == titleSort
                                  select new { Surname = e.Surname, Name = e.Name, MiddleName = e.MiddleName, PositionId = p.Title, DepatmentId = d.Title };
                    employees.ItemsSource = emplPos;
                    break;

            }
            

            typeOfPosition.ItemsSource = company.TypeOfPositions;
            position.ItemsSource = company.Positions;
            depatment.ItemsSource = company.Depatments;
            TypeOfPositionInsert.ItemsSource = company.TypeOfPositions;
            DepatmentInsert.ItemsSource = company.Depatments;
            PositionInsert.ItemsSource = company.Positions;
        }

        private void TypeOfPositionInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            titleSort = ((TypeOfPosition)TypeOfPositionInsert.SelectedItem).Title;
            this.Binding(1);
        }

        private void DepatmentInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            titleSort = ((Depatment)DepatmentInsert.SelectedItem).Title;
            this.Binding(2);
        }

        private void PositionInsert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            titleSort = ((Position)PositionInsert.SelectedItem).Title;
            this.Binding(3);
        }
    }
}