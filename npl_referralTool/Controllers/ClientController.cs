using npl_referralTool.DAL;
using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace npl_referralTool.Controllers
{
    public class ClientController : ApiController
    {
        private RegisteredClientRepository _registeredClientRepo { get; set; }

        public ClientController(RegisteredClientRepository repo)
        {
            _registeredClientRepo = repo;
        }

        [HttpGet]
        [Route("client")]
        [Authorize]
        public List<RegisteredClient> Get()
        {
            return _registeredClientRepo.GetAll();
        }

        [HttpGet]
        [Route("client/{id}")]
        [Authorize]
        public RegisteredClient GetByID(int id)
        {
            return _registeredClientRepo.GetById(id);
        }

        [HttpGet]
        [Route("client/{email}")]
        [Authorize]
        public RegisteredClient GetByEmail(string email)
        {
            return _registeredClientRepo.GetByEmail(email);
        }

        [HttpPost]
        [Route("client/")]
        public void AddClient(RegisteredClient client)
        {
            _registeredClientRepo.AddClient(client);
        }

        [HttpPut]
        [Route("client/")]
        [Authorize]
        public void UpdateClient(RegisteredClient client)
        {
            _registeredClientRepo.Update(client);
        }

        [HttpDelete]
        [Route("client")]
        [Authorize]
        public void Delete(int clientId)
        {
            _registeredClientRepo.Delete(clientId);
        }
    }
}
