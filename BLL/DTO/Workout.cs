using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Workout
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public int? ClubId { get; set; } 
        public Club Club { get; set; } 
        public List<User> Clients { get; set; }
    }
}
