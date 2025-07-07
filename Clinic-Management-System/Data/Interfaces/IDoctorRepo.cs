﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDoctorRepo : IRepository<Models.Doctor>
    {
        public Doctor GetByPhoneNumber(string phoneNumber); 
    }
}
