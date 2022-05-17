using System.Windows;
using System.Windows.Controls;
using API;

namespace UI
{
    public partial class BuyClubPassWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<UserModel> usersController;
        public BuyClubPassWindow(IController<ClubModel> clubsController, IController<UserModel> usersController)
        {
            this.clubsController = clubsController;
            this.usersController = usersController;
            
            InitializeComponent();
            LoadComboBoxClubs();
        }
        void LoadComboBoxClubs()
        {
            comboxClubs.ItemsSource = clubsController.GetAll();
        }

        UserModel AddUser()
        {
            var ClubPass = comboxClubPasses.SelectedItem as ClubPassModel;
            UserModel User = new UserModel()
            {
                FirstName = userFirstName.Text,
                LastName = userLastName.Text,
                AvailableNumberOfVisits = ClubPass.AvailableNumberOfVisits,
                ClubPassId = ClubPass.Id
            };
            usersController.Add(User);
            Close();
            MessageBox.Show("Абонемент придбано, нового клієнта додано до БД");
            return User;
        }
        private void Button_Click_BuyClubPass(object sender, RoutedEventArgs e) => AddUser();
        private void ComboxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var club = comboxClubs.SelectedItem as ClubModel;
            address.Text = club.Address;
            city.Text = club.City;
            comboxClubPasses.ItemsSource = club.ClubPasses;
        }

        private void ComboxClubPasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clubpass = comboxClubPasses.SelectedItem as ClubPassModel;
            price.Text = clubpass.Price.ToString();
            availableNumberOfVisits.Text = clubpass.AvailableNumberOfVisits.ToString();
        }
    }
}
