using ReferralTool.DAL;
using ReferralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferralTool.Controllers
{
    public class ServiceController : ApiController
    {
        private ServiceCategoryRepository repository { get; set; }

        public ServiceController(ServiceCategoryRepository repo)
        {
            repository = repo;
        }

        public ServiceController()
        {
            repository = new ServiceCategoryRepository();
        }

        [HttpGet]
        [Route("service")]
        public List<ServiceCategory> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("service/{id}")]
        public ServiceCategory GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        [Route("service")]
        public void Add(ServiceCategory serviceCategory)
        {
            repository.Add(serviceCategory);
        }

        [HttpPut]
        [Route("service")]
        public void Update(ServiceCategory serviceCategory)
        {
            repository.Update(serviceCategory);
        }

        [HttpDelete]
        [Route("service")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }
}
