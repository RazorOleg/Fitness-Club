using System;
using System.Windows;
using System.Windows.Controls;
using API;

namespace UI
{
    public partial class AddWorkoutWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<WorkoutModel> workoutsController;
        public AddWorkoutWindow(IController<ClubModel> clubsController, IController<WorkoutModel> workoutsController)
        {
            this.clubsController = clubsController;
            this.workoutsController = workoutsController;
           
            InitializeComponent();
            LoadHours();
            LoadMin();
            LoadComboBoxClubs();
        }

        void LoadComboBoxClubs()
        {
            comboxClubs.ItemsSource = clubsController.GetAll();
        }

        void LoadHours()
        {
            for (int i = 9; i < 20; i++)
                hours.Items.Add(i++);
        }
        void LoadMin()
        {
            for (int i = 0; i < 59; i++)
                min.Items.Add(i++);
        }

        WorkoutModel AddWorkout()
        {
            try
            {
                WorkoutModel newWorkout = new WorkoutModel()
                {
                    Type = type.Text,
                    Time = new DateTime(picker.SelectedDate.Value.Year, picker.SelectedDate.Value.Month, picker.SelectedDate.Value.Day, Int32.Parse(hours.SelectedItem.ToString()), Int32.Parse(min.SelectedItem.ToString()), 0),
                    ClubId = (int)comboxClubs.SelectedValue,
                    Price = Double.Parse(price.Text)
                };
                workoutsController.Add(newWorkout);
                Close();
                MessageBox.Show("Нове разове заняття додано");
                return newWorkout;
            }
            catch (Exception) { MessageBox.Show("Помилка!"); return null; }
        }

        private void Button_Click_AddWorkout(object sender, RoutedEventArgs e) => AddWorkout();

        private void ComboBoxClubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var club = comboxClubs.SelectedItem as ClubModel;
            address.Text = club.Address;
            city.Text = club.City;
        }
    }
}
