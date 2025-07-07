using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class DoctorRepo : Repository<Models.Doctor>, IDoctorRepo
    {
        public DoctorRepo(AppDbContext context) : base(context)
        {
        }
        public Doctor GetByPhoneNumber(string phoneNumber)
        {
            return dbSet.Find(phoneNumber);
        }
    }
}
