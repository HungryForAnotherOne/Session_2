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
    /// Логика взаимодействия для See.xaml
    /// </summary>
    public partial class See 
    {
        BlackBlockEntities blackBlockEntities = new BlackBlockEntities();
        List<string> list = new List<string>() { "Дом", "Квартира", "Земля" };
        public See()
        {
            InitializeComponent();
            Low.ItemsSource = blackBlockEntities.All.ToList();
            Kily.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            blackBlockEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Low.ItemsSource = blackBlockEntities.All.ToList();
        }

        private void Low_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Kily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = Kily.SelectedItem.ToString();
            var realProperties = blackBlockEntities.All.Where(cl => cl.TypeObject.ToLower().Contains(filter.ToLower())).ToList();
            Low.ItemsSource = realProperties.ToList();
        }
    }
}
