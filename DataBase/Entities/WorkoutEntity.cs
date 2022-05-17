using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class WorkoutEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public int? ClubId { get; set; } 
        public ClubEntity Club { get; set; } 
        public List<UserEntity> Clients { get; set; }
    }
}
