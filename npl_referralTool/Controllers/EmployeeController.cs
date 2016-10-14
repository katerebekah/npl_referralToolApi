using npl_referralTool.DAL;
using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferralTool.Controllers
{
    public class EmployeeController : ApiController
    {
        private AgencyEmployeeRepository repository { get; set; }

        public EmployeeController(AgencyEmployeeRepository repo)
        {
            repository = repo;
        }

        public EmployeeController()
        {
            repository = new AgencyEmployeeRepository();
        }
        
        [HttpGet]
        [Route("employee")]
        public List<AgencyEmployee> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("employee/{id}")]
        public AgencyEmployee GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpGet]
        [Route("employee/agency/{id}")]
        public List<AgencyEmployee> GetByAgencyId(int id)
        {
            return repository.GetByAgencyId(id);
        }

        [HttpPost]
        [Route("employee")]
        [Authorize]
        public void Add(AgencyEmployee employee)
        {
            repository.Add(employee);
        }

        [HttpPut]
        [Route("employee")]
        [Authorize]
        public void Update(AgencyEmployee employee)
        {
            repository.Update(employee);
        }

        [HttpDelete]
        [Route("employee")]
        [Authorize]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
