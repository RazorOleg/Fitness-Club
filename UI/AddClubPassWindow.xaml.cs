using System;
using System.Windows;
using System.Windows.Controls;
using API;

namespace UI
{
    public partial class AddClubPassWindow : Window
    {
        private readonly IController<ClubPassModel> clubsPassController;
        private readonly IController<ClubModel> clubsController;
        public AddClubPassWindow(IController<ClubPassModel> clubsPassController, IController<ClubModel> clubsController)
        {
            this.clubsPassController = clubsPassController;
            this.clubsController = clubsController;
            
            InitializeComponent();
            LoadComboBoxClubs();
        }

        void LoadComboBoxClubs()
        {
            comboxClubs.ItemsSource = clubsController.GetAll(); 
        }
        ClubPassModel AddClubPass()
        {
            var Club = comboxClubs.SelectedItem as ClubModel;
            try
            {
                ClubPassModel ClubPass = new ClubPassModel()
                {
                    Name = clubName.Text,
                    AvailableNumberOfVisits = int.Parse(visitsCount.Text),
                    Price = double.Parse(price.Text),
                    IsNet = (bool)isNet.IsChecked,
                    ClubId = Club.Id
                };
                clubsPassController.Add(ClubPass);
                Close();
                MessageBox.Show("Новий фітнес-абонемент додано");
                return ClubPass;
            }
            catch (Exception) { MessageBox.Show("Помилка!"); return null; }
        }

        private void Button_Click_AddClubPass(object sender, RoutedEventArgs e)
        {
            AddClubPass();
        }

        private void ComboxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var club = comboxClubs.SelectedItem as ClubModel;
            address.Text = club.Address;
            city.Text = club.City;
        }

    }
}
