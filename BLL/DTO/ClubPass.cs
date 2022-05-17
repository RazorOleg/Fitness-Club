using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClubPass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
        public int? ClubId { get; set; } 
        public Club Club { get; set; } 
        public List<User> Clients { get; set; }
    }
}
