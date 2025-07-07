using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Doctor : User
    {
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}
