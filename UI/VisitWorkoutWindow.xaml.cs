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
using API;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для VisitWorkoutWindow.xaml
    /// </summary>
    public partial class VisitWorkoutWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<UserModel> usersController;
        public VisitWorkoutWindow(IController<ClubModel> clubsController, IController<UserModel> usersController)
        {
            this.clubsController = clubsController;
            this.usersController = usersController;

            InitializeComponent();
            LoadComboBoxUsers();
            LoadComboBoxClubs();
        }
        void LoadComboBoxUsers()
        {
            comboxUsers.ItemsSource = usersController.GetAll().FindAll(x => x.ClubPassId == null);
        }
        void LoadComboBoxClubs()
        {
            comboxClubs.ItemsSource = clubsController.GetAll();
        }

        void Visit()
        {
            var user = comboxUsers.SelectedItem as UserModel;
            if (user.AvailableNumberOfVisits > 0)
            {
                user.AvailableNumberOfVisits--;
                usersController.Remove(user.Id);
            }
            Close();
        }
        private void ComboBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstname.Text = (comboxUsers.SelectedItem as UserModel).FirstName;
        }

        private void ComboBoxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var club = comboxClubs.SelectedItem as ClubModel;
            address.Text = club.Address;
            city.Text = club.City;
            comboxWorkouts.ItemsSource = club.Workouts;
        }

        private void Button_Click_VisitWorkout(object sender, RoutedEventArgs e)
        {
            var user = comboxUsers.SelectedItem as UserModel;
            if (user.WorkoutId == (int)comboxWorkouts.SelectedValue)
            {
                Visit();
                MessageBox.Show("Клієнт відвідав разове заняття");
            }
            else { MessageBox.Show("Клієнт не записаний на дане заняття"); Close(); }
        }
    }
}
