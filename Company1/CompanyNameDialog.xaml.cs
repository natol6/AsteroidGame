﻿using System;
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

namespace Company1
{
    /// <summary>
    /// Логика взаимодействия для CompanyNameDialog.xaml
    /// </summary>
    public partial class CompanyNameDialog : Window
    {
        public string NameCompany
        {
            get { return companyNameBox.Text; }
        }
        public CompanyNameDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}