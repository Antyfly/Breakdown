using Breakdown.Entity;
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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Personal : Window
    {
        Client clientsave;
        public Personal(Client client)
        {
            InitializeComponent();
            clientsave = client;
            IEnumerable<string> gendernamequery =
                from Gender in context.Gender
                where Gender.Code == client.GenderCode
                select Gender.Name;
            string GenderNameInfo = gendernamequery.First();
            FullName_label.Text = client.FullName;
            Gender.Text = GenderNameInfo;
            BirthDayDate_label.Text = client.Birthday.ToString();
            Email_label.Text = client.Email;
            phone.Text = client.Phone;
            Date_label.Text = client.RegistrationDate.ToString();
            var source = context.Client.Where(i => i.ID == client.ID).ToList();
            ImageList.ItemsSource = source;

            var genderquery = context.Gender.Select(i => i.Name).ToList();
            genderquery.Insert(0, "Выберите пол");
            Gender.ItemsSource = genderquery;
        }
        public string GenderAdd { get; set; } = "Выберите пол";
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Gender.SelectedIndex != -1)
            {
                clientsave.GenderCode = Gender.SelectedIndex.ToString();
            }
            
            clientsave.Phone = phone.Text;
            clientsave.RegistrationDate = Convert.ToDateTime(Date_label.Text);
            clientsave.Email = Email_label.Text;
            clientsave.Birthday = Convert.ToDateTime(BirthDayDate_label.Text);
            string[] testi = FullName_label.Text.Split(' ');
            clientsave.FirstName = testi[0];
            clientsave.LastName = testi[1];
            clientsave.Patronymic = testi[2];
            try
            {
                context.SaveChanges();
                MessageBox.Show("succ");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string test(Client client) 
        {
            string[] testi = client.FullName.Split(' ');
            return testi[0];
        }
    }
}
