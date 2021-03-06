using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AvailableNumberOfVisits { get; set; }
        public int? ClubPassId { get; set; } 
        public ClubPassModel ClubPass { get; set; } 
        public int? WorkoutId { get; set; } 
        public WorkoutModel Workout { get; set; } 
    }
}
