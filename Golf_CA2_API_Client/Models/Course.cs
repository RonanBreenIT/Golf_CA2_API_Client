using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_CA2_API_Client.Models
{
    public class Course
    {
        public int ID { get; set; } // May have more than one course

        public string Name { get; set; }

        public int Holes { get; set; }

        public int HoleNumber { get; set; }

        public int Distance { get; set; }

        public int Index { get; set; }

        public int Par { get; set; }

        public int ClubID { get; set; } // specific to each club

        public virtual ICollection<Competition> Comps { get; set; } // Course can have many Comps

        public override string ToString()
        {
            return "\nCourse Name: " + Name + "\nID: " + ID + "Holes: " + Holes + "\nClub: " + ClubID;
        }

    }
}
