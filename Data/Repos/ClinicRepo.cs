using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ClinicRepo : Repository<Models.Clinic>, Interfaces.IClinicRepo
    {
        public ClinicRepo(AppDbContext _context) : base(_context)
        {
        }
    }
}
