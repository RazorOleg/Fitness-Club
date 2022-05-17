using System;
using System.Collections.Generic;

namespace API
{
    public class WorkoutModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public int? ClubId { get; set; } 
        public ClubModel Club { get; set; } 
        public List<UserModel> Clients { get; set; }
    }
}
