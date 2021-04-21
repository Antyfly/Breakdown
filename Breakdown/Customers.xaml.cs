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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public int Page { get; set; } = 0;
        public Customers()
        {
            InitializeComponent();
            DataContext = this;
            Update();

        }
        public void Update()
        {
            
            var datasourse = CN.content.Client.ToList();
            datasourse = datasourse.Skip(Page * 50).Take(50).ToList();
            List.ItemsSource = datasourse;
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

        }

        private void OffersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
