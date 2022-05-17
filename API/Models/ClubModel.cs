using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ClubPassModel> ClubPasses { get; set; }
        public List<WorkoutModel> Workouts { get; set; }
    }
}
