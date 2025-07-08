using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class AssistantRepo : Repository<Models.Assistant>, Interfaces.IAssistantRepo
    {
        public AssistantRepo(AppDbContext _context) : base(_context)
        {
        }

        public Assistant GetByPhoneNumber(string phoneNumber)
        {
            return dbSet.Include(a => a.Clinic)
                        .FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        }
    }
}
