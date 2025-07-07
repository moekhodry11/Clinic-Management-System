using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClinicService
    {
        protected IClinicRepo clinicRepo;
        public ClinicService(IClinicRepo _clinicRepo)
        {
            clinicRepo = _clinicRepo;
        }

        public void AddClinic(Models.Clinic clinic)
        {
            clinicRepo.Add(clinic);
            clinicRepo.Save();
        }
    }
}
