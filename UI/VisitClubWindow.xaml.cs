using System.Windows;
using System.Windows.Controls;
using API;

namespace UI
{
    public partial class VisitClubWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<UserModel> usersController;
        public VisitClubWindow(IController<ClubModel> clubsController, IController<UserModel> usersController)
        {
            this.clubsController = clubsController;
            this.usersController = usersController;
            
            InitializeComponent();
            LoadComboBoxUsers();
            LoadComboBoxClubs();
        }
        void LoadComboBoxUsers()
        {
            comboxUsers.ItemsSource = usersController.GetAll().FindAll(x => x.ClubPassId != null);
        }
        void LoadComboBoxClubs()
        {
            comboxClubs.ItemsSource = clubsController.GetAll();
        }
        void Visit()
        {
            var user = usersController.GetById((int)comboxUsers.SelectedValue);
            if (user.AvailableNumberOfVisits > 0)
            {
                user.AvailableNumberOfVisits--;
                usersController.Update(user);
            }
            else 
                usersController.Remove(user.Id);
            Close();
        }
        private void ComboBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstname.Text = (comboxUsers.SelectedItem as UserModel).FirstName;
        }

        private void ComboBoxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            address.Text = (comboxClubs.SelectedItem as ClubModel).Address;
            city.Text = (comboxClubs.SelectedItem as ClubModel).City;
        }

        private void Button_Click_VisitClub(object sender, RoutedEventArgs e)
        {
            var user = (UserModel)comboxUsers.SelectedItem;
            var club = (ClubModel)comboxClubs.SelectedItem;
            if (user.ClubPass.ClubId == (int)comboxClubs.SelectedValue)
            {
                Visit();
                MessageBox.Show("Клієнт відвідав фітнес клуб за абонементом");
            }
            else if (user.ClubPass.IsNet && user.ClubPass.Club.Name == club.Name &&
                user.ClubPass.Club.City == club.City)
            {
                Visit();
                MessageBox.Show("Клієнт відвідав фітнес клуб за мережевим абонементом");
            }
            else { MessageBox.Show("В клієнта немає абонемента в даний фітнес клуб");  Close(); }
        }
    }
}
