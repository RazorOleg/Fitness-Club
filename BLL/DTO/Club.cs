using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ClubPass> ClubPasses { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
