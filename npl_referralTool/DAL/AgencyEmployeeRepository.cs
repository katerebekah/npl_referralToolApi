using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL
{
    public class AgencyEmployeeRepository
    {
        private ReferralContext Context { get; set; }

        public AgencyEmployeeRepository()
        {
            Context = new ReferralContext();
        }

        public AgencyEmployeeRepository(ReferralContext context)
        {
            Context = context;
        }

        /*
         * Add
         * Update
         * Delete
         * GetById
         * GetByAgencyId
         * GetAll
         */

        public void Add(AgencyEmployee employee)
        {
            Context.AgencyEmployees.Add(employee);
            Context.SaveChanges();
        }

        public void Update(AgencyEmployee employee)
        {
            var currentEmployee = Context.AgencyEmployees.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID);
            if (currentEmployee != null)
            {
                currentEmployee.Agency = employee.Agency;
                currentEmployee.AreaCode = employee.AreaCode;
                currentEmployee.EmailAddress = employee.EmailAddress;
                currentEmployee.FirstName = employee.FirstName;
                currentEmployee.LastName = employee.LastName;
                currentEmployee.PhoneNumber = employee.PhoneNumber;
                currentEmployee.ServiceCategories = currentEmployee.ServiceCategories;
            }
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var currentEmployee = Context.AgencyEmployees.FirstOrDefault(x => x.EmployeeID == id);
            if (currentEmployee != null)
            {
                Context.AgencyEmployees.Remove(currentEmployee);
            }
            Context.SaveChanges();
        }

        public AgencyEmployee GetById(int id)
        {
            return Context.AgencyEmployees.FirstOrDefault(x => x.EmployeeID == id);
        }

        public List<AgencyEmployee> GetByAgencyId (int id)
        {
            return Context.AgencyEmployees.Where(x => x.Agency.AgencyID == id).ToList();
        }

        public List<AgencyEmployee> GetAll()
        {
            return Context.AgencyEmployees.ToList();
        }
    }
}