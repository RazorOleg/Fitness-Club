using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ClubPassEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
        public int? ClubId { get; set; } 
        public ClubEntity Club { get; set; } 
        public List<UserEntity> Clients { get; set; }
    }
}
