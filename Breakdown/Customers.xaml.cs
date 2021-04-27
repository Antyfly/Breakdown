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
using Breakdown.Entity;

namespace Breakdown
{
    ///
    /// 
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public int RowAll { get; set; } = 0;
        public int RowsShowed { get; set; } = 0;
        public int RowsPlus { get; set; } = 0;
        public int Page { get; set; } = 0;
        public string Search { get; set; } = "";

        public Customers()
        {
            InitializeComponent();
            DataContext = this;
            RowsBox.ItemsSource = new List<string>() { 
                "10",
                "50",
                "200",
                "Всё"

            };
            Update();
        }
        public void Update()
        {
            var datasourse = CN.context.Client.ToList();
            RowAll = datasourse.Count();
            if (string.IsNullOrEmpty(Search) != true)
            {
                string search = Search.ToLower();
                datasourse = datasourse.Where(i => i.FirstName.ToLower().Contains(search) || i.Email.ToLower().Contains(search) || i.Phone.ToLower().Contains(search) == true).ToList();
            }
            switch (RowsBox.SelectedIndex)
            {
                case 0:
                    datasourse = datasourse.Skip(10 * Page).Take(10).ToList();
                    if (datasourse.Count < 10)
                    {
                        Next.IsEnabled = false;
                    }
                    else
                    {
                        Next.IsEnabled = true;
                    }
                    break;
                case 1:
                    datasourse = datasourse.Skip(50 * Page).Take(50).ToList();
                    if (datasourse.Count < 50)
                    {
                        Next.IsEnabled = false;
                    }
                    else
                    {
                        Next.IsEnabled = true;
                    }
                    break;
                case 2:
                    datasourse = datasourse.Skip(200 * Page).Take(200).ToList();
                    if (datasourse.Count < 200)
                    {
                        Next.IsEnabled = false;
                    }
                    else
                    {
                        Next.IsEnabled = true;
                    }
                    break;
                case 3:
                    datasourse = datasourse.ToList();
                    break;
            }
           
            RowsShowed = datasourse.Count();
            List.ItemsSource = datasourse;

            var Svodsourse = CN.context.Svodka.ToList();
            ListClient.ItemsSource = Svodsourse;

            //var Sersourse = CN.context.Service.ToList();
            //ListService.ItemsSource = Sersourse;
            Rows_label.Content = RowsShowed + " из " + RowAll;
               /* string search = Search.ToLower();
                datasourse = datasourse.Where(i => i.FirstName.ToLower().Contains(search) || i.Email.ToLower().Contains(search) || i.Phone.ToLower().Contains(search) == true).ToList();*/
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            
            Page++;
            Update();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            Page--;
            Update();
        }

        private void MainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (List.SelectedItem is Client client)
            {
                Personal wi = new Personal(client);
                wi.ShowDialog();

            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            New wi = new New();
            wi.ShowDialog();
        }

        private void RowsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page = 0;
            Update(); 
        }

        private void Poisk_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
