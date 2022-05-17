using System.Windows;
using System.Windows.Controls;
using API;

namespace UI
{
    public partial class BuyWorkoutWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<UserModel> usersController;
        public BuyWorkoutWindow(IController<ClubModel> clubsController,  IController<UserModel> usersController)
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
            UserModel User = new UserModel()
            {
                FirstName = userFirstName.Text,
                LastName = userLastName.Text,
                AvailableNumberOfVisits = 1,
                WorkoutId = (int)comboxWorkouts.SelectedValue
            };
            usersController.Add(User);
            Close();
            MessageBox.Show("Абонемент придбано, нового клієнта додано до БД");
            return User;
        }
        private void Button_Click_BuyWorkout(object sender, RoutedEventArgs e) => AddUser();
        private void ComboBoxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var club = comboxClubs.SelectedItem as ClubModel;
            address.Text = club.Address;
            city.Text = club.City;
            comboxWorkouts.ItemsSource = club.Workouts;
        }

        private void ComboBoxWorkouts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var workout = comboxWorkouts.SelectedItem as WorkoutModel;
            price.Text = workout.Price.ToString();
            date.Text = workout.Time.ToString();
        }
    }
}
