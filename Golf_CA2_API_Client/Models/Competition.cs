using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_CA2_API_Client.Models
{
    public enum CompType
    {
        Strokeplay, Stableford
    }

    public class Competition
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public CompType Type { get; set; }

        public int ClubID { get; set; } // specific to each club

        public virtual ICollection<Golfer> Golfers { get; set; } // Many Golfers in each Comp

        public override string ToString()
        {
            return "\nComp Name: " + Name + "\nComp Type" + Type + "\nDate: " + Date; 
        }
    }
}
