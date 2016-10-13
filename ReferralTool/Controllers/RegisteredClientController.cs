using System.Collections.Generic;
using System.Web.Http;
using ReferralTool.DAL;
using ReferralTool.DAL.Models;

namespace ReferralTool.Controllers
{
    public class RegisteredClientController : ApiController
    {
        private RegisteredClientRepository _registeredClientRepo  {get;set;}

        public RegisteredClientController (RegisteredClientRepository repo)
        {
            _registeredClientRepo = repo;
        }

        [HttpGet]
        [Route("client")]
        public  List<RegisteredClient> Get()
        {
            return _registeredClientRepo.GetAll();
        }
        
        [HttpGet]
        [Route("client/{id}")]
        public RegisteredClient GetByID(int id)
        {
            return _registeredClientRepo.GetById(id);
        }

        [HttpGet]
        [Route("client/{email}")]
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
        [Route("client/{id}")]
        public void UpdateClient(RegisteredClient client)
        {
            _registeredClientRepo.Update(client);
        }
    }
}
