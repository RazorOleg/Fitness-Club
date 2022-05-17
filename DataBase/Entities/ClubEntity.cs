using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ClubEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ClubPassEntity> ClubPasses { get; set; }
        public List<WorkoutEntity> Workouts { get; set; }
    }
}
