using Regex_Kylosov.Classes;
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

namespace Regex_Kylosov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Passport> Passports = new List<Classes.Passport>();

        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }

        private void Add(object sender, RoutedEventArgs e) => new Windows.Add(null).ShowDialog();

        private void Update(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
                new Windows.Add(lv_passport.SelectedItem as Classes.Passport).ShowDialog();
            else MessageBox.Show("Выберите элемент для изменения");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItem as Classes.Passport);
                loadPassport();
            }
            else
                MessageBox.Show("Выберите элемент для удаления");
        }

        public void loadPassport()
        {
            lv_passport.Items.Clear();
            foreach (Classes.Passport passport in Passports)
                lv_passport.Items.Add(passport);
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (Passport item in lv_passport.Items)
            {

                if (item.Name.Contains(FindText.Text) ||
                    item.FirstName.Contains(FindText.Text) ||
                    item.LastName.Contains(FindText.Text) ||
                    item.Issued.Contains(FindText.Text) ||
                    item.DateOfIssued.Contains(FindText.Text) ||
                    item.DepartmnetCode.Contains(FindText.Text) ||
                    item.SeriesAndNumber.Contains(FindText.Text) ||
                    item.DateOfBirth.Contains(FindText.Text) ||
                    item.PlaceOfBirth.Contains(FindText.Text) ||
                    item.PathToImage.Contains(FindText.Text))
                {
                    new Windows.Add(lv_passport.Items[i] as Classes.Passport).ShowDialog();
                }
                i++;
            }
        }
    }
}
