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
using static Breakdown.Entity.CN;

namespace Breakdown
{
    /// <summary>
    /// Логика взаимодействия для New.xaml
    /// </summary>
    public partial class New : Window
    {
        public New()
        {
            InitializeComponent();
            var genderquery = context.Gender.Select(i => i.Name).ToList();
            genderquery.Insert(0, "Выберите пол");
            GenderBox.ItemsSource = genderquery;
        }
        public string GenderAdd { get; set; } = "Выберите пол";

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Client.Add(new Entity.Client
                {
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                    Patronymic = Patronymicbox.Text,
                    Birthday = BirthdayDatePick.SelectedDate.Value,
                    RegistrationDate = WorkingStartDatePick.SelectedDate.Value,
                    GenderCode = GenderBox.SelectedIndex.ToString(),
                    Email = EmailBox.Text,
                    Phone = PhoneBox.Text,

                }); ;
                MessageBox.Show("Успех");
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

