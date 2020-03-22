using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_CA2_API_Client.Models
{
    public class Golfer
    {
        public int GUI { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int Handicap { get; set; }

        public int ClubID { get; set; }

        public int CompID { get; set; }

        public int? StokeScore { get; set; }  // ? allows Nullable score

        public int? StableScore { get; set; }

        public virtual ICollection<Competition> Comps { get; set; } // Golfers can play many Comps

        public override string ToString()
        {
            return "\nGolfer Name: " + FirstName + " " + Surname + "\nGUI: " + GUI + "\nHandicap: " + Handicap + "\nClub: " + ClubID;
        }
    }
}
