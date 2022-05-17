using System;
using System.Windows;
using API;

namespace UI
{
    public partial class UserControlWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        private readonly IController<ClubPassModel> clubsPassController;
        private readonly IController<UserModel> usersController;
        private readonly IController<WorkoutModel> workoutsController;
        public UserControlWindow(IController<ClubModel> clubsController, IController<ClubPassModel> clubsPassController, IController<UserModel> usersController, IController<WorkoutModel> workoutsController)
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
            clientList1.ItemsSource = usersController.GetAll().FindAll(x => x.ClubPassId != null);
            clientList2.ItemsSource = usersController.GetAll().FindAll(x => x.WorkoutId != null);
        }
        private void Update_DG(object sender, EventArgs e) => LoadDG();
        private void Button_Click_BuyClubPass(object sender, RoutedEventArgs e)
        {
            BuyClubPassWindow clubPassWindow = new BuyClubPassWindow(clubsController, usersController);
            clubPassWindow.Closed += Update_DG;
            clubPassWindow.ShowDialog();
        }

        private void Button_Click_BuyWorkout(object sender, RoutedEventArgs e)
        {
            BuyWorkoutWindow workoutWindow = new BuyWorkoutWindow(clubsController, usersController);
            workoutWindow.Closed += Update_DG;
            workoutWindow.ShowDialog();
        }

        private void Button_Click_VisitClub(object sender, RoutedEventArgs e)
        {
            VisitClubWindow visitClubWindow = new VisitClubWindow(clubsController, usersController);
            visitClubWindow.Closed += Update_DG;
            visitClubWindow.ShowDialog();
            LoadDG();
        }

        private void Button_Click_VisitWorkout(object sender, RoutedEventArgs e)
        {
            VisitWorkoutWindow visitWorkoutWindow = new VisitWorkoutWindow(clubsController, usersController);
            visitWorkoutWindow.Closed += Update_DG;
            visitWorkoutWindow.ShowDialog();
        }
    }
}
