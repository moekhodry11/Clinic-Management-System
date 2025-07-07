using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class PatientRepo : Repository<Models.Patient>, Interfaces.IPatientRepo
    {
        public PatientRepo(AppDbContext _context) : base(_context)
        {
        }

        public Patient GetByPhoneNumber(string phoneNumber)
        {
            return dbSet.Include(p => p.Clinic)
                        .Include(p => p.Appointments)
                        .ThenInclude(a => a.Doctor)
                        .FirstOrDefault(p => p.PhoneNumber == phoneNumber);
        }
    }
}
