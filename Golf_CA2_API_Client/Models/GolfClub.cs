using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_CA2_API_Client.Models
{
    public class GolfClub
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Golfer> Golfers { get; set; } // Many Golfers in each Comp

        public virtual ICollection<Competition> Comps { get; set; }

        public override string ToString()
        {
            return "Golf Club Name: " + Name;
        }

    }
}
