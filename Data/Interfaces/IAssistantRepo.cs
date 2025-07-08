using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAssistantRepo : IRepository<Models.Assistant>
    {
        public Assistant GetByPhoneNumber(string phoneNumber);
    }
}
