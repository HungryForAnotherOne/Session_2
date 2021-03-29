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
using WpfApp1.Model;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для PravaAdmin.xaml
    /// </summary>
    public partial class PravaAdmin
    {
        BlackBlockEntities blackBlockEntities = new BlackBlockEntities();
        List<string> list = new List<string>() { "Дом", "Квартира", "Земля" };
        public PravaAdmin()
        {
            InitializeComponent();
            Prava.ItemsSource = blackBlockEntities.All.ToList();
            Typi.ItemsSource = list;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRedactArea addArea = new AddRedactArea();
            addArea.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Prava.SelectedItems.Count > 0)
            {
                All alls = (All)Prava.SelectedItems[0];
                blackBlockEntities.All.Remove(alls);
                blackBlockEntities.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            blackBlockEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Prava.ItemsSource = blackBlockEntities.All.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Prava.SelectedItems.Count > 0)
            {
                All alls = (All)Prava.SelectedItems[0];
                AddRedactArea redactArea = new AddRedactArea(alls);
                redactArea.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Typi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = Typi.SelectedItem.ToString();
            var realProperties = blackBlockEntities.All.Where(cl => cl.TypeObject.ToLower().Contains(filter.ToLower())).ToList();
            Prava.ItemsSource = realProperties.ToList();
        }
    }
}
