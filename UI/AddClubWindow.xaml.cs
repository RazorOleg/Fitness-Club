using System;
using System.Windows;
using API;

namespace UI
{
    public partial class AddClubWindow : Window
    {
        private readonly IController<ClubModel> clubsController;
        public AddClubWindow(IController<ClubModel> clubsController)
        {
            this.clubsController = clubsController;
            
            InitializeComponent();
        }

        ClubModel AddClub()
        {
            try
            {
                ClubModel Club = new ClubModel() { Name = clubName.Text, City = clubCity.Text, Address = clubAddress.Text };
                clubsController.Add(Club);
                Close();
                MessageBox.Show("Новий фітнес клуб додано!");
                return Club;
            }
            catch (Exception) { MessageBox.Show("Помилка!"); return null; }
        }

        private void Button_Click_AddClub(object sender, RoutedEventArgs e) => AddClub();
    }
}
