﻿using npl_referralTool.DAL;
using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferralTool.Controllers
{
    public class AgencyController : ApiController
    {
        private AgencyRepository agencyRepo { get; set; }

        public AgencyController(AgencyRepository repo)
        {
            agencyRepo = repo;
        }

        public AgencyController()
        {
            agencyRepo = new AgencyRepository();
        }

        [HttpGet]
        [Route("agency")]
        public List<Agency> GetAll()
        {
            return agencyRepo.GetAll();
        }

        [HttpGet]
        [Route("agency/{id}")]
        public Agency GetById(int id)
        {
            return agencyRepo.GetById(id);
        }

        [HttpPost]
        [Route("agency")]
        [Authorize]
        public void Add(Agency agency)
        {
            agencyRepo.Add(agency);
        }

        [HttpPut]
        [Route("agency")]
        [Authorize]
        public void Update(Agency agency)
        {
            agencyRepo.Update(agency);
        }

        [HttpDelete]
        [Route("agency")]
        [Authorize]
        public void Delete(int id)
        {
            agencyRepo.Delete(id);
        }
    }
}
