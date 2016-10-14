using npl_referralTool.DAL.Models;
using npl_referralTool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferralTool.Controllers
{
    public class ReferralController : ApiController
    {
        private ReferralRepository repository { get; set; }

        public ReferralController(ReferralRepository repo)
        {
            repository = repo;
        }

        public ReferralController()
        {
            repository = new ReferralRepository();
        }

        [HttpGet]
        [Route("referral")]
        public List<Referral> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("referral/{id}")]
        public Referral GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpGet]
        [Route("referral/client/{id}")]
        public List<Referral> GetByClientId(int id)
        {
            return repository.GetByClientId(id);
        }

        [HttpGet]
        [Route("referral/service/{id}")]
        public List<Referral> GetByServiceId(int id)
        {
            return repository.GetByServiceCategoryId(id);
        }

        [HttpPost]
        [Route("referral")]
        [Authorize]
        public void Add(Referral referral)
        {
            repository.Add(referral);
        }

        [HttpPut]
        [Route("referral")]
        [Authorize]
        public void Update(Referral referral)
        {
            repository.Update(referral);
        }

        [HttpDelete]
        [Route("referral")]
        [Authorize]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
