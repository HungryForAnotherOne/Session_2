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
    /// Логика взаимодействия для AddRedactArea.xaml
    /// </summary>
    public partial class AddRedactArea
    {
        All _all = new All();
        BlackBlockEntities blackBlockEntities = new BlackBlockEntities();

      

        public AddRedactArea()
        {
            InitializeComponent();
        }
        public AddRedactArea(All alls)
        {
            InitializeComponent();
            City.Text = alls.City;
            Street.Text = alls.Street;
            TypeObject.Text = alls.TypeObject;
            HouseNumber.Text = alls.HouseNumber.ToString();
            FlatNummber.Text = alls.FlatNummber.ToString();
            Latitude.Text = alls.Latitude.ToString();
            Longitude.Text = alls.Longitude.ToString();
            Floor.Text = alls.Floor.ToString();
            NumberOfRooms.Text = alls.NumberOfRooms.ToString();
            NumberOfFloors.Text = alls.NumberOfFloors.ToString();
            Area.Text = alls.Area.ToString();
            _all.Id = alls.Id;
        }
        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            if (int.Parse(Latitude.Text) <= -90)
            {
                error.AppendLine("Широта от -90 до +90");
            }
            if (int.Parse(Latitude.Text) >= +90)
            {
                error.AppendLine("Широта от -90 до +90");
            }
            if (int.Parse(Longitude.Text) <= -180)
            {
                error.AppendLine("Долгота от -180 до +180");
            }
            if (int.Parse(Longitude.Text) >= +180)
            {
                error.AppendLine("Долгота от -180 до +180");
            }
            if (TypeObject.Text == "Дом" || TypeObject.Text == "Квартира" || TypeObject.Text == "Земля")
            {
                error.AppendLine("Тип недвижимости может быть лишь: Дом/Квартира/Земля!");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {

                try
                {
                    if (_all.Id == 0)
                    {
                        _all.City = City.Text;
                        _all.Street = Street.Text;
                        _all.TypeObject = TypeObject.Text;
                        _all.HouseNumber = int.Parse(HouseNumber.Text);
                        _all.FlatNummber = int.Parse(FlatNummber.Text);
                        _all.Latitude = int.Parse(Latitude.Text);
                        _all.Longitude = int.Parse(Longitude.Text);
                        _all.Floor = int.Parse(Floor.Text);
                        _all.NumberOfRooms = int.Parse(NumberOfRooms.Text);
                        _all.NumberOfFloors = int.Parse(NumberOfFloors.Text);
                        _all.Area = int.Parse(Area.Text);
                        blackBlockEntities.All.Add(_all);
                    }
                    else
                    {
                        All tempAll = blackBlockEntities.All.FirstOrDefault(u => u.Id == _all.Id);
                        tempAll.City = City.Text;
                        tempAll.Street = Street.Text;
                        tempAll.TypeObject = TypeObject.Text;
                        tempAll.HouseNumber = int.Parse(HouseNumber.Text);
                        tempAll.FlatNummber = int.Parse(FlatNummber.Text);
                        tempAll.Latitude = int.Parse(Latitude.Text);
                        tempAll.Longitude = int.Parse(Longitude.Text);
                        tempAll.Floor = int.Parse(Floor.Text);
                        tempAll.NumberOfRooms = int.Parse(NumberOfRooms.Text);
                        tempAll.NumberOfFloors = int.Parse(NumberOfFloors.Text);
                        tempAll.Area = int.Parse(Area.Text);
                    }
                    blackBlockEntities.SaveChanges();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
    }
}
