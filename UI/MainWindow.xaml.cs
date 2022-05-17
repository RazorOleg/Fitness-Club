using System;
using System.Linq;
using System.Windows;
using API;

namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<ClubPassModel> clubsPassController;
        private readonly IController<UserModel> usersController;
        private readonly IController<WorkoutModel> workoutsController;

        public MainWindow(IController<ClubModel> clubsController, IController<ClubPassModel> clubsPassController, IController<UserModel> usersController, IController<WorkoutModel> workoutsController)
        {
            this.clubsController = clubsController;
            this.clubsPassController = clubsPassController;
            this.usersController = usersController;
            this.workoutsController = workoutsController;
            InitializeComponent();
            LoadDG();
        }

        void LoadDG()
        {
            clubList.ItemsSource = clubsController.GetAll();
            clubPassList.ItemsSource = clubsPassController.GetAll();
            workoutList.ItemsSource = workoutsController.GetAll();
        }
        private void Button_Click_UserControl(object sender, RoutedEventArgs e)
        {
            UserControlWindow userWindow = new UserControlWindow(clubsController, clubsPassController, usersController, workoutsController);
            userWindow.Closed += Update_DG;
            userWindow.ShowDialog();
        }
        private void Button_Click_AddClub(object sender, RoutedEventArgs e)
        {
            AddClubWindow clubWindow = new AddClubWindow(clubsController);
            clubWindow.Closed += Update_DG;
            clubWindow.ShowDialog();
        }
        private void Button_Click_RemoveClub(object sender, RoutedEventArgs e)
        {
            if (clubList.SelectedItem != null)
            {
                clubsController.Remove((clubList.SelectedItem as ClubModel).Id);
                clubsController.Save();
                LoadDG();
            }                
        }
        private void Button_Click_AddClubPass(object sender, RoutedEventArgs e)
        {
            AddClubPassWindow clubPassWindow = new AddClubPassWindow(clubsPassController, clubsController);
            clubPassWindow.Closed += Update_DG;
            clubPassWindow.ShowDialog();
        }
        private void Update_DG(object sender, EventArgs e)
        {
            LoadDG();
        }
        private void Button_Click_RemoveClubPass(object sender, RoutedEventArgs e)
        {
            var deletedClubPass = (ClubPassModel)clubPassList.SelectedItem;
            if (deletedClubPass != null)
            {
                clubsPassController.Remove(deletedClubPass.Id);
                clubsPassController.Save();
                LoadDG();
            }
        }
        private void Button_Click_AddWorkout(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow newWorkout = new AddWorkoutWindow(clubsController, workoutsController);
            newWorkout.Closed += Update_DG;
            newWorkout.ShowDialog();
        }

        private void Button_Click_RemoveWorkout(object sender, RoutedEventArgs e)
        {
            workoutsController.Remove(((WorkoutModel)workoutList.SelectedItem).Id);
            workoutsController.Save();
            LoadDG();
        }

    }
}
